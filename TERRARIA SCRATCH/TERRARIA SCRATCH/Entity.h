#ifndef ENTITY_H
#define ENTITY_H
#include "Constants.h"
#include "Shapes.h"
#include <vector>
#include <typeinfo>
// Forward declarations
class Spell;
class Buff;
class Block;
class Item;
class DiggingBlock
{
	BlockPos blockID;
	Block* blockPointer;
	float hpNOW;
public:
	DiggingBlock(const BlockPos bPos);
	BlockPos GetBlockID();
};
// ALLY, ( Player: Cannot hurt, Ally: Cannot hurt, Enemies: Attacks hurt, NeutralHostile: Attacks
// NEUTRAL, ( Ally: Cannot hurt)
// NEUTRALALLY, ( Neutral Ally: 
// HOSTILE, attacks allies and neutrals
// CHAOTIC, able to attack everything, be attacked by everything
enum Hostility
{
	entAlly,
	entNeutral,
	entNeutralAlly,
	entNeutralHostile,
	entHostile,
	entChaotic
};
class Entity
{
#define HP_DEFAULT 50
#define MOVEMENT_SPEED 300
#define ARMOUR	0
#define FALL_THRESHOLD 150
protected:
	XMFLOAT2 posOLD;
	XMFLOAT2 posNEW;
	bool fallingNOW = false;
	bool fallingOLD = false;
	bool invulnerable = false;
	float airResistance = 0.9f; // smaller than 1
	float armour;
	float fallThreshold = FALL_THRESHOLD;
	// List of buffs
	vector<Buff*> buffList;
	// Blocks being dug
	vector<DiggingBlock> diggingList;
public:
	float hpNOW;
	float hpMAX;
	string entityName;
	Entity();
	bool isSilence;
	XMFLOAT2 movementVel;
	XMFLOAT2 movementVelUNCHANGED;
	XMFLOAT2 vel;
	Rect rectangle;
	// Entity Alignment
	Hostility hostility;
	// Is in water?
	bool inWater;

	// ---------------------------------------------------------------------------------
	// PHYSICS-ENTITY FUNCTIONS
	// ---------------------------------------------------------------------------------
	// GRAVITY & FALLING ===================
	virtual void Gravity();
	// Sets entity's falling state
	void SetFalling(bool IsFalling);
	// Envoking this will cause the entity to take damage according to Y velocity
	virtual void Fell();

	// OTHER ===============================
	// Apply air resistance
	virtual void ApplyResistance();
	// Checks whether the entity has hit a block
	virtual void blockCollision();

	// ---------------------------------------------------------------------------------
	// BUFF-ENTITY FUNCTIONS
	// ---------------------------------------------------------------------------------
	// Applies a buff accordingly
	void ApplyBuff(Buff* buff);
	// Rids SELF of all bad buffs
	void CleanseBuffs();
	// Checks if a buff is present
	bool isBuffPresent(Buff& buff);	
	// Applies buff functions and checks if they have expired
	virtual void BuffFunctions();

	// ---------------------------------------------------------------------------------
	// HEALTH-ENTITY FUNCTIONS
	// ---------------------------------------------------------------------------------
	void resetCurrentHP(); // hpNOW = hpMAX
	// Determines whether SELF takes damage or not
	virtual void Damage(float damage);
	// Heals Self
	virtual void Heal(float HealValue);

	// ---------------------------------------------------------------------------------
	// ENTITY-ENTITY COMBAT FUNCTIONS
	// ---------------------------------------------------------------------------------
	// Hurt's other entity according to Hostility
	virtual void HurtOther(Entity& entity, float damage);
	// Determines how fast an entity can move according to buffs, if falling, etc
	virtual void CalculateMovementVelocity();

	// ---------------------------------------------------------------------------------
	// OTHER
	// ---------------------------------------------------------------------------------
	// Envokes typical entity functions
	virtual void EntilyFunctions();
	// Makes the Entity move
	virtual void EntityMovement();
	// The update function
	virtual void Update();
	// Kills SELF
	virtual void Kill();
	// Returns name
	string GetEntityName();
	// Jump
	virtual void Jump();
	// Add to digging list
	virtual void AddToDigList(const BlockPos bPos);
};
#endif
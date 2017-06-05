#ifndef PLAYER_H
#define PLAYER_H
#include "Entity.h"
class Item;
class Accessory;
class Headgear;
class ChestPiece;
class Boots;
class Ammunition;
enum EquipmentType;
class Player :protected Entity
{
#define HP_DEFAULT 50
#define MOVEMENT_SPEED 300
#define ARMOUR 0
#define FALL_THRESHOLD 150


	 bool dead;
	void Regen();
	void LoadStats();
	// When player dies
	void Die();
	// When damage dealt
	void Damage(float damage);
	void EntityMovement();
	// When game tick occurs
	void Update();
	// =================================================================================
	// STATS
	// =================================================================================
	 float mpNOW;
	 float mpMAX;
	 float hpRgn;
	 float hpRgnTmrNOW;
	 float hpRgnTmrMAX;	
	 float ms;
	 float jumpHeight;
	 float itemGravityRange;
	// =================================================================================
	// INVENTORY
	// =================================================================================
	Item * inventory[50];
	Accessory * accessories[5];
	Headgear* headgear;
	ChestPiece* chestpiece;
	Boots* boots;
	Ammunition* ammunition[3];

	Headgear* vanityHeadgear;
	ChestPiece* vanityChestpiece;
	Boots* vanityBoots;
public:	
	// ---------------------------------------------------------------------------------
	// MAGIC-PLAYER FUNCTIONS
	// ---------------------------------------------------------------------------------
	// Makes Entity cast a specific spell
	virtual void CastSpell(Spell& spell);
	void HealMana(float value);

	// ---------------------------------------------------------------------------------
	// ITEM-PLAYER FUNCTIONS
	// ---------------------------------------------------------------------------------
	void ItemGravity();
	void pickUpItem();
	void dropItem();
	// EQUIPMENT ===========================
	void Equip();
	void Unequip();
};
static Player player;
#endif
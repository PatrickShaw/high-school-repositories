#ifndef CREATURES_H
#define CREATURES_H
#include "Entity.h"
#include "LootList.h"
// Entity constructor for headers
#define PE_CONSTRUCT_CPP(Child,Parent,lootListDEFAULT) Child::(const LootList lootList = lootListDEFAULT):Parent(lootListDEFAULT)
#define E_CONSTRUCT_CPP(Child,Parent,lootList) Child::Child(const LootList lootList):Parent(lootList)
class NonPlayer:public Entity
{
	public:
		 NonPlayer();
		 float damageValue;
		 virtual void Attack(Entity& entity);
protected:
	 LootList* lootList;
	 virtual void Drop(const XMFLOAT2 pos );
	 virtual void SetLootList(LootList& LootList);
	 float damageValue_DEFAULT;
	 float hpMAX_DEFAULT;
};
enum Size
{
	little,normal,large
};
class Creature :public NonPlayer
{
protected:
	Creature();
	float mobDropRate;
	Size size;
	float GetSizeDropRate();
};
class Animal :public Creature
{
	Animal();
};
// Relatives to slimes, are not hostile, do not attack
// Can be tamed, come in all colours
// Acts as a support pet
class Jelly :public Animal
{

};
class Monster: public Creature
{
protected:
	// Mob drop rate calculates the amount of crap a particular mob would give relative to how much a Normal monster of the given species would give

	Monster();
};
class Slime :public Monster
{
public:
	string slimePrefix;
	string slimeName;
	float fuseValue;
	float absorbedValue;
	float cooldownMAX = 1;
	float cooldownNOW = cooldownMAX;
	// Values refer to the value when fused
	enum SlimeRank
	{
		petty = 1,lesser = 2, normal = 3, greater = 10, goliath = 15
	};
	SlimeRank slimeRank;
#define SLIME_PREFIX_PETTY		"Petty "
#define SLIME_PREFIX_LESSER		"Lesser "
#define SLIME_PREFIX_NORMAL		""
#define SLIME_PREFIX_GREATER	"Greater "
#define SLIME_PREFIX_GOLIATH	"Goliath "
#define SLIME_THRESHOLD_LESSER  3
#define SLIME_THRESHOLD_NORMAL	5
#define SLIME_THRESHOLD_GREATER	10
#define SLIME_THRESHOLD_GOLIATH 30
#define SLIME_SPLIT_GREATER		3 //3 Lessers
#define SLIME_SPLIT_GOLIATH		5 //5 Normals
#define SLIME_HP_PETTY   1
#define SLIME_HP_LESSER  20
#define SLIME_HP_NORMAL	 50
#define SLIME_HP_GREATER 120
#define SLIME_HP_GOLIATH 250
#define SLIME_DAMAGE_PETTY 0.0F
#define SLIME_DAMAGE_LESSER 3.0F
#define SLIME_DAMAGE_NORMAL 12.0F
#define SLIME_DAMAGE_GREATER 40.0F
#define SLIME_DAMAGE_GOLIATH 150.0F
	Slime();
	virtual void Drop();
	static void PossibleUpgrade(Slime& slime);
	void Fuse(Slime& otherslime);
	void RecalculateStats();
	void EntityCollision(Entity& entity);
	virtual void Attack(Entity& entity);
	virtual void AdditionalAttack(Entity& entity);
	void SetSlimeRank(SlimeRank rank);
};
class FireSlime :public Slime
{
public:
	FireSlime();
	void AdditionalAttack(Entity& entity);
};
#endif
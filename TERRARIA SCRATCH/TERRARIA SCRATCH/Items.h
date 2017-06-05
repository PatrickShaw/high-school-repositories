#ifndef ITEMS_H
#define ITEMS_H
#include "Constants.h"
#include <string>
class Entity;
class Item
{
public:
	string itemName;
	string tooltip;
protected:
	int stackNumber = 0;
	int amount = 1;
	bool creative = false;
	bool dissolves = false;
	bool melts = true;
	bool hovers = false;
	virtual void SetAmount(int Amount) { amount = Amount; };
	virtual void Use() = 0;
};
// MISC ====
class Misc :public Item
{

};
class Gel :public Misc
{
public:
	Gel();
	virtual void Use();
};
// BLOCKPLACERS ====
class BlockPlacer :public Item
{

};
class DirtBlock :public BlockPlacer
{
public:
	DirtBlock();
	virtual void Use(XMFLOAT2 pos);
};

// EQUIPMENT ====
enum EquipmentType
{
	headgear,
	chestpiece,
	boots,
	accessories
};
class Equipment :public Item
{
public:
	virtual void Equipped();
	virtual void Unequipped();
	Equipment();
};
class Ammunition : public Equipment
{
protected:
	Ammunition();
};
class Accessory : public Equipment
{

};
class Armour :public Equipment
{
protected:
	float defense;
	virtual void WhenHit() = 0;
};
class Headgear :public Armour
{

};
class ChestPiece:public Armour
{

};
class Boots:public Armour
{

};
class Weapons :public Equipment
{
protected:
	float damage;
	bool twohanded = false;

	virtual void OnHit() = 0;
};
class MeleeW :public Weapons
{

};
class MiningTools :public MeleeW
{
protected:
	const float miningStrength;
	MiningTools(const float miningStr = 1) :miningStrength(miningStr){};
};
class RangedW :public Weapons
{
protected:
	virtual void Use();
	virtual void Shoot() = 0;
};
class Bows :public RangedW
{

};
class ThrowingW :public RangedW
{
};
#endif
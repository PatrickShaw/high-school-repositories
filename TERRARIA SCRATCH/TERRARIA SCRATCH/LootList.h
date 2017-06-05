#ifndef LOOTLIST_H
#define LOOTLIST_H
#define DROPS(...) __VA_ARGS__ 
#define ARRAY(dropArray) DROPS(dropArray)
#include "Items.h"
#include <string>
#include <iostream>
#include "Shapes.h"
class Item;
struct LiveItem
{
	LiveItem& operator=(LiveItem& element){ return element; }
	Item &item;
	XMFLOAT2 pos;
	XMFLOAT2 vel;
	int ID; // ID in the world, used to work out where it is in the vector list
};
struct Drop
{
	Drop(const Item& Item,const float Chance) :chance(Chance), item(Item){}
	// 0<x<=1
	const float chance;
	const Item& item;
};
struct LootList
{
public:
	const Drop* dropPointer; // Never changes adress
	const int size;
	LootList(const Drop* DropPointer, const int DropAmount) :dropPointer(DropPointer),size(DropAmount){}
};
struct DropV2
{
public:
	const int maxAmount;
	const int minAmount;
	const float chance;
	const Item& item;
	DropV2(const Item& Item,const int Max,const int Min, const float Chance):item(Item),minAmount(Min),maxAmount(Max),chance(Chance){}
};

struct LootListV2
{
};
#endif
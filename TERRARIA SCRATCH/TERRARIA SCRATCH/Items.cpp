#include "Items.h"
#include "Entity.h"
#include "Player.h"
#include "Chunks.h"
#include <string>
#include <iostream>
DirtBlock::DirtBlock()
{
	itemName = "Dirt Block";
}
void DirtBlock::Use(XMFLOAT2 pos)
{
	using namespace Chunk;
	ChangeBlock(Dirt(),PosToBlockPos(pos));
}
Equipment::Equipment()
{
	stackNumber = 1;
}
void Equipment::Equipped()
{

}
void Equipment::Unequipped()
{

}
Ammunition::Ammunition()
{
	stackNumber = 512;
}

void RangedW::Use()
{
	Shoot();
}
Gel::Gel()
{
	itemName = "Gel";
	cout << itemName << " dropped."<< endl;
}
void Gel::Use()
{
	player.HealMana(1);
}
void Armour::WhenHit()
{

}
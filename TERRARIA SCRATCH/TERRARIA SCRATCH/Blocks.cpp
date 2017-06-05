#include "Constants.h"
#include "Blocks.h"
#include "Entity.h"
// BLOCK 
void Block::Hit(Entity& ent)
{

}
void Block::Break(const BlockPos bPos)
{
	DropLoot(bPos);
}
void Block::DropLoot(const BlockPos bPos)
{

}
void Block::AnyTouched(Entity& ent, XMFLOAT2 blockPos)
{

}
 void Block::TopTouched(Entity& ent, XMFLOAT2 blockPos)
{
	ent.rectangle.pos.y = blockPos.y;
	ent.vel.y = 0;
	ent.movementVelUNCHANGED.y = 0;
}
 void Block::BotTouched(Entity& ent, XMFLOAT2 blockPos)
{
	ent.rectangle.pos.y = blockPos.y + 16;
	if (ent.vel.y < 0){ ent.vel.y *= 0.25f; }
	ent.movementVelUNCHANGED.x *= 0.25f;
}
 void Block::LeftTouched(Entity& ent, XMFLOAT2 blockPos)
{
	ent.rectangle.pos.x = blockPos.x;
	ent.vel.x = 0;
	ent.movementVelUNCHANGED.x = 0;
}
 void Block::RightTouched(Entity& ent, XMFLOAT2 blockPos)
{
	ent.rectangle.pos.x = blockPos.x + 16;
	ent.vel.x = 0;
	ent.movementVelUNCHANGED.x = 0;
}
 bool Block::GetInvulnrability()
 {
	 return invulnrability;
 }
 float Block::GetHP()
 {
	 return hpMAX;
 }
 B_CONSTRUCT_CPP(Dirt, Block, 10){}
 // DIRT
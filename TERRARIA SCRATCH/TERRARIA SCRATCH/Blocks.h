#ifndef BLOCKS_H
#define BLOCKS_H
class Entity;
struct BlockPos;
#include <string>
#include <Windows.h>
#include <DirectXMath.h>
#include <iostream>
// Parent block constructor for HEADERS
#define PB_CONSTRUCT_H(Child, Parent,hpDEFAULT)Child(float hp = hpDEFAULT);
// Parent block constructor (A block that is going to be inherited from. For SOURCE files)
#define PB_CONSTRUCT_CPP(Child, Parent) Child::Child(const float hp) : Parent(hp)
// Block Constructor (The final constructor for SOURCE files)
#define B_CONSTRUCT_CPP(Child, Parent,hp) Child::Child() : Parent(hp)
// Which side an entity collided with a block
enum CollisionSide
{
	cLeft, cRight, cTop, cBot
};
class Block
{
protected:
	bool isSolid;
	const float hpMAX;
	bool invulnrability;
	Block(const float HP=100) :hpMAX(10){}
public:
	Block& operator=(const Block& element);
	virtual void AnyTouched(Entity& ent,XMFLOAT2 blockPos);
	virtual void TopTouched(Entity& ent, XMFLOAT2 blockPos);
	virtual void BotTouched(Entity& ent, XMFLOAT2 blockPos);
	virtual void LeftTouched(Entity& ent, XMFLOAT2 blockPos);
	virtual void RightTouched(Entity& ent, XMFLOAT2 blockPos);
	virtual void Hit(Entity& entity);
	virtual void Break(const BlockPos bPos);
	virtual void DropLoot(const BlockPos bPos);
	virtual bool GetInvulnrability();
	virtual float GetHP();
};
class Dirt: public Block
{
public:
	using Block::Block;
	Dirt();
}; 


#endif
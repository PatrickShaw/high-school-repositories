#include "Entity.h"
#include "Chunks.h"
#include "Buffs.h"
#include "Blocks.h"
#include "Spells.h"
#include "World.h"
#include <vector>
DiggingBlock::DiggingBlock(const BlockPos bPos)
{
	using namespace Chunk;
	blockID = bPos;
	blockPointer = blockList[bPos.x][bPos.y];
	hpNOW = blockPointer->GetHP();
}
BlockPos DiggingBlock::GetBlockID()
{
	return blockID;
}
Entity::Entity()
{
	hostility = entNeutral;
}
	void Entity::Gravity()
{
	if (fallingNOW == true)
	{
		vel.y += World::GetGravityStr();
	}
}
	void Entity::ApplyResistance()
	{
		vel.y *= airResistance;
		vel.x *= airResistance;
	}
	void Entity::Damage(float damage)
	{
		if (invulnerable = true){ return; }
		if (damage < 1){ damage = 1; }
		hpNOW -= damage;
	}
	void Entity::CalculateMovementVelocity()
	{
		movementVel = movementVelUNCHANGED;
		if (fallingNOW = true)
		{
			movementVel.x, movementVel.y *= 0.5f;
		}
	}
	// When collided with block due to velocity
	void Entity::blockCollision()
	 {
		float x1 = rectangle.pos.x / 16.0f;
		float y1 = rectangle.pos.y / 16.0f;
		float x2 = (rectangle.pos.x + vel.x + movementVel.x) / 16.0f;
		float y2 = (rectangle.pos.y + vel.y + movementVel.y) / 16.0f;
		 // Bresenham's line algorithm
		 const bool steep = (fabs(y2 - y1) > fabs(x2 - x1));
		 if (steep)
		 {
			 std::swap(x1, y1);
			 std::swap(x2, y2);
		 }

		 if (x1 > x2)
		 {
			 std::swap(x1, x2);
			 std::swap(y1, y2);
		 }

		 const float dx = x2 - x1;
		 const float dy = fabs(y2 - y1);

		 float error = dx / 2.0f;
		 const int ystep = (y1 < y2) ? 1 : -1;
		 int y = (int)y1;

		 const int maxX = (int)x2;

		 for (int x = (int)x1; x<maxX; x++)
		 {
			 if (steep)
			 {
					 // Chunk::BlockTouched(*this,,x,y);
			 }
			 else
			 {
				 BlockPos bPos(x, y);
				 posNEW = Chunk::BlockPosToPos(bPos);
			 }

			 error -= dy;
			 if (error < 0)
			 {
				 y += ystep;
				 error += dx;
			 }
		 }
	 }
	// Fall damage calculations
	void Entity::Fell()
	{
		if (fallThreshold > abs(vel.y))
		{
			Damage(abs(vel.y));
		}
	}
	void Entity::EntityMovement()
	{
	}
	void Entity::EntilyFunctions()
	 {
		 BuffFunctions();
		Gravity();
		EntityMovement();
		rectangle.pos.x += movementVel.x + vel.x;
		rectangle.pos.y += movementVel.y + vel.y;
		blockCollision();
		if (fallingNOW == false && fallingOLD == true){ Fell(); }
		posOLD = rectangle.pos;
	}
	void Entity::BuffFunctions()
	 {
		 for (int i = 0; i < buffList.size(); i++)
		 {
			 buffList[i]->CheckTimedOut();
			 buffList[i]->Update(*this);
		 }
	 }
	void Entity::ApplyBuff(Buff* buff)
	{
		buffList.push_back(buff);
	}
	void Entity::CleanseBuffs()
	{
		for (int i = 0; i < buffList.size(); i++)
		{
			if (buffList[i]->buffAlignment == buffBad)
			{
				buffList.erase(buffList.begin() + i);
			}
		}
	}
	void Entity::SetFalling(bool IsFalling)
	{
		fallingNOW = IsFalling;
	}
	// TODO
	bool Entity::isBuffPresent(Buff& buff)
	{
		for (unsigned int i = 0; i < buffList.size(); i++)
		{
		}
		return false;
	}
	void Entity::resetCurrentHP(){ hpNOW = hpMAX; }

	void Entity::Jump()
	{

	}
	void Entity::Update()
	{

	}
	void Entity::Kill()
	{

	}
	string Entity::GetEntityName()
	{
		return entityName;
	}

	void Entity::Heal(float HealValue)
	{
		hpNOW += HealValue;
		if (hpNOW > hpMAX)
		{
			hpNOW = hpMAX;
		}
	}
	void Entity::HurtOther(Entity& entity,float damage)
	{
		switch (entity.hostility)
		{
		case entAlly:
			if (hostility == entAlly||hostility == entNeutralAlly){ break; }
			entity.Damage(damage);
			break;
		case entNeutral:
		case entNeutralHostile:
			entity.Damage(damage);
				break;
		case entNeutralAlly:
			if (hostility == entAlly || hostility == entNeutralAlly){ break; }
			entity.Damage(damage);
			break;
		case entHostile:
			if (hostility == entHostile){ break; }
			entity.Damage(damage);
			break;
		}
	}
	void Entity::AddToDigList(const BlockPos bPos)
	{
		using namespace std;
		using namespace Chunk;
		if (blockList[bPos.x][bPos.y]->GetInvulnrability() == true){ return; }
		for (unsigned int i = 0; i < diggingList.size(); i++)
		{
			if (diggingList[i].GetBlockID().x == bPos.x&&diggingList[i].GetBlockID().y == bPos.y)
			{
				return;
			}
		}
		DiggingBlock digTEMP(bPos);
		diggingList.push_back(digTEMP);
	}
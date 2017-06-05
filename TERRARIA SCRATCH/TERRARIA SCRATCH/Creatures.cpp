#include "Creatures.h"
#include "Buffs.h"
#include "Items.h"

void NonPlayer::SetLootList(LootList& LootList)
{
	lootList = &LootList;
}
float Creature::GetSizeDropRate()
{
	switch (size)
	{
	case little:
		return 0.8f;
	case normal:
		return 1.0f;
	case large:
		return 1.2f;
	}
	return 0;
}
void NonPlayer:: Drop(const XMFLOAT2 pos)
{}
NonPlayer::NonPlayer()
{
}
void NonPlayer::Attack(Entity& entity)
{
	
}
Creature::Creature() 
{
	size = normal;
}
Animal::Animal() 
{
	hostility = entNeutral;
}
Monster::Monster()
{
	hostility = entHostile;
}
Slime::Slime()
{
	fuseValue = GetSizeDropRate()*slimeRank;
}

void Slime::PossibleUpgrade(Slime& slime)
{
	switch (slime.slimeRank)
	{
	default:
		return;
	case petty:
		if (slime.absorbedValue >= SLIME_THRESHOLD_NORMAL)
		{
			slime.slimeRank = lesser;
			break;
		}
		return;
	case lesser:
		if (slime.absorbedValue >= SLIME_THRESHOLD_NORMAL)
		{
			slime.slimeRank = normal;
			break;
		}
		return;
	case normal:
		if (slime.absorbedValue >= SLIME_THRESHOLD_GREATER)
		{
			slime.slimeRank = greater;
			break;
		}
		return;
	case greater:
		if (slime.absorbedValue >= SLIME_THRESHOLD_GREATER)
		{
			slime.slimeRank = goliath;
			break;
		}
		return;
	case goliath:
		return;
	}
	slime.absorbedValue = 0;
	slime.RecalculateStats();
}
void Slime::RecalculateStats()
{
	fuseValue = slimeRank * GetSizeDropRate();
	switch (slimeRank)
	{
	default:
		return;
	case petty:
			damageValue = 0;
			hpMAX = 1;
			slimePrefix = SLIME_PREFIX_PETTY;
		break;
	case lesser:
			damageValue = SLIME_DAMAGE_LESSER*GetSizeDropRate();
			hpMAX = SLIME_HP_LESSER*GetSizeDropRate(); 
			slimePrefix = SLIME_PREFIX_LESSER;
			break;
	case normal:
			damageValue = SLIME_DAMAGE_NORMAL*GetSizeDropRate();
			hpMAX = SLIME_HP_NORMAL*GetSizeDropRate();
			slimePrefix = SLIME_PREFIX_NORMAL;
			break;
	case greater:
			damageValue = SLIME_DAMAGE_GREATER*GetSizeDropRate();
			hpMAX = SLIME_HP_GREATER*GetSizeDropRate();
			slimePrefix = SLIME_PREFIX_GREATER;
			break;
	case goliath:
			damageValue = SLIME_DAMAGE_GOLIATH*GetSizeDropRate();
			hpMAX = SLIME_HP_GOLIATH*GetSizeDropRate();
			slimePrefix = SLIME_PREFIX_GOLIATH;
			break;
	}
	entityName = slimePrefix + slimeName;
	resetCurrentHP();
}
void Slime::Fuse(Slime& otherslime)
{
	if (slimeRank > otherslime.slimeRank)
	{
		fuseValue += otherslime.fuseValue + otherslime.absorbedValue;
		Heal(otherslime.hpNOW);
		PossibleUpgrade(*this);
	}
	else
	{
		otherslime.absorbedValue += fuseValue + absorbedValue;
		otherslime.Heal(hpNOW);
		PossibleUpgrade(otherslime);
	}
}
void Slime::Attack(Entity& entity)
{
	if (cooldownNOW >= cooldownMAX)
	{
		entity.HurtOther(entity,damageValue);
	}
	else
	{
		cooldownNOW += 0.1f; // TODO: WORKOUT HOW LONG IT HAS TO TAKE
	}
}
void Slime::EntityCollision(Entity& entity)
{
	if (rectangle.Intersects(entity.rectangle))
	{
		Attack(entity);
	}
}
void Slime::Drop()
{
	new Gel();
}
void Slime::AdditionalAttack(Entity& entity)
{}
void Slime::SetSlimeRank(SlimeRank rank)
{
	slimeRank = rank;
	RecalculateStats();
}
void FireSlime::AdditionalAttack(Entity& entity)
{
	Fire fire(5.0f);
	entity.ApplyBuff(&fire);
}
FireSlime::FireSlime()
{
	slimeRank = petty;
	slimeName = "Fire Slime";
	RecalculateStats();
}
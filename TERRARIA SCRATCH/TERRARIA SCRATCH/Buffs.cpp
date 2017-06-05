#include "Entity.h"
#include "Buffs.h"
Buff::Buff()
{

}
void Buff::CheckTimedOut()
{
	if (durationMAX >= durationNOW){ delete this; }
	else
	{
		durationNOW += 0.1f;//TODO 
	}
}
void Buff::Applied(Entity& entity)
{

}
void Buff::Expired(Entity& entity)
{

}
Debuff::Debuff()
{

}
DOTBuff::DOTBuff(const float Damage)
{
	damage = Damage;
}
	// FIRE
Fire::Fire(const float Damage) :DOTBuff(Damage)
{

}
	void Fire::Update(Entity& entity)
	{
		entity.Damage(damage);
	}
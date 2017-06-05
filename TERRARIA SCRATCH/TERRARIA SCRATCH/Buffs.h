#ifndef BUFFS_H
#define BUFFS_H
// Forward declaration
class Entity;

// BUFFS
#pragma once
enum BuffAlignment
{
	buffGood, buffBad, buffNeutral
};
class Buff
{
protected:
	bool isStackable;
	float durationMAX;
	float durationNOW;
public:
	Buff();
	Buff& operator=(const Buff& element);
	virtual void Applied(Entity& entity);
	virtual void Expired(Entity& entity);
	virtual void Update(Entity& entity) = 0; 
	void CheckTimedOut();
	BuffAlignment buffAlignment;
};
class Debuff :public Buff
{
protected:
	Debuff();
};
class DOTBuff : public Debuff
{
public:
	DOTBuff(const float Damage);
protected:
	float damage;
};
class Fire :public DOTBuff
{
public:
	Fire(const float Damage);
	void Update(Entity& entity);
};

#endif
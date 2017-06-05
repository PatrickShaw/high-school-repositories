#ifndef SPELLS_H
#define SPELLS_H
class Player;
class Spell
{
protected:
	virtual void Cast(Player player) = 0;
	bool twohanded;
	float mpCost;
};
class MissleS :protected Spell
{

};
class ChanneledS :protected Spell
{
protected:
	float channelTime;
};
class Blizzard :protected ChanneledS, protected MissleS
{
	float mpCost = 10;
	void Cast(Player entity);
};
#endif
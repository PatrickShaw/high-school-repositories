#include "Player.h"

void Player::EntityMovement()
{
	if (dead = true){ return; }
}
void Player::Update()
{
}
void Player::Regen()
{
	// HP Regen
	if (hpRgnTmrNOW <= hpRgnTmrMAX){ hpRgnTmrNOW += 1; return; }
}
void Player::CastSpell(Spell& spell)
{

}
void Player::Damage(float damage)
{
	if (invulnerable == true) { return; }
	hpNOW -= damage;
	hpRgnTmrNOW = 0;
	if (hpNOW <= hpMAX)
	{
		Die();
	}
}
void Player::LoadStats()
{

}
void Player::Die(){
	//TODO: Second chance
	dead = true;
}
void Player::HealMana(float value)
{
	mpNOW += value;
}
void Player::pickUpItem()
{
}
void Player::Equip()
{

}
void Player::Unequip()
{

}
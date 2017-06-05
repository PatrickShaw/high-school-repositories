#ifndef WORLD_H
#define WORLD_H
namespace World
{
	static float gravityStr;
	float GetGravityStr()
	{
		return gravityStr;
	}
	void LoadWorldStats()
	{

	}
	// ~~~~~~=== Time ===~~~~~~
	// One second in real life = timeSpeedDefault seconds in game
	// ONE DAY (real life) = 86400 seconds (in real life)
	// 20 minutes (in game) = ONE DAY in real life
	static int timeSpeed;
	static int time; // in seconds
	static int days;
	static bool daytime;
	// Sun rotation in degrees. Rotation is according to unit circle
	static float sunAngle;
	void TimeTick()
	{
		time += timeSpeed;
		if (time > FULL_DAY)
		{
			days += 1;
			time = time - FULL_DAY;
		}
		sunAngle = (360 * (float)time / (float)FULL_DAY) - 90;
	}
	// ~~~~~~=== TODO: LIQUIDS ===~~~~~
	// 1 second = 72 seconds ingame
	// ~~~~~~=== GRAVITY ===~~~~~
	static float gravity;
	void Gravity(XMFLOAT2& velocity, const bool falling)
	{
		if (falling != true){ return; }
		velocity.y -= gravity;
	}
}

#endif
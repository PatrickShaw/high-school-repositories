#include "Shapes.h"

bool Rect::Intersects(const Rect oRect)
{
	if (pos.x < oRect.pos.x + width && pos.x + width > oRect.pos.x &&
		pos.y < oRect.pos.y + height && pos.y + height > oRect.pos.y)
	{
		return true;
	}
	return false;
}
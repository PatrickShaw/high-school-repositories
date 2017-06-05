#ifndef SHAPES_H
#define SHAPES_H

#include "Constants.h"
#include <Windows.h>
#include <DirectXMath.h>
struct Rect
{
	XMFLOAT2 pos;
	float width;
	float height;
	bool Intersects(const Rect oRect);
};
struct BlockPos
{
	BlockPos& operator=(BlockPos element)
    {
		return element;
	}
	BlockPos(){}
	BlockPos(const int X, const int Y)
	{
		x = X;
		y = Y;
	}
	int x;
	int y;
};
#endif
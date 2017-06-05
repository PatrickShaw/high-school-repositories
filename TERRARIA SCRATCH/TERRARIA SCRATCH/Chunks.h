#ifndef CHUNK_H
#define CHUNK_H
#include "Constants.h"
#include "Blocks.h"
#include <vector>
// FORWARD DECLARATION
class Entity;
enum CollisionSide;
struct BlockPos;
namespace Chunk
{
	struct VERTEX{ FLOAT X, Y, Z; D3DXCOLOR Color; };

	// BLOCK HANDLING VARIABLES
	static vector< Block(*)[1024] > blockList;//vector of arrays of 1024 blocks
	static int origin;

	// BLOCK HANDLING FUNCTIONS
	bool ChangeBlock(Block& block,BlockPos bPos);
	BlockPos PosToBlockPos(const XMFLOAT2 pos);
	XMFLOAT2 BlockPosToPos(const BlockPos bPos);
	void BlockTouched(Entity& ent, const CollisionSide side);
	void BreakBlock(const int x, const int y);
}
#endif
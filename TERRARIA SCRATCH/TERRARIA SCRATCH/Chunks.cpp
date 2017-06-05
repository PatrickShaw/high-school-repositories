#include "Chunks.h"
#include "Entity.h"
namespace Chunk
{
	bool ChangeBlock(Block& block, BlockPos bPos)
	{
		return true;
	}
XMFLOAT2 BlockPosToPos(const BlockPos bPos)
{
	return XMFLOAT2((bPos.x - origin) * 16, bPos.y * 16);
}
BlockPos PosToBlockPos(const XMFLOAT2 pos)
{
	using namespace std;
	return BlockPos((int)ceil(pos.x / 16.0f), (int)ceil(pos.y / 16.0f));
}
void InitialiseBlocks()
{
	for (int x = 0; x <= CHUNK_WIDTH*CHUNK_INIT_NO; x++)
	{
		for (int y = 0; y <= CHUNK_HEIGHT; y++)
		{
			if (y > 300)
			{

			}
		}
	}
}

void BlockTouched(Entity& ent, const CollisionSide side,const int x,const int y)
{
	using namespace Chunk;
	blockList[x][y]->AnyTouched(ent, BlockPosToPos(BlockPos(x, y)));
	switch (side)
	{
	case cTop:
		blockList[x][y]->TopTouched(ent, BlockPosToPos(BlockPos(x, y)));
		break;
	case cRight:
		blockList[x][y]->RightTouched(ent, BlockPosToPos(BlockPos(x, y)));
		break;
	case cLeft:
		blockList[x][y]->LeftTouched(ent, BlockPosToPos(BlockPos(x, y)));
		break;
	case cBot:
		blockList[x][y]->BotTouched(ent, BlockPosToPos(BlockPos(x, y)));
		break;
	}
}
void BreakBlock(BlockPos bPos)
{
	using namespace Chunk;
	blockList[bPos.x][bPos.y]->Break(bPos);
} 
VERTEX* FindEdges()
{
	For(int i = 0; i<width)
}
}
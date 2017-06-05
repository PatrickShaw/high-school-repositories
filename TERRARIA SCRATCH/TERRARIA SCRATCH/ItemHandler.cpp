#include "LootList.h"
#include "Items.h"
#include "ItemHandler.h"
namespace ItemHandler
{
	void DropLiveItem(LiveItem& liveItem)
	{
		liveItem.ID = itemList.size();
		itemList.push_back(liveItem);
	}
	void RemoveLiveItem(LiveItem& liveItem)
	{
		itemList.erase(itemList.begin() + liveItem.ID);
	}
}
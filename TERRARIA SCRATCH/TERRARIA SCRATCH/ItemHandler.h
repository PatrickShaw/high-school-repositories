#ifndef ITEMHANDLER_H
#define ITEMHANDLER_H
#include <vector>
struct LiveItem;
namespace ItemHandler
{
	static std::vector<LiveItem> itemList;
	void DropLiveItem(LiveItem& liveItem);
	void RemoveLiveItem(LiveItem& liveItem);
}
#endif
#include "NPCs.h"
class AIEntity :protected Entity
{

};
class Enemy :protected AIEntity
{
};
class Ally :protected AIEntity
{
};
class Neutral :protected AIEntity
{

};
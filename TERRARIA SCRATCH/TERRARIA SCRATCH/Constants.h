#ifndef CONSTANTS_H
#define CONSTANTS_H
// include the basic windows header files and the Direct3D header files
#include <windows.h>
#include <windowsx.h>
#include <d3d11.h>
#include <d3dx11.h>
#include <d3dx10.h>
#include <vector>
#include <math.h>
#include <DirectXMath.h>
using namespace std;

// include the Direct3D Library file
#pragma comment (lib, "d3d11.lib")
#pragma comment (lib, "d3dx11.lib")
#pragma comment (lib, "d3dx10.lib")
using namespace std;
using namespace DirectX;
// CHUNKS
#define CHUNK_WIDTH 512
#define CHUNK_HEIGHT 1024
#define CHUNK_INIT_NO 5
#define BLOCK_SIZE 16
// TIME
#define FULL_DAY 84000
#define TIME_SPEED_DEFAULT	72

// PHYSICS
// Gravity
#define GRAVITY_DEFAULT 9.8F
#endif
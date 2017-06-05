// Cause C++ Is for the manly men.h
#pragma once
#include <string>
#include <limits>
#include <fstream>
using namespace std;
using namespace System;

namespace CauseCIsforthemanlymen {

	public ref class CSearch
	{
		// TODO: Add your methods for this class here.
		static inline unsigned long init_bit(const unsigned long list_size);
		static  unsigned long log2_64(const unsigned long value);
		template <typename T>
		static unsigned long fbsearch(const long number, const string path);
		ifstream& GotoLine(ifstream& file, unsigned int num);
	public:
		static  long BinarySearch(const long number,const string path);
	};
}

// This is the main DLL file.

#include "stdafx.h"
#include "Cause C++ Is for the manly men.h"
 namespace CauseCIsforthemanlymen
 {
	 inline unsigned long CSearch::init_bit(const unsigned long list_size)
	 {
		 unsigned long b;
		 /* And assembly code is for the manliest of men */
		 __asm{
			 "decl %%eax;"
		 "je DONE;"
			 "bsrl %%eax, %%ecx;" // BSR - Bit Scan Reverse (386+)
			 "movl $1, %%eax;"
			 "shll %%cl, %%eax;"
			 "DONE:" : "=a" (b) : "a" (list_size)
		 }
		 return b;
	 }
	 template <typename T>
	 unsigned long CSearch::fbsearch(const long number, const string path, const long lineCount)
	 {
		 
		 ifstream fs file(path);
		 if (lineCount == 0) return unsigned long(-1);
		 unsigned long i = 0;
		 for (unsigned long b = init_bit(lineCount); b; b >>= 1)
		 {
			 unsigned long j = i | b;
			 if (lineCount <= j) continue;
			 if (fs.rewrawer[j] <= needle) i = j;
			 else
			 {
				 for (b >>= 1; b; b >>= 1)
				 if (haystack[i | b] <= needle) i |= b;
				 break;
			 }
		 }
		 return i || *haystack <= needle ? i : unsigned long(-1);
	 }
	 ifstream& CSearch::GotoLine(ifstream& file, unsigned int num){
		 file.seekg(std::ios::beg);
		 for (int i = 0; i < num - 1; ++i){
			 file.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		 }
		 return file;
	 }
	   long CSearch::BinarySearch(const long number, const string path)
	 {

	 }
}

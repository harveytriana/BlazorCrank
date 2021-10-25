#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif
#include <iostream>
#include <chrono>
#include <thread>

using namespace std;

// delegate
typedef void(__stdcall* PFN_PROMPT)(int number);

// implementation
extern "C" {
	E void __stdcall UnmanagedPrompt(PFN_PROMPT fn) {
		// simulation of somethng
		for (int i = 1; i <= 10; i++)
		{
			this_thread::sleep_for(chrono::milliseconds(1000));
			fn(i); // trigger the callback
		}
	};
}

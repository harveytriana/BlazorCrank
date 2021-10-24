#define E __declspec(dllexport)
#include <iostream>
#include <chrono>
#include <thread>

using namespace std;

// delegate
typedef void(__stdcall* PFN_PROMPT)(int number);

// implementation
extern "C" {
	E void __stdcall UnmanagedPrompt(PFN_PROMPT fn) {

		for (int i = 1; i <= 10; i++)
		{
			// by example
			this_thread::sleep_for(chrono::milliseconds(1000));
			fn(i);
		}
	};
}

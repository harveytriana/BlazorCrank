#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif
#include <iostream>
#include <chrono>
#include <thread>

using namespace std;

// event
typedef void(*PromptHandler)(int number);

// implementation
extern "C" {
	E void UnmanagedPrompt(int number, int sleep_ms, PromptHandler notify) {
		// simulation of somethng
		for (int i = 1; i <= number; i++)
		{
			this_thread::sleep_for(chrono::milliseconds(sleep_ms));
			notify(i); // callback
		}
	};
}

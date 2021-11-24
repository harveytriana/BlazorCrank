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
	E void UnmanagedPrompt(PromptHandler notify) {
		// simulation of somethng
		for (int i = 1; i <= 10; i++)
		{
			this_thread::sleep_for(chrono::milliseconds(250));
			notify(i); // callback
		}
	};
}

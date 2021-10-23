#define E __declspec(dllexport)
#include <iostream>

// delegate
typedef void(__stdcall* PFN_PROMPT)(int number);

// implementation
extern "C" {
	E void __stdcall UnmanagedPrompt(PFN_PROMPT fn) {
		// something...
		fn(1234);
	};
}

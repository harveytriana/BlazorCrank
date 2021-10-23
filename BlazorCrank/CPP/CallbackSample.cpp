/*
	CPP/CallbackSample.cpp
*/
#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

#include <iostream>

using namespace std;

// delegate
typedef void(__stdcall* PFN_PROMPT)(int number);

// implementation
extern "C" {
	E void __stdcall UnmanagedPrompt(PFN_PROMPT fn) {
		// debugging...
		cout << "Inside UnmanagedPrompt" << endl;

		// something...
		fn(1234);
	};
}

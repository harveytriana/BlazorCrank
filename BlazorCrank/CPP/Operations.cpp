/*
	Operations.cpp
*/
#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

#include<cmath>
#include<iostream>

struct  Legs
{
	float X;
	float Y;
};

using namespace std;

extern "C" {
	E int add(int a, int b) {
		return a + b;
	}

	E int subtract(int a, int b) {
		return a - b;
	}

	E float hypotenuse(Legs legs) {
		cout << "X: " << legs.X << endl;
		cout << "Y: " << legs.Y << endl;
		return sqrt(pow(legs.X, 2.0) + pow(legs.Y, 2.0));
	}
}
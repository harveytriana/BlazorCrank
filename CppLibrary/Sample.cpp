#define E __declspec(dllexport)
#include<iostream>
#include<cmath>

using namespace std;

struct  Legs
{
	float X;
	float Y;
};

extern "C" {
	E void greeting() {
		cout << "Hello C++" << endl;
	}

	E float hypotenuse(Legs legs) {
		// cout << "X: " << legs.X << endl;
		// cout << "Y: " << legs.Y << endl;
		return (float)sqrt(pow(legs.X, 2.0) + pow(legs.Y, 2.0));
	}

	/*
	Also:
	auto h = std::hypot(x, y);
	x, y, h may have types float, double, ...
	*/
}


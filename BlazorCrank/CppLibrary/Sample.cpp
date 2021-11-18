#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif
#include<cmath>
#include<iostream>

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
        return sqrt(pow(legs.X, 2.0) + pow(legs.Y, 2.0));
    }
}

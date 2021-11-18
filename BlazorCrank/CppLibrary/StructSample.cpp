#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

struct  XY {
	int x, y;
};

// Warning, return a new loacl instance the address of the local instance expiders - time ends with return from the function.
// Then in consumer will received a empty structure
// Scheff's Cat
// Worarround: Solution: Use static, but with the caution that the same memory address is attacked.
// However, since WASM is the final destination, you only have one consumer, and the solution is not that bad.

extern "C" {
	// Approach 1. 
	// A scope variable in the module
	XY _p;

	E XY* scoped_get_xy_ptr() {
		_p.x = 15;
		_p.y = 23;
		return &_p;
	}

	// Approach 2. 
	//The function refers to a static variable
	E  XY* get_xy_ptr() {
		static XY p;
		p.x = 15;
		p.y = 23;
		return &p;
	}

	E int sum_xy(XY p) {
		return p.x + p.y;
	}

	// doesn´t works for wasm emscripten
	//E XY get_xy() {
	//	XY p;
	//	p.x = 15;
	//	p.y = 23;
	//	return p;
	//}
}
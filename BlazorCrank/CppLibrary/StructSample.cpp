#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

struct  XY {
	int x, y;
};

extern "C" {

	E XY get_xy() {
		XY p;
		p.x = 15;
		p.y = 23;
		return p;
	}

	E int sum_xy(XY p) {
		return p.x + p.y;
	}
}
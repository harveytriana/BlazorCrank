#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

class Something
{
public:
	Something(int value) {
		this->value = value;
	}
	int getValue() {
		return this->value;
	}
private:
	int value = 0;
};

extern "C" {
	E void* somethig_new(int value) {
		return new Something(value);
	}
	E void something_delete(void* obj) {
		delete (Something*)obj;
	}
	E int something_get_value(void* obj) {
		return ((Something*)obj)->getValue();
	}
}

// Invoking a C++ method (instance)
// https://www.youtube.com/watch?v=lVWQkpcVEWQ&t=173

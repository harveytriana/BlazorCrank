#ifdef _WIN32
#  define E __declspec( dllexport )
#else
#  define E
#endif

class Animal
{
public:
	Animal(int age) {
		this->age = age;
	}
	int get_age() {
		return this->age;
	}
	void get_older() {
		this->age++;
	}
private:
	int age = 0;
};

extern "C" {
	E void* animal_new(int age) { return new Animal(age); }
	E int	animal_get_age(void* obj) { return ((Animal*)obj)->get_age(); }
	E void	animal_get_older(void* obj) { ((Animal*)obj)->get_older(); }
	E void	animal_dispose(void* obj) { delete (Animal*)obj; }
}

// Inspired in Invoking a C++ method (instance)
// https://www.youtube.com/watch?v=lVWQkpcVEWQ&t=173

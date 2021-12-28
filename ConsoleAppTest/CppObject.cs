/*
 * Some C# interaction experiments with C++ code
 */
using System.Runtime.InteropServices;

class CppObject
{
    public static void Run()
    {
        // OOP. Brick house
        using var cat = new Animal(3);

        cat.GetOlder();

        Console.WriteLine("Cat age: {0}", cat.Age);
    }
}

// PERFECT. Wrap all complexity
class Animal : IDisposable
{
    readonly nint _handle;

    public Animal(int age)
    {
        _handle = animal_new(age);
    }

    public int Age {
        get {
            return animal_get_age(_handle);
        }
    }

    public void GetOlder()
    {
        animal_get_older(_handle);
    }

    public void Dispose()
    {
        animal_dispose(_handle);
    }

    const string CPPLIB = "CppLibrary.dll";

    [DllImport(CPPLIB)] static extern nint animal_new(int age);
    [DllImport(CPPLIB)] static extern int animal_get_age(nint obj);
    [DllImport(CPPLIB)] static extern void animal_get_older(nint obj);
    [DllImport(CPPLIB)] static extern void animal_dispose(nint obj);
}

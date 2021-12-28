/*
 * Some C# interaction experiments with C++ code
 */
using System.Runtime.InteropServices;

class CppMeethodTest
{
    const string CPPLIB = "CppLibrary.dll";

    public static void Run()
    {
        var instance = somethig_new(13);

        var value = something_get_value(instance);

        Console.WriteLine("value: {0}", value);

        something_delete(instance);

        // brick house
        using var something = new Something(19);

        Console.WriteLine("something.Value: {0}", something.Value);

    }

    [DllImport(CPPLIB)] static extern nint somethig_new(int value);
    [DllImport(CPPLIB)] static extern void something_delete(nint obj);
    [DllImport(CPPLIB)] static extern int something_get_value(nint obj);
}


// PERFECT
class Something : IDisposable
{
    readonly nint _handle;

    public Something(int value)
    {
        _handle = somethig_new(value);
    }

    public int Value {
        get {
            return something_get_value(_handle);
        }
    }

    public void Dispose()
    {
        something_delete(_handle); 
    }

    const string CPPLIB = "CppLibrary.dll";

    [DllImport(CPPLIB)] static extern nint somethig_new(int value);
    [DllImport(CPPLIB)] static extern void something_delete(nint obj);
    [DllImport(CPPLIB)] static extern int something_get_value(nint obj);
}

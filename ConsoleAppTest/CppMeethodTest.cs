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

    }

    [DllImport(CPPLIB)] static extern nint somethig_new(int value);
    [DllImport(CPPLIB)] static extern void something_delete(nint obj);
    [DllImport(CPPLIB)] static extern int something_get_value(nint obj);
}


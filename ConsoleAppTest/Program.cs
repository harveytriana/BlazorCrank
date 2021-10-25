/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

Console.WriteLine("C++ Calls Demostration");
Console.WriteLine("----------------------");

new CallingCpp().ExecuteSamples();

Console.WriteLine("Pause");
Console.ReadKey();

class CallingCpp
{
    const string CPPLIB = "CppLibrary.dll";

    struct Legs
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    [DllImport(CPPLIB)]
    static extern void greeting();

    [DllImport(CPPLIB)]
    static extern float hypotenuse(Legs legs);

    // callback
    public delegate void CppCallback(int number);
    [DllImport(CPPLIB)]
    static extern void UnmanagedPrompt(CppCallback cppCallback);

    public void ExecuteSamples()
    {
        Console.WriteLine("Basic test:");
        greeting();

        Console.WriteLine("\nFunction test passing a structure as parameter:");
        var legs = new Legs { X = 9, Y = 11 };
        var h = hypotenuse(legs);
        Console.WriteLine("From C++: Hypotenuse({0}, {1}) = {2}\n", legs.X, legs.Y, h);

        // callback
        Console.WriteLine("Callback from C++");
        UnmanagedPrompt(HandlePrompt);
    }

    private void HandlePrompt(int number)
    {
        Console.WriteLine("Called back by unmanaged side. Number: {0}", number);
    }
}
/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

Console.WriteLine("C++ Calls Demostration");
Console.WriteLine("----------------------");

// new CppSamples().ExecuteSamples1();
new CppSamples().ExecuteSamples2();


Console.WriteLine("Pause");
Console.ReadKey();

class CppSamples
{
    const string CPPLIB = "CppLibrary.dll";

    record struct Legs(float X, float Y);
    // OR...
    //struct Legs
    //{
    //    public float X { get; set; }
    //    public float Y { get; set; }
    //}

    [DllImport(CPPLIB)] static extern void greeting();
    [DllImport(CPPLIB)] static extern float hypotenuse(Legs legs);

    // callback
    public delegate void CppCallback(int number);
    //
    [DllImport(CPPLIB)] static extern void UnmanagedPrompt(CppCallback cppCallback);

    //record struct XY(int x, int y);
    // OR...
    struct XY
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    [DllImport(CPPLIB)] static extern XY get_xy();
    [DllImport(CPPLIB)] static extern int sum_xy(XY p);
    // POINTER
    [DllImport(CPPLIB)] static extern XY get_xy_ptr();

    public void ExecuteSamples1()
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

    public void ExecuteSamples2()
    {
        var xy = get_xy();
        var sum = sum_xy(xy);

        Console.WriteLine(string.Format("x: {0} y: {1}, Sum: {2}", xy.x, xy.y, sum));

        Console.WriteLine("\nPointers Approach");

        // Pointers for emscripten
        var xy_ptr = get_xy_ptr();
        Console.WriteLine("xy_ptr   : {0}", xy_ptr);
        Console.WriteLine("xy_ptr.x : {0}", xy_ptr.x);
        Console.WriteLine("xy_ptr.y : {0}", xy_ptr.y);

    }
}
/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

class CppSamples
{
    const string CPPLIB = "CppLibrary.dll";

    record struct Legs(float X, float Y);

    [DllImport(CPPLIB)] static extern void greeting();
    [DllImport(CPPLIB)] static extern float hypotenuse(Legs legs);

    // callback
    public delegate void CppCallback(int number);
    //
    [DllImport(CPPLIB)] static extern void UnmanagedPrompt(CppCallback cppCallback);

    record struct XY(int x, int y);
    // OR...
    //struct XY
    //{
    //    public int x;
    //    public int y;
    //}
   
    [DllImport(CPPLIB)] static extern XY get_xy();
    [DllImport(CPPLIB)] static extern int sum_xy(XY p);
    // POINTER
    //[return: MarshalAs(UnmanagedType.LPStruct)]
    [DllImport(CPPLIB)] static extern IntPtr get_xy_ptr();

    public void Run()
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

        var xy = get_xy();
        var sum = sum_xy(xy);

        Console.WriteLine("\nGetting a C++'s struct");
        Console.WriteLine(string.Format("x: {0} y: {1}, Sum: {2}", xy.x, xy.y, sum));
    }

    private void HandlePrompt(int number)
    {
        Console.WriteLine("Called back by unmanaged side. Number: {0}", number);
    }

}
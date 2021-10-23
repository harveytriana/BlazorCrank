
using System.Runtime.InteropServices;

Console.WriteLine("C++ Calls");

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

    #region Try Delegates
    public delegate void CppCallback(int number);
    [DllImport(CPPLIB)]
    static extern void UnmanagedPrompt(CppCallback cppCallback);
    #endregion

    public void ExecuteSamples()
    {
        greeting();

        var legs = new Legs { X = 9, Y = 11 };
        var h = hypotenuse(legs);
        Console.WriteLine("\nHypotenuse({0}, {1}) = {2}\n", legs.X, legs.Y, h);

        // events
        UnmanagedPrompt(HandlePrompt);
    }

    private void HandlePrompt(int number)
    {
        Console.WriteLine("Called back by unmanaged side. Number: {0}", number);
    }
}
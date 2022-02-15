using System.Runtime.InteropServices;

namespace SampleServer;

public class NativeFunctions
{
    // event
    public delegate void RaiseNumber(int number);

    string _name = string.Empty;

    public string RunProcess(string name, int number)
    {
        Console.WriteLine("Running C++: UnmanagedPrompt({0})", number);
        _name = name;

        // call a C++ method
        UnmanagedPrompt(number, 250, OnRaiseNumber);

        return "Done";
    }

    private void OnRaiseNumber(int number)
    {
        Console.WriteLine($"Arrives extern number for {_name}: {number}");
    }

    public float GetHypotenuse(float x, float y)
    {
        return hypotenuse(new Legs(x, y));
    }


    // extern -----------------------------------------------------
    const string CPPLIB = "CppLibrary.dll";

    [DllImport(CPPLIB)] static extern void UnmanagedPrompt(int number, int sleep_ms, RaiseNumber cppCallback);
    [DllImport(CPPLIB)] static extern float hypotenuse(Legs legs);

    // struct as parameter
    record struct Legs(float X, float Y);
}


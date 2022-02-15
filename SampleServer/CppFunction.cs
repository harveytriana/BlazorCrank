using System.Runtime.InteropServices;

namespace SampleServer;

public class CppFunction
{
    public float GetHypotenuse(float x, float y)
    {
        return hypotenuse(new Legs(x, y));
    }

    // extern -----------------------------------------------------
    [DllImport("CppLibrary.dll")] static extern float hypotenuse(Legs legs);

    // struct as parameter
    record struct Legs(float X, float Y);
}


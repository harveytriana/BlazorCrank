/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

class ECallbackSample
{
    // event
    public delegate void RaiseNumber(int number);
    
    public void Run()
    {
        Console.WriteLine("\nRunning C++");

        // call a C++ method
        UnmanagedPrompt(OnRaiseNumber);
    }

    private void OnRaiseNumber(int number)
    {
        Console.WriteLine($"Arrives extern number: {number}");
    }

    // extern -----------------------------------------------------
    const string CLIB = "CppLibrary.dll";

    [DllImport(CLIB)] static extern void UnmanagedPrompt(RaiseNumber cppCallback);
}
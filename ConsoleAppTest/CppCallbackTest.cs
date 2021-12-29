/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

class CppCallbackTest
{
    // event
    public delegate void RaiseNumber(int number);

    public void Run()
    {
        Console.WriteLine("\nRunning C++");

        // call a C++ method
        UnmanagedPrompt(12, 250, OnRaiseNumber);
    }

    private void OnRaiseNumber(int number)
    {
        Console.WriteLine($"Arrives extern number: {number}");
    }

    // extern -----------------------------------------------------
    const string CLIB = "CppLibrary.dll";

    [DllImport(CLIB)] static extern void UnmanagedPrompt(int number, int sleep_ms, RaiseNumber cppCallback);
}
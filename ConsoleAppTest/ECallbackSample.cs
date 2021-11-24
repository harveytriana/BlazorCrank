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
        Console.WriteLine("\nRunning Sample C++");

        // call a C++ method
        UnmanagedPrompt(OnRaiseNumber);
    }

    private void OnRaiseNumber(int number)
    {
        Console.WriteLine($"arrives extern number: {number}");
    }

    // extern -----------------------------------------------------
    const string ELIB = "CppLibrary.dll";

    [DllImport(ELIB)] static extern void UnmanagedPrompt(RaiseNumber cppCallback);

}
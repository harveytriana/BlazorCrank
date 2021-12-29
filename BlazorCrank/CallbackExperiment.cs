using System.Runtime.InteropServices;

namespace BlazorCrank;

public unsafe class CallbackExperiment
{
    // echo to consumer
    public delegate Task EchoHandler(string? message);
    public static EchoHandler? Echo;

    static readonly delegate* unmanaged<int, void> OnRaiseNumberPointer = &OnRaiseNumber;

    public static void Run(int number, int sleep_ms)
    {
        Console.WriteLine("\nRunning C++");

        // call a C++ method
        UnmanagedPrompt(number, sleep_ms, (IntPtr)OnRaiseNumberPointer);
    }

    [UnmanagedCallersOnly]
    private static void OnRaiseNumber(int number)
    {
        Echo?.Invoke($"Arrives external number: {number}");
    }

    // extern ---------------------------------------------------------------
    const string CLIB = "CallbackSample";

    [DllImport(CLIB)] static extern void UnmanagedPrompt(int number, int sleep_ms, IntPtr notify);
    // theory
    // [DllImport(CLIB)] static extern void UnmanagedPrompt(delegate *unmanaged<int,void> cppCallback);
}


﻿using System.Runtime.InteropServices;

namespace BlazorCrank;

public unsafe class CallbackExperiment
{
    // echo to consumer
    public delegate Task EchoHandler(string? message);
    public static EchoHandler? Echo;

    static readonly delegate* unmanaged<int, void> OnRaiseNumberPointer = &OnRaiseNumber;

    public static void Run()
    {
        Console.WriteLine("\nRunning C++");

        // call a C++ method
        UnmanagedPrompt((IntPtr)OnRaiseNumberPointer);
    }

    [UnmanagedCallersOnly]
    private static void OnRaiseNumber(int number)
    {
        Echo?.Invoke($"Arrives external number: {number}");
    }

    // extern ---------------------------------------------------------------
    const string CLIB = "CallbackSample";

    [DllImport(CLIB)] static extern void UnmanagedPrompt(IntPtr cppCallback);
    // theory
    // [DllImport(CLIB)] static extern void UnmanagedPrompt(delegate *unmanaged<int,void> cppCallback);
}


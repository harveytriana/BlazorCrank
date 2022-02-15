#nullable disable

using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SampleServer.Hubs;
using System.Runtime.InteropServices;

namespace SampleServer;

public class CppCallback
{
    // event
    public delegate void RaiseNumber(int number);

    string _name = string.Empty;

    // SignalR
    readonly IHubContext<Transmitter> _hubContext;

    public CppCallback(IHubContext<Transmitter> hubContext)
    {
         _hubContext = hubContext;
    }

    public string RunProcess(string name, int number)
    {
        Console.WriteLine("Running C++: UnmanagedPrompt({0})", number);
        _name = name;

        // call a C++ method
        UnmanagedPrompt(number, 250, OnRaiseNumber);

        return "Done";
    }

    async void OnRaiseNumber(int number)
    {
        Console.WriteLine($"Arrives extern number for {_name}: {number}");

        await _hubContext.Clients.All.SendAsync("Broadcast", _name, number);
    }

    // extern -----------------------------------------------------
    [DllImport("CppLibrary.dll")] static extern void UnmanagedPrompt(int number, int sleep_ms, RaiseNumber cppCallback);
}


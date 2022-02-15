using Microsoft.AspNetCore.SignalR;

namespace SampleServer.Hubs;

public class Transmitter : Hub
{
    public Task Broadcast(string name, int number)
    {
        return Clients.Others.SendAsync("Broadcast", name, number);
    }
}


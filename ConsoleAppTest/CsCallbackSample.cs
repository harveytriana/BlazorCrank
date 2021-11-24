namespace ConsoleAppTest;

class CsCallbackSample
{
    // event
    public delegate void RaiseNumber(int number);

    public static async Task Run()
    {
        Console.WriteLine("\nRunning Sample C#");
        
        // call extern method (by simulate exists here)
        await UnmanagedPrompt(OnRaiseNumber);
    }

    static void OnRaiseNumber(int number)
    {
        Console.WriteLine($"arrives extern number: {number}");
    }

    // extern -----------------------------------------------------
    public static async Task UnmanagedPrompt(RaiseNumber notify)
    {
        for (int i = 1; i <= 10; i++) {
            await Task.Delay(250);
            notify.Invoke(i);
        }
    }
}

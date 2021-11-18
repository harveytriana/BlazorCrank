using System.Runtime.InteropServices;

namespace BlazorCrank
{
    public unsafe class CallbackExperiment
    {
        // Echo to consumer
        public delegate Task EchoHandler(string? message);
        public static EchoHandler? Echo;

        static readonly delegate* unmanaged<int, void> _handlePromptPointer = &HandlePrompt;

        [DllImport("CallbackSample")] static extern void UnmanagedPrompt(IntPtr cppCallback);

        public static void ExecutePrompts()
        {
            UnmanagedPrompt((IntPtr)_handlePromptPointer);
        }

        [UnmanagedCallersOnly]
        private static void HandlePrompt(int number)
        {
            Echo?.Invoke($"Called back by unmanaged side. Number: {number}");
        }
    }
}

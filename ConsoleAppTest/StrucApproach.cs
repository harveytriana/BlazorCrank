/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */
using System.Runtime.InteropServices;

class CppStructFromPointer
{
    const string CPPLIB = "CppLibrary.dll";

    record struct XY(int x, int y);
    // OR...
    //struct XY
    //{
    //    public int x;
    //    public int y;
    //}

    // POINTER
    [DllImport(CPPLIB)] static extern IntPtr get_xy_ptr();

    // MarshalDirectiveException: Cannot marshal 'return value': Invalid managed/unmanaged type combination (this value type must be paired with Struct).
    //[return: MarshalAs(UnmanagedType.LPStruct)]
    //[DllImport(CPPLIB)] static extern XY get_xy();

    public static void Run()
    {
        // Pointers for emscripten
        IntPtr pointer = get_xy_ptr();

        XY xy = Marshal.PtrToStructure<XY>(pointer);

        Console.WriteLine("xy_ptr.x : {0}", xy.x);
        Console.WriteLine("xy_ptr.y : {0}", xy.y);

        //XY z = get_xy();
        //Console.WriteLine("z : {0}", z);
    }
}
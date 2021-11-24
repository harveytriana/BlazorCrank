/*
 * Some C# interaction experiments with C++ code
 * By: harveytriana@gmail.com
 */

using ConsoleAppTest;

Console.WriteLine("C++ Calls Demostration");
Console.WriteLine("----------------------");

// new CppSamples().Run();
// CppStructFromPointer.Run();

new ECallbackSample().Run();

CsCallbackSample.Run().Wait();

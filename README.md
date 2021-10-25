## Native dependencies support for Blazor WebAssembly - Issue when try use a callback from C++

Excellent and amazing progress in Blazor. This project is intended to illustrate some experience of this new feature. Also, the purpose is to show that there is an issue when using a C++ callback. The following exception occurs.
 
```
Assertion at /__w/1/s/src/mono/mono/metadata/loader.c:1806, condition '<disabled>' not met
```
To get into context, I have first written the mirror with a C# net6 console and a C++ library. 
 
The same modules from this C ++ library are then taken to a Blazor WASM project.
 
You can run the ```ConsoleAppTest``` console project to get this result:

![Console Test](https://github.com/harveytriana/BlazorCrank/blob/master/Images/cs-cpp-console.gif)
 
When run in Blazor project then following images show the result.

Basic sample:

[]()

Callback issue:

I estimate that there are no errors in the code, maybe the behavior should be corrected


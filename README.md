## Native dependencies support for Blazor WebAssembly - Issue when try use a callback from C++

Excellent and amazing progress in Blazor. This project is intended to illustrate some experience with this new feature. Also, the purpose is to show that there is an issue when using a C++ callback.

To get into context, I have first written the experiment with a C# net6 console and a C++ library (attached projects here). 
 
The same code from this C++ library is then copied into a Blazor WASM project, in folder CppLibrary and referenced in project file as native reference.
 
You can run the ```ConsoleAppTest``` console project to get this result:

![Console Test](https://github.com/harveytriana/BlazorCrank/blob/master/Images/cs-cpp-console.gif)
 
When run in Blazor project then following images show the result.

Basic sample:

![Basic Sample](https://github.com/harveytriana/BlazorCrank/blob/master/Images/bz-cpp-1.png)

--

P.S. The name BlazorCrank is irrelevant

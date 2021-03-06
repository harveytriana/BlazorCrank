## Native dependencies support for Blazor WebAssembly - Report when try use a callback from C++

Excellent and amazing progress in Blazor. This project is intended to illustrate some experience with this new feature. Also, the purpose is to show that there is an issue when using a C++ callback.

To get into context, I have first written the experiment with a C# net6 console and a C++ library (attached projects here). 
 
The same code from this C++ library is then copied into a Blazor WASM project, in folder CppLibrary and referenced in project file as native reference.
 
You can run the ```ConsoleAppTest``` console project to get this result:

![Console Test](https://github.com/harveytriana/BlazorCrank/blob/master/Images/cs-cpp-console.gif)
 
When run in Blazor project then following images show the result.

### Running Functions

![Basic Sample](https://github.com/harveytriana/BlazorCrank/blob/master/Images/bz-cpp-1.png)

### Running Callbacks

In first instance, I tried use equivalent code on console application. When try to run the code with callback, an exception occurs.

```
Assertion at /__w/1/s/src/mono/mono/metadata/loader.c:1806, condition '<disabled>' not met
```

Then I put a «Issue» to MS Team: https://github.com/dotnet/runtime/issues/60824. 

In the current publish, I rearranged the code a bit in reference to Aleksey Kliger's answer, which requires the use of explicit pointers (unsafe in C#). The result is that we can execute the callback, receive the result of the function, but not update the UI on the page, which happens at the end of the process.

![Callback Page](https://github.com/harveytriana/BlazorCrank/blob/master/Images/bz-cpp-3.png)

Moore information »» [Document how to setup callbacks for native dependencies in Blazor WebAssembly](https://github.com/dotnet/AspNetCore.Docs/issues/23661)

To be continue.


--

P.S. The name BlazorCrank is irrelevant

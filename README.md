## Using C++ With Blazor WebAssembly

Many people may not know that from a Blazor WA project we can use functions written in C and C++. It's all part of the Blazor feature that allows you to use native dependencies. You can find the basic description here https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-native-dependencies. In the present repository I show more complex examples to the basic documentation. We can also do the same with Rust, but the Rust code must be previously compiled to WA.

But why would we want to do this? We may have code in C or some library that we want to use in our Blazor WA application. A commendable case is Skia Sharp. I'm currently using Blazor and SkiaSharp in the software I write for engineering, at the production level.

This project illustrate experience with native dependencies support for Blazor WebAssembly, in this case C++. Also, the purpose is to show that there is an issue when using a C++ callback.

![Console Test](https://github.com/harveytriana/BlazorCrank/blob/master/Images/cs-cpp-index.png)

**Demonstrations**

- Casic Sample
- Struct Sample
- Class Sample
- Callback in Browser
- Callback from Server

To get into context, I have first written the experiment with a C# console and a C++ library (attached projects here). 
 
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

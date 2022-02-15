using Microsoft.AspNetCore.ResponseCompression;
using SampleServer;
using SampleServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------ container services ----------------------------------
// COORS
string _CorsPolicy = "CorsPolicy";
string[] origins = builder.Configuration.GetSection("AllowOrigins").Get<string[]>();

builder.Services.AddCors(_ => _.AddPolicy(_CorsPolicy,
        builder =>
        builder.WithOrigins(origins)
               .AllowAnyHeader()
               .AllowAnyMethod()
       )
);

// SignalR
builder.Services.AddSignalR();
// signalr requirement
builder.Services.AddResponseCompression(_ => {
    _.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

// app
builder.Services.AddScoped<CppCallback>();

// ------------------------------------ middleware ----------------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(_CorsPolicy);
app.UseHttpsRedirection();

var fn = new CppFunction();
//var cb = new CppCallback();

app.MapGet("/", () => "Hello Server");

app.MapGet("/GetHypotenuse/{x}/{y}", (float x, float y) => fn.GetHypotenuse(x, y));

app.MapGet("/RunProcess/{name}/{number}", (CppCallback cb,string name, int number) => cb.RunProcess(name, number));

app.MapHub<Transmitter>("/Transmitter");

app.Run();


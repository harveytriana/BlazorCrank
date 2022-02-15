using SampleServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string _CorsPolicy = "CorsPolicy";

// CORS with named policy and middleware
builder.Services.AddCors(options => {
    options.AddPolicy(name: _CorsPolicy,
        builder => {
            // see launchSettings.json of BlazorCrank
            builder.WithOrigins("https://localhost:7104", "http://localhost:5104");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(_CorsPolicy);
app.UseHttpsRedirection();

var fn = new NativeFunctions();

app.MapGet("/", () => "Hello Server");

app.MapGet("/GetHypotenuse/{x}/{y}", (float x, float y) => fn.GetHypotenuse(x, y));

app.MapGet("/RunProcess/{name}/{number}", (string name, int number) => fn.RunProcess(name, number));

app.Run();


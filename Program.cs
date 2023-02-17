using dependence_injection_example;

var builder = WebApplication.CreateBuilder(args);

//dependence injection

builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

//add for swagger
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();//add for swagger
builder.Services.AddSwaggerGen();//add for swagger

var app = builder.Build();

//swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY API");
});


app.MapGet("/transient", (ITransientService transient1, ITransientService transient2) =>
{
    var values = new { value1 = transient1.Id, value2 = transient2.Id };

    return Results.Ok(values);
});

app.MapGet("/scoped", (IScopedService scoped1, IScopedService scoped2) =>
{
    var values = new { value1 = scoped1.Id, value2 = scoped2.Id };

    return Results.Ok(values);
});

app.MapGet("/singleton", (ISingletonService singleton1, ISingletonService singleton2) =>
{
    var values = new { value1 = singleton1.Id, value2 = singleton2.Id };

    return Results.Ok(values);
});
app.Run();

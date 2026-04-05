var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient(); // IMPORTANT

var app = builder.Build();
app.MapControllers();
app.Run();

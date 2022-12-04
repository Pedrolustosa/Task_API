using Task_API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddPersistence();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
//app.MapTaskEndPoints();
app.Run();

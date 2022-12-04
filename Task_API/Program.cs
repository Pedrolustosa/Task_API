using Task_API.Endpoints;
using Task_API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddPersistence();

var app = builder.Build();
app.MapTaskEndPoints();
app.Run();

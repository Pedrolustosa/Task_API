using Task_API.Data;
using Dapper.Contrib.Extensions;
using static Task_API.Data.TaskContext;

namespace Task_API.Endpoints
{
    public static class TaskEndPoints
    {
        public static void MapTaskEndPoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Welcome Task API - {DateTime.Now}");

            app.MapGet("/tasks", async(GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tasks = con.GetAll<Tasks>().ToList();

                if (!tasks.Any())
                    return Results.NotFound();

                return Results.Ok(tasks);
            });
        }
    }
}

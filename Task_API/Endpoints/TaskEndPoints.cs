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

            app.MapGet("/task{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                return con.Get<Tasks>(id) is Tasks tasks ? Results.Ok(tasks) : Results.NotFound();
            });

            app.MapPost("/tasks", async (GetConnection connectionPost, Tasks tasks) =>
            {
                using var con = await connectionPost();
                var id = con.Insert(tasks);
                return Results.Created($"/tasks/{id}", tasks);
            });

            app.MapPut("/tasks", async (GetConnection connectionPut, Tasks tasks) =>
            {
                using var con = await connectionPut();
                var id = con.Update(tasks);
                return Results.NoContent();
            });

            app.MapDelete("/task/{id}", async (GetConnection connectionDelete, int id) =>
            {
                using var con = await connectionDelete();
                var taskDeleted = con.Get<Tasks>(id);

                if (taskDeleted is null)
                    Results.NotFound();

                con.Delete(taskDeleted);
                return Results.Ok($"Task of the id:{ taskDeleted?.Id } was deleted");
            });
        }
    }
}

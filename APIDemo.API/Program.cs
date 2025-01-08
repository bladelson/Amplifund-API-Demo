using APIDemo.API.DTO;
using APIDemo.Database;
using APIDemo.Database.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<APIDemoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetRequiredSection("DatabaseConnection").Value, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
});

var app = builder.Build();

//apply migration on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<APIDemoContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/health", () =>
{
    return Results.Ok("alive");
})
.WithOpenApi(o => new(o) { Summary = "Health" });

app.MapGet("/todo", async Task<Ok<List<TodoItem>>> (APIDemoContext db, int limit = 100) =>
{
    var todos = await db.TodoItems
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Created)
                .Take(limit)
                .ToListAsync();

    return TypedResults.Ok(todos);
})
.WithOpenApi(o => new(o) { Summary = "Get All Todo Items" });

app.MapGet("/todo/{id}", async Task<Results<NotFound<Error>, Ok<TodoItem>>> (APIDemoContext db, int id) =>
{
    var todo = await db.TodoItems.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
    if (todo == null)
        return TypedResults.NotFound(new Error($"Todo Item with id {id} not found."));

    return TypedResults.Ok(todo);
})
.WithOpenApi(o => new(o) { Summary = "Get Todo Item by id" });

app.MapPut("/todo/{id}", async Task<Results<NotFound<Error>, BadRequest<Error>, Ok<TodoItem>>> (APIDemoContext db, int id, NewTodoItem todo) =>
{
    if (!todo.IsValid())
        return TypedResults.BadRequest(new Error("Invalid Title or Description"));

    var dbTodo = await db.TodoItems.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
    if (dbTodo == null)
        return TypedResults.NotFound(new Error($"Todo Item with id {id} not found."));

    dbTodo.Title = todo.Title;
    dbTodo.Description = todo.Description;
    dbTodo.Modified = DateTimeOffset.UtcNow;
    await db.SaveChangesAsync();

    return TypedResults.Ok(dbTodo);
})
.WithOpenApi(o => new(o) { Summary = "Update Todo Item by id" }); ;

app.MapPost("/todo", async Task<Results<Ok<TodoItem>, BadRequest<Error>>> (APIDemoContext db, NewTodoItem todo) =>
{
    if (!todo.IsValid())
        return TypedResults.BadRequest(new Error("Invalid Title or Description"));

    var newTodo = new TodoItem()
    {
        Title = todo.Title,
        Description = todo.Description
    };
    db.TodoItems.Add(newTodo);
    await db.SaveChangesAsync();

    return TypedResults.Ok(newTodo);
})
.WithOpenApi(o => new(o) { Summary = "Create New Todo Item" });

app.MapDelete("/todo/{id}", async Task<Results<Ok, NotFound<Error>>> (APIDemoContext db, int id) =>
{
    var dbTodo = await db.TodoItems.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
    if (dbTodo == null)
        return TypedResults.NotFound(new Error($"Todo Item with id {id} not found."));

    dbTodo.Deleted = true;
    dbTodo.Modified = DateTimeOffset.UtcNow;
    await db.SaveChangesAsync();

    return TypedResults.Ok();
})
.WithOpenApi(o => new(o) { Summary = "Delete Todo Item by id" });

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }
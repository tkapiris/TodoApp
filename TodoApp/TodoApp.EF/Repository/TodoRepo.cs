using Microsoft.EntityFrameworkCore;

using TodoApp.EF.Context;
using TodoApp.Model;

namespace TodoApp.EF.Repository;

public class TodoRepo : IEntityRepo<Todo>
{
    /// <inheritdoc />
    public IEnumerable<Todo> GetAll()
    {
        using var context = new TodoContext();
        return context.Todos.Include(todo => todo.Detail).ToList();
    }

    /// <inheritdoc />
    public Todo? GetById(int id)
    {
        using var context = new TodoContext();
        return context.Todos.Include(todo => todo.Detail).SingleOrDefault(todo => todo.Id == id);
    }

    /// <inheritdoc />
    public void Add(Todo entity)
    {
        using var context = new TodoContext();

        if (entity.Id != 0)
            throw new ArgumentException("Given entity should not have Id set", nameof(entity));

        context.Todos.Add(entity);
        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Update(int id, Todo entity)
    {
        using var context = new TodoContext();

        var dbTodo = context.Todos.Include(todo => todo.Detail).SingleOrDefault(todo => todo.Id == id);
        if (dbTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        dbTodo.Title = entity.Title;
        dbTodo.Finished = entity.Finished;

        if (entity.Finished) entity.Detail.FinishDate = DateTime.Now;

        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        using var context = new TodoContext();

        var dbTodo = context.Todos.SingleOrDefault(todo => todo.Id == id);
        if (dbTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        context.Todos.Remove(dbTodo);
        context.SaveChanges();
    }
}
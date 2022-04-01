using Microsoft.EntityFrameworkCore;

using TodoApp.EF.Context;
using TodoApp.Model;

namespace TodoApp.EF.Repository;

public class TodoRepo : IEntityRepo<Todo>
{
    private readonly TodoContext context;

    public TodoRepo(TodoContext dbContext)
    {
        context = dbContext;
    }

    /// <inheritdoc />
    public IEnumerable<Todo> GetAll()
    {
        // using var context = new TodoContext();
        return context.Todos.Include(todo => todo.Detail).ToList();
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        // await using var context = new TodoContext();
        return await context.Todos.Include(todo => todo.Detail).ToListAsync();
    }

    /// <inheritdoc />
    public Todo? GetById(int id)
    {
        // using var context = new TodoContext();
        return context.Todos.Include(todo => todo.Detail).SingleOrDefault(todo => todo.Id == id);
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        // await using var context = new TodoContext();
        return await context.Todos.Include(todo => todo.Detail).SingleOrDefaultAsync(todo => todo.Id == id);
    }

    /// <inheritdoc />
    public void Add(Todo entity)
    {
        // using var context = new TodoContext();
        AddLogic(entity, context);
        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Update(int id, Todo entity)
    {
        // using var context = new TodoContext();
        UpdateLogic(id, entity, context);
        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        // using var context = new TodoContext();
        DeleteLogic(id, context);
        context.SaveChanges();
    }

    public async Task AddAsync(Todo entity)
    {
        // await using var context = new TodoContext();
        AddLogic(entity, context);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Todo entity)
    {
        // await using var context = new TodoContext();
        UpdateLogic(id, entity, context);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        // await using var context = new TodoContext();
        DeleteLogic(id, context);
        await context.SaveChangesAsync();
    }

    private void DeleteLogic(int id, TodoContext context)
    {
        var dbTodo = context.Todos.SingleOrDefault(todo => todo.Id == id);
        if (dbTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        context.Todos.Remove(dbTodo);
    }

    private void UpdateLogic(int id, Todo entity, TodoContext context)
    {
        var dbTodo = context.Todos.Include(todo => todo.Detail).SingleOrDefault(todo => todo.Id == id);
        if (dbTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        dbTodo.Title = entity.Title;
        dbTodo.Finished = entity.Finished;

        if (entity.Finished) entity.Detail.FinishDate = DateTime.Now;
    }

    private void AddLogic(Todo entity, TodoContext context)
    {
        if (entity.Id != 0)
            throw new ArgumentException("Given entity should not have Id set", nameof(entity));

        context.Todos.Add(entity);
    }
}
using TodoApp.EF.Context;
using TodoApp.Model;

namespace TodoApp.EF.Repository;

public class TodoCommentRepo : IEntityRepo<TodoComment>, ITodoCommentRepo
{
    /// <inheritdoc />
    public IEnumerable<TodoComment> GetAll()
    {
        using var context = new TodoContext();
        return context.TodoComments.ToList();
    }

    /// <inheritdoc />
    public TodoComment? GetById(int id)
    {
        using var context = new TodoContext();
        return context.TodoComments.SingleOrDefault(todoComment => todoComment.Id == id);
    }

    /// <inheritdoc />
    public void Add(TodoComment entity)
    {
        using var context = new TodoContext();

        if (entity.Id != 0)
            throw new ArgumentException("Given entity should not have Id set", nameof(entity));

        context.TodoComments.Add(entity);
        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Update(int id, TodoComment entity)
    {
        using var context = new TodoContext();

        var dbTodoComment = context.TodoComments.SingleOrDefault(todoComment => todoComment.Id == id);
        if (dbTodoComment is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        dbTodoComment.Text = entity.Text;
        context.SaveChanges();
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        using var context = new TodoContext();

        var dbTodoComment = context.TodoComments.SingleOrDefault(todoComment => todoComment.Id == id);
        if (dbTodoComment is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found in database");

        context.TodoComments.Remove(dbTodoComment);
        context.SaveChanges();
    }

    /// <inheritdoc />
    public IEnumerable<TodoComment> GetAllForTodo(int todoId)
    {
        using var context = new TodoContext();
        return context.TodoComments.Where(todoComment => todoComment.TodoId == todoId).ToList();
    }

    public Task<IEnumerable<TodoComment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TodoComment?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TodoComment entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, TodoComment entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
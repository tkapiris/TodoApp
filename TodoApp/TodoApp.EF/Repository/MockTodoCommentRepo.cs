using TodoApp.Model;

namespace TodoApp.EF.Repository;

public class MockTodoCommentRepo : IEntityRepo<TodoComment>, ITodoCommentRepo
{
    private readonly List<TodoComment> _todoComments;

    public MockTodoCommentRepo()
    {
        _todoComments = new List<TodoComment>
        {
            new("Comment 1") { Id = 1, TodoId = 1 },
            new("Comment 2") { Id = 2, TodoId = 1 },
            new("Comment 3") { Id = 3, TodoId = 2 },
        };
    }

    /// <inheritdoc />
    public IEnumerable<TodoComment> GetAll()
    {
        return _todoComments;
    }

    /// <inheritdoc />
    public TodoComment? GetById(int id)
    {
        return _todoComments.SingleOrDefault(todo => todo.Id == id);
    }

    /// <inheritdoc />
    public void Add(TodoComment entity)
    {
        if (entity.Id != 0)
            throw new ArgumentException("Given entity should not have Id set", nameof(entity));

        var lastId = _todoComments.OrderBy(todo => todo.Id).Last().Id;
        entity.Id = ++lastId;
        _todoComments.Add(entity);
    }

    /// <inheritdoc />
    public void Update(int id, TodoComment entity)
    {
        var foundTodoComment = _todoComments.SingleOrDefault(todo => todo.Id == id);
        if (foundTodoComment is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found");

        foundTodoComment.Text = entity.Text;
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        var foundTodoComment = _todoComments.SingleOrDefault(todo => todo.Id == id);
        if (foundTodoComment is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found");

        _todoComments.Remove(foundTodoComment);
    }

    /// <inheritdoc />
    public IEnumerable<TodoComment> GetAllForTodo(int todoId)
    {
        return _todoComments.Where(todoComment => todoComment.TodoId == todoId).ToList();
    }
}
using TodoApp.Model;

namespace TodoApp.EF.Repository;

public class MockTodoRepo : IEntityRepo<Todo>
{
    private readonly List<Todo> _todos;

    public MockTodoRepo()
    {
        _todos = new List<Todo>
        {
            new("Task 1")
            {
                Id = 1, Detail = new TodoDetail { CreateDate = new DateTime(year: 2022, month: 1, day: 1) },
            },
            new("Task 2")
            {
                Id = 2, Detail = new TodoDetail { CreateDate = new DateTime(year: 2022, month: 1, day: 2) },
            },
            new("Task 3")
            {
                Id = 3,
                Finished = true,
                Detail = new TodoDetail
                {
                    CreateDate = new DateTime(year: 2022, month: 1, day: 3),
                    FinishDate = new DateTime(year: 2022, month: 2, day: 3),
                },
            },
        };
    }

    /// <inheritdoc />
    public IEnumerable<Todo> GetAll()
    {
        return _todos;
    }

    /// <inheritdoc />
    public Todo? GetById(int id)
    {
        return _todos.SingleOrDefault(todo => todo.Id == id);
    }

    /// <inheritdoc />
    public void Add(Todo entity)
    {
        if (entity.Id != 0)
            throw new ArgumentException("Given entity should not have Id set", nameof(entity));

        var lastId = _todos.OrderBy(todo => todo.Id).Last().Id;
        entity.Id = ++lastId;
        _todos.Add(entity);
    }

    /// <inheritdoc />
    public void Update(int id, Todo entity)
    {
        var foundTodo = _todos.SingleOrDefault(todo => todo.Id == id);
        if (foundTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found");

        foundTodo.Title = entity.Title;
        foundTodo.Finished = entity.Finished;
    }

    /// <inheritdoc />
    public void Delete(int id)
    {
        var foundTodo = _todos.SingleOrDefault(todo => todo.Id == id);
        if (foundTodo is null)
            throw new KeyNotFoundException($"Given id '{id}' was not found");

        _todos.Remove(foundTodo);
    }
}
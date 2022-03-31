using TodoApp.Model;

namespace TodoApp.EF.Repository;

public interface ITodoCommentRepo
{
    IEnumerable<TodoComment> GetAllForTodo(int todoId);
}
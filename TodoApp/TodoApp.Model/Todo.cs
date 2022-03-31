using System.ComponentModel.DataAnnotations;

namespace TodoApp.Model;

public class Todo : BaseEntity
{
    public Todo(string title)
    {
        Title = title;
        Comments = new List<TodoComment>();
        Detail = new TodoDetail();
    }

    [Required] public string Title { get; set; }

    public bool Finished { get; set; }

    // Relations
    public TodoDetail Detail { get; set; }

    public ICollection<TodoComment> Comments { get; set; }
}
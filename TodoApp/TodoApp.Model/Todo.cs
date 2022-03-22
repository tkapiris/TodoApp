using System.ComponentModel.DataAnnotations;

namespace TodoApp.Model;

public class Todo : BaseEntity
{
    public Todo(string title)
    {
        Title = title;
    }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public bool Finished { get; set; }
}
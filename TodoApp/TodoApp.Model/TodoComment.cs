using System.ComponentModel.DataAnnotations;

namespace TodoApp.Model;

public class TodoComment : BaseEntity
{
    public TodoComment(string text)
    {
        Text = text;
    }

    [Required] public string Text { get; set; }

    // Relations
    public int TodoId { get; set; }
    public Todo Todo { get; set; } = null!;

    public int CommenterId { get; set; }
    public Commenter Commenter { get; set; }
}
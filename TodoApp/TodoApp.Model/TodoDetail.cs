namespace TodoApp.Model;

public class TodoDetail : BaseEntity
{
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? FinishDate { get; set; }

    // Relations
    public int TodoId { get; set; }
    public Todo Todo { get; set; } = null!;
}
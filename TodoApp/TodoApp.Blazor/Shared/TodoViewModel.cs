using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Blazor.Shared
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }
    }

    public class TodoEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public List<TodoEditCommentViewModel> Comments { get; set; } = new();
        public List<TodoEditCommenterViewModel> Commenters { get; set; } = new();
    }
    public class TodoEditCommenterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TodoEditCommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int CommenterId { get; set; }
    }
}

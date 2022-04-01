using TodoApp.Model;

namespace TodoApp.Web.Models
{
    public class TodoListViewModel
    {
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime? FinshDate { get; set; }
    }

    public class TodoCommentListViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class TodoDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime? FinshDate { get; set; }
        public List<TodoCommentListViewModel> Comments { get; set; } = new List<TodoCommentListViewModel>();
    }

    public class TodoCreateViewModel
    {
        public string Title { get; set; }
    }

    public class TodoUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class TodoFinishViewModel
    {
        public int Id { get; set; }
    }

    public class TodoDeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
    }
}

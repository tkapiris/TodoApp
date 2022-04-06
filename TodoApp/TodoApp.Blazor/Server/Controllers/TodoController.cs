using Microsoft.AspNetCore.Mvc;
using TodoApp.Blazor.Shared;
using TodoApp.EF.Repository;
using TodoApp.Model;

namespace TodoApp.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IEntityRepo<Todo> _todoRepo;
        private readonly IEntityRepo<Commenter> _commenterRepo;

        public TodoController(IEntityRepo<Todo> todoRepo, IEntityRepo<Commenter> commenterRepo)
        {
            _todoRepo = todoRepo;
            _commenterRepo = commenterRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoListViewModel>> Get()
        {
            var result = await _todoRepo.GetAllAsync();
            return result.Select(x => new TodoListViewModel
            {
                Id = x.Id,
                Finished = x.Finished,
                FinishedDate = x.Detail?.FinishDate,
                Title = x.Title
            });
        }

        [HttpGet("{id}")]
        public async Task<TodoEditViewModel> Get(int id)
        {
            TodoEditViewModel model = new();
            if(id != 0)
            {
                var existing = await _todoRepo.GetByIdAsync(id);
                model.Id = existing.Id;
                model.Finished = existing.Finished;
                model.Title = existing.Title;
                model.Comments = existing.Comments.Select(comment => new TodoEditCommentViewModel
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    CommenterId = comment.CommenterId
                }).ToList();
            }

            var commenters = await _commenterRepo.GetAllAsync();
            model.Commenters = commenters.Select(x => new TodoEditCommenterViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _todoRepo.DeleteAsync(id);
        }



        [HttpPost]
        public async Task Post(TodoEditViewModel todo)
        {
            var newTodo = new Todo(todo.Title);
            foreach(var comment in todo.Comments)
            {
                newTodo.Comments.Add(new TodoComment(comment.Text)
                {
                    CommenterId = comment.CommenterId
                });
            }
            await _todoRepo.AddAsync(newTodo);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TodoEditViewModel todo)
        {
            var itemToUpdate = await _todoRepo.GetByIdAsync(todo.Id);
            if (itemToUpdate == null) return NotFound();
            if(todo.Finished && !itemToUpdate.Finished)
            {
                itemToUpdate.Detail.FinishDate = DateTime.Now;
            }

            itemToUpdate.Finished = todo.Finished;
            itemToUpdate.Title = todo.Title;
            itemToUpdate.Comments = todo.Comments.Select(comment => new TodoComment(comment.Text)
            {
                Id = comment.Id,
                CommenterId = comment.CommenterId
            }).ToList();

            await _todoRepo.UpdateAsync(todo.Id, itemToUpdate);

            return Ok();
        }
    }
}

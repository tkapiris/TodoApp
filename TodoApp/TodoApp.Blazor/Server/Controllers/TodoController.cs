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

        public TodoController(IEntityRepo<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
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

        [HttpPost]
        public async Task Post(TodoListViewModel todo)
        {
            var newTodo = new Todo(todo.Title);
            await _todoRepo.AddAsync(newTodo);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _todoRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(TodoListViewModel todo)
        {
            var itemToUpdate = await _todoRepo.GetByIdAsync(todo.Id);
            if (itemToUpdate == null) return NotFound();
            if(todo.Finished && !itemToUpdate.Finished)
            {
                itemToUpdate.Detail.FinishDate = DateTime.Now;
            }

            itemToUpdate.Finished = todo.Finished;
            itemToUpdate.Title = todo.Title;

            await _todoRepo.UpdateAsync(todo.Id, itemToUpdate);

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Model;

namespace TodoApp.EF.Repositories
{
    public class MockTodoRepo : IEntityRepo<Todo>
    {

        private List<Todo> _todos = new List<Todo>() { new Todo("Todo1") { Id = 1 }, new Todo("Todo2") { Id = 2 } };

        public Task Create(Todo entity)
        {
            _todos.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var foundTodo = _todos.SingleOrDefault(todo => todo.Id == id);
            if (foundTodo is null)
                return Task.CompletedTask;
            _todos.Remove(foundTodo);
            return Task.CompletedTask;
        }

        public List<Todo> GetAll()
        {
            return _todos;
        }

        public Todo? GetById(int id)
        {
            return _todos.SingleOrDefault(todo => todo.Id == id);
        }

        public Task Update(int id, Todo entity)
        {
            var foundTodo = _todos.SingleOrDefault(todo => todo.Id == id);
            if (foundTodo is null)
                return Task.CompletedTask;
            if (!foundTodo.Finished && entity.Finished)
            {
                foundTodo.Detail.FinishDate = DateTime.Now;
            }
            foundTodo.Finished = entity.Finished;
            foundTodo.Title = entity.Title;
            return Task.CompletedTask;
        }
    }
}

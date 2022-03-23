using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.EF.Context;
using TodoApp.Model;

namespace TodoApp.EF.Repositories
{
    public class TodoRepo : IEntityRepo<Todo>
    {
        public async Task Create(Todo entity)
        {
            using var context = new TodoAppContext();
            context.Todos.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var context = new TodoAppContext();
            var foundTodo = context.Todos.SingleOrDefault(todo => todo.Id == id);
            if (foundTodo is null)
                return;

            context.Todos.Remove(foundTodo);
            await context.SaveChangesAsync();
        }

        public List<Todo> GetAll()
        {
            using var context = new TodoAppContext();
            return context.Todos.ToList();
        }

        public Todo? GetById(int id)
        {
            using var context = new TodoAppContext();
            return context.Todos.Where(todo => todo.Id == id).SingleOrDefault();
        }

        public async Task Update(int id, Todo entity)
        {
            using var context = new TodoAppContext();
            var foundTodo = context.Todos.Include(todo => todo.Detail).SingleOrDefault(todo => todo.Id == id);
            if (foundTodo is null)
                return;
            if (!foundTodo.Finished && entity.Finished)
            {
                foundTodo.Detail.FinishDate = DateTime.Now;
            }
            foundTodo.Finished = entity.Finished;
            foundTodo.Title = entity.Title;
            await context.SaveChangesAsync();
        }
    }
}

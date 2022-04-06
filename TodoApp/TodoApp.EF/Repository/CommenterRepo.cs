using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.EF.Context;
using TodoApp.Model;

namespace TodoApp.EF.Repository
{
    public class CommenterRepo : IEntityRepo<Commenter>
    {
        private readonly TodoContext context;

        public CommenterRepo(TodoContext dbContext)
        {
            context = dbContext;
        }

        /// <inheritdoc />
        public IEnumerable<Commenter> GetAll()
        {
            // using var context = new TodoContext();
            return context.Commenters.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<Commenter>> GetAllAsync()
        {
            // await using var context = new TodoContext();
            return await context.Commenters.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc />
        public Commenter? GetById(int id)
        {
            // using var context = new TodoContext();
            return context.Commenters.AsNoTracking().SingleOrDefault(todo => todo.Id == id);
        }

        public async Task<Commenter?> GetByIdAsync(int id)
        {
            // await using var context = new TodoContext();
            return await context.Commenters.AsNoTracking().SingleOrDefaultAsync(todo => todo.Id == id);
        }

        /// <inheritdoc />
        public void Add(Commenter entity)
        {
            // using var context = new TodoContext();
            AddLogic(entity, context);
            context.SaveChanges();
        }

        /// <inheritdoc />
        public void Update(int id, Commenter entity)
        {
            // using var context = new TodoContext();
            UpdateLogic(id, entity, context);
            context.SaveChanges();
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            // using var context = new TodoContext();
            DeleteLogic(id, context);
            context.SaveChanges();
        }

        public async Task AddAsync(Commenter entity)
        {
            // await using var context = new TodoContext();
            AddLogic(entity, context);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Commenter entity)
        {
            // await using var context = new TodoContext();
            UpdateLogic(id, entity, context);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // await using var context = new TodoContext();
            DeleteLogic(id, context);
            await context.SaveChangesAsync();
        }

        private void DeleteLogic(int id, TodoContext context)
        {
            var dbTodo = context.Commenters.SingleOrDefault(todo => todo.Id == id);
            if (dbTodo is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            context.Commenters.Remove(dbTodo);
        }

        private void UpdateLogic(int id, Commenter entity, TodoContext context)
        {
            var dbCommenter = context.Commenters.SingleOrDefault(todo => todo.Id == id);
            if (dbCommenter is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            dbCommenter.Name = entity.Name;
        }

        private void AddLogic(Commenter entity, TodoContext context)
        {
            if (entity.Id != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            context.Commenters.Add(entity);
        }
    }
}

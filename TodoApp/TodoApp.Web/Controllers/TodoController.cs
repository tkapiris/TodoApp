#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TodoApp.EF.Context;
using TodoApp.EF.Repository;
using TodoApp.Model;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        private readonly IEntityRepo<Todo> _todoRepo;

        public TodoController(IEntityRepo<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            return View(await _todoRepo.GetAllAsync());
        }

        // GET: Todo/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _todoRepo.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return NotFound();
            }

            var viewModel = new TodoDetailViewModel
            {
                Title = todo.Title,
                Finished = todo.Finished,
                FinshDate = todo.Detail.FinishDate
            };

            foreach (var comment in todo.Comments)
            {
                var commentViewModel = new TodoCommentListViewModel
                {
                    Text = comment.Text
                };
                viewModel.Comments.Add(commentViewModel);
            }

            return View(viewModel);
        }

        // GET: Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title")] TodoCreateViewModel todoViewModel)
        {
            if (ModelState.IsValid)
            {
                var newTodo = new Todo(todoViewModel.Title);

                await _todoRepo.AddAsync(newTodo);
                return RedirectToAction(nameof(Index));
            }
            return View(todoViewModel);
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _todoRepo.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return NotFound();
            }
            var todoViewModel = new TodoUpdateViewModel
            {
                Id = todo.Id,
                Title = todo.Title
            };
            return View(todoViewModel);
        }

        // POST: Todo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title", "Id")] TodoUpdateViewModel todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentTodo = await _todoRepo.GetByIdAsync(id);
                if (currentTodo is null)
                    return BadRequest("Could not find todo");
                currentTodo.Title = todo.Title;
                await _todoRepo.UpdateAsync(id, currentTodo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Finish(int id)
        {
            var currentTodo = await _todoRepo.GetByIdAsync(id);
            if (currentTodo is null)
                return BadRequest("Could not find todo");
            if (!currentTodo.Finished)
            {
                currentTodo.Finished = true;
                currentTodo.Detail.FinishDate = DateTime.Now;

                await _todoRepo.UpdateAsync(id, currentTodo);
            }

            return Ok();
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _todoRepo.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return NotFound();
            }

            var viewModel = new TodoDeleteViewModel
            {
                Title = todo.Title,
                Id = todo.Id,
                Finished = todo.Finished
            };
            return View(viewModel);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _todoRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

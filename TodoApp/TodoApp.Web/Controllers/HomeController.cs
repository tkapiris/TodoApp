using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using TodoApp.Model;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Test()
    {
        // Got todo from db for example
        var todo = new Todo("test");

        var testModel = new TestViewModel
        {
            TodoTitle = todo.Title
        };
        return View(testModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
using Microsoft.Extensions.DependencyInjection;

using TodoApp.EF.Context;
using TodoApp.EF.Repository;
using TodoApp.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodoContext>();
var useMocks = Boolean.Parse(builder.Configuration["UseMocks"]);
if (!useMocks)
{
    builder.Services.AddScoped<IEntityRepo<Todo>, TodoRepo>();
}
else
{
    builder.Services.AddSingleton<IEntityRepo<Todo>, MockTodoRepo>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();
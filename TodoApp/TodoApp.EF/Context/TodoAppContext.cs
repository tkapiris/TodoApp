using Microsoft.EntityFrameworkCore;

using TodoApp.EF.Configuration;
using TodoApp.Model;

namespace TodoApp.EF.Context;

public class TodoAppContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoDetail> TodoDetails { get; set; }
    public DbSet<TodoComment> TodoComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TodoConfiguration());
        modelBuilder.ApplyConfiguration(new TodoCommentConfiguration());
        modelBuilder.ApplyConfiguration(new TodoDetailConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbTodo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connString);
    }
}
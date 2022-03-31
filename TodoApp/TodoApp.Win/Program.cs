using Microsoft.Extensions.DependencyInjection;

using TodoApp.EF.Repository;
using TodoApp.Model;

namespace TodoApp.Win;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());

        var services = new ServiceCollection();

        ConfigureServices(services);

        using var serviceProvider = services.BuildServiceProvider();
        var mainForm = serviceProvider.GetRequiredService<Main>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Actual Service
        //services.AddSingleton<IEntityRepo<Todo>, TodoRepo>()
        //    .AddSingleton<IEntityRepo<TodoComment>, TodoCommentRepo>()
        //    .AddSingleton<Main>();

        // Mock Service
        services.AddSingleton<IEntityRepo<Todo>, MockTodoRepo>()
            .AddSingleton<IEntityRepo<TodoComment>, MockTodoCommentRepo>()
            .AddSingleton<Main>();
    }
}
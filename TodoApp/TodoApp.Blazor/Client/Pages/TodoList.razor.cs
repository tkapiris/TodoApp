using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TodoApp.Blazor.Shared;

namespace TodoApp.Blazor.Client.Pages
{
    public partial class TodoList
    {
        private string NewItemText { get; set; }
        List<TodoListViewModel> todoList = new();
        bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadItemsFromServer();
            isLoading = false;
        }

        private async Task LoadItemsFromServer()
        {
            todoList = await httpClient.GetFromJsonAsync<List<TodoListViewModel>>("todo");
        }

        async Task AddItem()
        {
            if (string.IsNullOrWhiteSpace(NewItemText)) return;
            var newTodo = new TodoListViewModel
            {
                Title = NewItemText
            };
            NewItemText = null;

            await httpClient.PostAsJsonAsync("todo", newTodo);
            await LoadItemsFromServer();
        }

        async Task DeleteItem(TodoListViewModel itemToDelete)
        {
            var confirm = await jsRuntime.InvokeAsync<bool>("confirmDelete", null);
            if (confirm)
            {
                var response = await httpClient.DeleteAsync($"todo/{itemToDelete.Id}");
                response.EnsureSuccessStatusCode();
                await LoadItemsFromServer();
            }
        }

        async Task TitleChanged(ChangeEventArgs e, TodoListViewModel item)
        {
            item.Title = e.Value?.ToString();
            var response = await httpClient.PutAsJsonAsync("todo", item);
            response.EnsureSuccessStatusCode();
            //await LoadItemsFromServer();
        }

        async Task FinishedChanged(TodoListViewModel item)
        {
            item.Finished = !item.Finished;
            var response = await httpClient.PutAsJsonAsync("todo", item);
            response.EnsureSuccessStatusCode();
            await LoadItemsFromServer();
        }
    }
}

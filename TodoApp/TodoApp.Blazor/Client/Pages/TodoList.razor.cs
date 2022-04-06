using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TodoApp.Blazor.Shared;

namespace TodoApp.Blazor.Client.Pages
{
    public partial class TodoList
    {
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
            navigationManager.NavigateTo("/todolist/edit");
        }

        async Task EditItem(TodoListViewModel itemToEdit)
        {
            navigationManager.NavigateTo($"/todolist/edit/{itemToEdit.Id}");
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
    }
}

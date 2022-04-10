using TodoApp.EF.Repository;
using TodoApp.Model;
using System.Text.Json;
using System.Net.Http.Json;
using TodoApp.Blazor.Shared;

namespace TodoApp.Win;

public partial class Main : Form
{
    private readonly IEntityRepo<TodoComment> _todoCommentsRepo;
    private readonly IEntityRepo<Todo> _todoRepo;

    private int? _selectedTodoId;

    public Main(IEntityRepo<Todo> todoRepo, IEntityRepo<TodoComment> todoCommentsRepo)
    {


        InitializeComponent();
        _todoRepo = todoRepo;
        _todoCommentsRepo = todoCommentsRepo;
    }

    private async void Main_Load(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7213/");
        var response = await httpClient.GetFromJsonAsync<List<TodoListViewModel> >("todo");

        StartLb.Visible = false;
        StartDt.Visible = false;

        FinishLb.Visible = false;
        FinishDt.Visible = false;

        RefreshTodos();
        // ValidateSelection(_selectedTodoId);
    }

    private void TodoGV_SelectionChanged(object sender, EventArgs e)
    {
        if (TodoGV.SelectedRows.Count != 1)
            return;

        _selectedTodoId = (int)TodoGV.SelectedRows[index: 0].Cells[index: 4].Value;
        var finished = (bool)TodoGV.SelectedRows[index: 0].Cells[index: 1].Value;
        ValidateSelection(_selectedTodoId, finished);
        RefreshTodoDetails(_selectedTodoId);
    }

    private void AddBtn_Click(object sender, EventArgs e)
    {
        var todoTitle = TitleTxt.Text;
        if (string.IsNullOrEmpty(todoTitle))
            return;

        var newTodo = new Todo(todoTitle);
        _todoRepo.Add(newTodo);
        RefreshTodos();
    }

    private void FinishBtn_Click(object sender, EventArgs e)
    {
        if (_selectedTodoId is null)
            return;

        var selectedTodo = _todoRepo.GetById(_selectedTodoId.Value);
        if (selectedTodo is null)
            return;

        selectedTodo.Finished = true;
        selectedTodo.Detail.FinishDate = DateTime.Now;
        _todoRepo.Update(_selectedTodoId.Value, selectedTodo);
        RefreshTodos();
        ValidateSelection(_selectedTodoId, selectedTodo.Finished);
    }

    private void ValidateSelection(int? todoId, bool finished = false)
    {
        FinishBtn.Enabled = todoId is not null && !finished;
    }

    private void RefreshTodos()
    {
        TodoGV.DataSource = null;
        TodoGV.DataSource = _todoRepo.GetAll();
        TodoGV.Update();
        TodoGV.Refresh();
        TodoGV.Columns[index: 0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        TodoGV.Columns[index: 2].Visible = false;
        TodoGV.Columns[index: 3].Visible = false;
        TodoGV.Columns[index: 4].Visible = false;
    }

    private void RefreshTodoDetails(int? todoId)
    {
        if (todoId is null)
            return;

        var todoDetail = (TodoDetail)TodoGV.SelectedRows[index: 0].Cells[index: 2].Value;
        if (todoDetail is not null)
        {
            StartLb.Visible = true;
            StartDt.Visible = true;
            StartDt.Value = todoDetail.CreateDate;
            if (todoDetail.FinishDate.HasValue)
            {
                FinishLb.Visible = true;
                FinishDt.Visible = true;
                FinishDt.Value = todoDetail.FinishDate.Value;
            }
            else
            {
                FinishLb.Visible = false;
                FinishDt.Visible = false;
            }
        }
        else
        {
            StartLb.Visible = false;
            StartDt.Visible = false;
        }

        if (_todoCommentsRepo is not ITodoCommentRepo castedCommentsRepo) return;
        TodoCommentsGv.DataSource = null;
        TodoCommentsGv.DataSource = castedCommentsRepo.GetAllForTodo(todoId.Value);
        TodoCommentsGv.Update();
        TodoCommentsGv.Refresh();
        TodoCommentsGv.Columns[index: 0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        TodoCommentsGv.Columns[index: 1].Visible = false;
        TodoCommentsGv.Columns[index: 2].Visible = false;
        TodoCommentsGv.Columns[index: 3].Visible = false;
    }
}
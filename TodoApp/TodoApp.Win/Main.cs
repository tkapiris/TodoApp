using System.Windows.Forms;

using TodoApp.EF.Repositories;
using TodoApp.Model;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TodoApp.Win
{
    public partial class MainForm : Form
    {
        private readonly IEntityRepo<Todo> _todoRepo;

        private List<Todo> _todos = new List<Todo>();

        public MainForm(IEntityRepo<Todo> todoRepo)
        {
            InitializeComponent();
            _todoRepo = todoRepo;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RefreshTodos();
        }

        private void RefreshTodos()
        {
            _todos = _todoRepo.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _todos;
            dataGridView1.Refresh();
            dataGridView1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var todoTile = textBox1.Text;
            if (string.IsNullOrEmpty(todoTile))
                return;
            var todo = new Todo(todoTile);
            _todoRepo.Create(todo);
            textBox1.Text = String.Empty;
            RefreshTodos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedTodo = selectedRow.DataBoundItem as Todo;
                if (selectedTodo is not null)
                {
                    selectedTodo.Finished = true;
                    _todoRepo.Update(selectedTodo.Id, selectedTodo);
                    RefreshTodos();
                }
            }

        }
    }
}
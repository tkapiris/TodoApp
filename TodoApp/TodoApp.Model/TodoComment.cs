using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class TodoComment : BaseEntity
    {
        public TodoComment(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        public int TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}

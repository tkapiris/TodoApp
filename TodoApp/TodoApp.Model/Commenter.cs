using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class Commenter : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TodoComment> TodoComments { get; set; }
    }
}

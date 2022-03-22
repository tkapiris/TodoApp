using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class Test
    {
        public Test()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}

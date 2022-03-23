using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class TodoDetail : BaseEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? FinishDate { get; set; }

        public int TodoId { get; set; }
        public Todo Todo { get; set; }
    }
}

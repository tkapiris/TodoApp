﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Blazor.Shared
{
    public class TodoListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}

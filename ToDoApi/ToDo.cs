using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDo
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool IsComplete { get; set; } = false;
    }
}

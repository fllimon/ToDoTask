using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextFileDatabase.Models
{
    internal class ToDo : IToDo
    {
        public long Id { get; set; }
        public string Description { get; set; } 
        public DateTime Date { get; set; }
        public byte IsComplete { get; set; }
        public byte IsDeleted { get; set; }
    }
}

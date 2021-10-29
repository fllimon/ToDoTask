using System;

namespace ToDoApi.Models
{
    public class PutToDo
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public byte IsComplete { get; set; }
    }
}

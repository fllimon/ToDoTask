using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileDatabase.Factoryes
{
    public class ToDoJsonFactory : IToDoFactory
    {
        public IToDo GetToDo(long id, string description, DateTime date, byte isComplete, byte isDeleted)
        {
            return new Models.ToDo { Id = id, Description = description, Date = date, IsComplete = isComplete, IsDeleted = isDeleted };
        }
    }
}

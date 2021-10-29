using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.EFDatabase.Factoryes
{
    public class ToDoEfFactory : IToDoFactory
    {
        public IToDo GetToDo(long id, string description, DateTime date, byte isComplete, byte isDeleted = 0)
        {
            return new Models.ToDo(id, description, date, isComplete, isDeleted);
        }
    }
}

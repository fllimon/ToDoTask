using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IToDoFactory
    {
        IToDo GetToDo(long id, string description, DateTime date, byte isComplete, byte isDeleted = 0);
    }
}

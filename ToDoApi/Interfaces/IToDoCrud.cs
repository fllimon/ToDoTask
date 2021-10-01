using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public interface IToDoCrud
    {
        Task<bool> AddAsync(ToDo item);

        Task<IEnumerable<ToDo>> GetAllAsync();

        ToDo GetToDoById(long id);

        Task<bool> Remove(long id);

        Task<bool> Update(ToDo item);
    }
}

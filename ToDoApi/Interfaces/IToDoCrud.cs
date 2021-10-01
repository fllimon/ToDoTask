using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public interface IToDoCrud
    {
        Task AddAsync(ToDo item);

        Task<IEnumerable<ToDo>> GetAllAsync();

        Task<ToDo> FindAsync(string key);

        Task<bool> Remove(long key);

        Task<bool> Update(ToDo item);
    }
}

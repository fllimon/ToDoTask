using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public interface IToDoCrud
    {
        Task AddAsync(ToDo item);

        Task<ToDo> GetAllAsync();

        Task<ToDo> FindAsync(string key);

        ToDo Remove(string key);

        void Update(ToDo item);
    }
}

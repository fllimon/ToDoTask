using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    interface IToDoCrud
    {
        Task AddAsync(ToDo item);

        Task<ToDo> GetAllAsync();

        ToDo Find(string key);

        ToDo Remove(string key);

        void Update(ToDo item);
    }
}

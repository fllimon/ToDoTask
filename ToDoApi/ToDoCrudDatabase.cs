using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDoCrudDatabase : IToDoCrud
    {
        public Task AddAsync(ToDo item)
        {
            throw new NotImplementedException();
        }

        public Task<ToDo> FindAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<ToDo> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ToDo Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }
    }
}

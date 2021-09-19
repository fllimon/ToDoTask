using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDoCrudDatabase : IToDoCrudEF
    {
        private ToDoContext _db;

        public ToDoCrudDatabase(ToDoContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ToDo item)
        {
            _db.ToDo.Add(item);

           await _db.SaveChangesAsync();
        }

        public Task<ToDo> FindAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await Task.Run(() => Get());
        }

        public ToDo Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }

        //private void Add(ToDo item)
        //{
        //    if (item == null)
        //    {
        //        return;
        //    }

        //    _db.ToDo.Add(item);
        //    _db.SaveChanges();
        //}

        private IEnumerable<ToDo> Get()
        {
            return _db.ToDo.ToList();    //ToDo: Read LazyLoading
        }
    }
}

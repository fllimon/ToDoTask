using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDoCrudDatabase : IToDoCrud
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

        public async Task Remove(string key)
        {
            ToDo data = (ToDo)_db.ToDo.Where(a => a.Key.Equals(key));
            data.IsDeleted = 1;

            _db.ToDo.Update(data);
            await _db.SaveChangesAsync();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ToDo> Get()
        {
            var data = _db.ToDo.Select(a => a).Where(a => a.IsDeleted != 1);

            return data.ToList();  
        }
    }
}

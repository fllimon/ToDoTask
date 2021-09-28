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
            ToDo data = new ToDo { Date = DateTime.Now, Description = "dsfsdf", IsComplete = 0, Key = "sfddasf", IsDeleted = 0 };
            
            _db.ToDo.Add(data);

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
            var data = _db.ToDo.Select(a => a).Where(a => a.IsDeleted != 1);

            return data.ToList();    //ToDo: Read LazyLoading
        }

        private void Delete(string key)
        {
            ToDo data = (ToDo)_db.ToDo.Where(a => a.Key.Equals(key));
        }
    }
}

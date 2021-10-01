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
            ToDo data = _db.ToDo.Where(a => a.Description.Equals(key)).FirstOrDefault();

            if (data == null)
            {
                return;
            }

            _db.ToDo.Update(data);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Update(ToDo item)
        {
            bool isUpdated = false;

            if (item == null)
            {
                return isUpdated;
            }

            ToDo obj = FindToDoById(item);

            if (obj == null)
            {
                return isUpdated;
            }

            ToDo data = new ToDo
            {
                Date = item.Date,
                Description = item.Description,
                IsComplete = item.IsComplete,
                IsDeleted = item.IsDeleted
            };

            _db.ToDo.Update(data);
            await _db.SaveChangesAsync();

            return isUpdated = true;
        }

        private ToDo FindToDoById(ToDo item)
        {
            return _db.ToDo.Where(x => x.Id == item.Id).FirstOrDefault();
        }

        private IEnumerable<ToDo> Get()
        {
            var data = _db.ToDo.Where(a => a.IsDeleted != 1);

            return data.ToList();  
        }
    }
}

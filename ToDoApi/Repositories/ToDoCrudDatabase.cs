using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDoCrudDatabase : IToDoCrud
    {
        private readonly string _connectionString;
        private ToDoContext _db;

        public ToDoCrudDatabase(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddAsync(ToDo item)
        {
            bool isAdd = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                if (item == null)
                {
                    return isAdd;
                }

                _db.ToDo.Add(item);
                await _db.SaveChangesAsync();

                return isAdd = true;
            }
        }

        public ToDo GetToDoById(long id)
        {
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option)) 
            {
                ToDo data = FindToDoById(id);

                return data;
            }
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {

                var data = _db.ToDo.Where(a => a.IsDeleted != 1);

                return await data.ToListAsync();
            }
        }

        public async Task<bool> Remove(long id)
        {
            bool isDeleted = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {

                ToDo data = FindToDoById(id);

                if (data == null)
                {
                    return isDeleted;
                }

                data.IsDeleted = 1;

                _db.ToDo.Update(data);
                await _db.SaveChangesAsync();

                return isDeleted = true;
            }
        }

        public async Task<bool> Update(ToDo item)
        {
            bool isUpdated = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                if (item == null)
                {
                    return isUpdated;
                }

                ToDo obj = FindToDoById(item.Id);

                if (obj == null)
                {
                    return isUpdated;
                }

                obj.Description = item.Description;
                obj.Date = item.Date;
                obj.IsComplete = item.IsComplete;
                obj.IsDeleted = item.IsDeleted;

                _db.ToDo.Update(obj);
                await _db.SaveChangesAsync();

                return isUpdated = true;
            }
        }

        private ToDo FindToDoById(long id)
        {
            return _db.ToDo.Where(x => x.Id == id && x.IsDeleted != 1).FirstOrDefault();
        }

        private DbContextOptions<ToDoContext> GetOption()
        {
            DbContextOptionsBuilder<ToDoContext> optionBuilder = new DbContextOptionsBuilder<ToDoContext>();
            DbContextOptions<ToDoContext> option = optionBuilder.UseSqlServer(_connectionString).Options;

            return option;
        }
    }
}

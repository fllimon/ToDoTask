using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.EFDatabase.Context;


namespace ToDo.EFDatabase.Repositories
{
    public class ToDoCrudDatabase : IToDoCrud
    {
        private readonly string _connectionString;
        private ToDoContext _db;

        public ToDoCrudDatabase(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddAsync(IToDo item)
        {
            bool isAdd = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                if (item == null)
                {
                    return isAdd;
                }

                _db.ToDo.Add((Models.ToDo)item);
                await _db.SaveChangesAsync();

                return isAdd = true;
            }
        }

        public async Task<IToDo> GetToDoById(long id)
        {
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option)) 
            {
                return await _db.FindAsync<IToDo>(id);
            }
        }

        public async Task<IEnumerable<IToDo>> GetAllAsync()
        {
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                return await _db.ToDo.Where(a => a.IsDeleted != 1).ToListAsync();
            }
        }

        public async Task<bool> Remove(long id)
        {
            bool isDeleted = false;

            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                Models.ToDo data = FindToDoById(id);

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

        public async Task<bool> UpdateAsync(IToDo item)
        {
            bool isUpdated = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                if (item == null)
                {
                    return isUpdated;
                }

                Models.ToDo obj = FindToDoById(item.Id);

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

        public async Task<bool> IsIdExist(long id)
        {
            bool isExist = false;
            DbContextOptions<ToDoContext> option = GetOption();

            using (_db = new ToDoContext(option))
            {
                Models.ToDo item = await _db.FindAsync<Models.ToDo>(id);

                return item != null ? isExist = true : isExist;
            }
        }

        private Models.ToDo FindToDoById(long id)
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

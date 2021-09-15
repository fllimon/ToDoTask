using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApi
{
    class ToDoCrudJson : IToDoCrud
    {
        public const string FILE_NAME = "todo.json";

        public async Task AddAsync(ToDo item)
        {
            await Task.Run(() => Add(item));
        }

        public async Task<ToDo> FindAsync(string key)
        {
            // return await Task.Run(() => GetDataOnKey(key));
            throw new NotImplementedException();
        }

        public async Task<ToDo> GetAllAsync()
        {
            return await Task.Run(() => GetAllData());
        }

        public ToDo Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }

        private void Add(ToDo item)
        {
            var todoData = new ToDo
            {
                IsComplete = item.IsComplete,
                Key = item.Key,
                Name = item.Name
            };

            string jsonString = JsonSerializer.Serialize(todoData);

            File.WriteAllText(FILE_NAME, jsonString);
        }

        //private ToDo GetDataOnKey(string key)
        //{
        //    var data = JsonSerializer.Deserialize<ToDo>(File.ReadAllText(FILE_NAME));

        //    foreach (var item in data)
        //    {
        //        if (item.Equals(key))
        //        {
        //            ToDo todo = new ToDo
        //            {
        //                Key = data.Key,
        //                Name = data.Name,
        //                Date = data.Date,
        //                IsComplete = data.IsComplete
        //            };

        //            return todo;
        //        }
        //    }

        //    throw new KeyNotFoundException("Data not found");
        //}

        private ToDo GetAllData()
        {
            ToDo data = JsonSerializer.Deserialize<ToDo>(File.ReadAllText(FILE_NAME));

            return data;
        }
    }
}

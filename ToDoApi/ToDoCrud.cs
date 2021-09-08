using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApi
{
    class ToDoCrud : IToDoCrud
    {
        public const string FILE_NAME = "todo.json";

        public async Task AddAsync(ToDo item)
        {
            await Task.Run(() => Add(item));
        }

        public ToDo Find(string key)
        {
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

        private ToDo GetAllData()
        {
            ToDo data = JsonSerializer.Deserialize<ToDo>(File.ReadAllText(FILE_NAME));

            return data;
        }
    }
}

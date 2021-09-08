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
        public async Task AddItem(ToDo item)
        {
            await Task.Run(() => Add(item));
        }

        public ToDo Find(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetAll()
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

        private void Add(ToDo item)
        {
            var todoData = new ToDo
            {
                IsComplete = item.IsComplete,
                Key = item.Key,
                Name = item.Name
            };

            string fileName = "todo.json";
            string jsonString = JsonSerializer.Serialize(todoData);

            File.WriteAllText(fileName, jsonString);
        }
    }
}

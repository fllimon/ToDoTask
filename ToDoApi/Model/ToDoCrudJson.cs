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
        private List<ToDo> _lists;

        public async Task AddAsync(ToDo item)
        {
            await Task.Run(() => Add(item));
        }

        public async Task<ToDo> FindAsync(string key)
        {
             return await Task.Run(() => GetDataOnKey(key));
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            StreamReader reader = new StreamReader(FILE_NAME);

            ToDo data = await JsonSerializer.DeserializeAsync<ToDo>(reader.BaseStream);   

            _lists = new List<ToDo>();

            _lists.Add(data);

            return _lists;
        }

        public Task Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo item)
        {
            throw new NotImplementedException();
        }

        private void Add(ToDo item)
        {
            if (item == null)
            {
                return;
            }

            string jsonString = JsonSerializer.Serialize(item);

            File.WriteAllText(FILE_NAME, jsonString);
        }

        private ToDo GetDataOnKey(string key)
        {
            ToDo data = JsonSerializer.Deserialize<ToDo>(File.ReadAllText(FILE_NAME));

            if (data.Key.Equals(key))
            {
                return data;
            }

            throw new KeyNotFoundException("Data not found");
        }
    }
}

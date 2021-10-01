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

        public async Task<bool> AddAsync(ToDo item)
        {
            return await Task.Run(() => Add(item));
        }

        public ToDo GetToDoById(long id)
        {
             //return await Task.Run(() => GetDataOnKey(key));
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            StreamReader reader = new StreamReader(FILE_NAME);

            ToDo data = await JsonSerializer.DeserializeAsync<ToDo>(reader.BaseStream);   

            _lists = new List<ToDo>();

            _lists.Add(data);

            return _lists;
        }

        public async Task<bool> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ToDo item)
        {
            throw new NotImplementedException();
        }

        private bool Add(ToDo item)
        {
            bool isAdd = false;

            if (item == null)
            {
                return isAdd;
            }

            string jsonString = JsonSerializer.Serialize(item);
            File.WriteAllText(FILE_NAME, jsonString);

            return isAdd = true;
        }

        private ToDo GetDataOnKey(string key)
        {
            ToDo data = JsonSerializer.Deserialize<ToDo>(File.ReadAllText(FILE_NAME));

            if (data.Description.Equals(key))
            {
                return data;
            }

            throw new KeyNotFoundException("Data not found");
        }
    }
}

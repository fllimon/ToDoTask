using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Domain.Interfaces;
using TextFileDatabase.Models;

namespace TextFileDatabase.Repositories
{
    public class ToDoCrudJson : IToDoCrud
    {
        public const string FILE_NAME = "todo.json";
        private Lazy<IList<ToDo>> _lists = new Lazy<IList<ToDo>>(DeserializeData().ToList());

        public async Task<bool> AddAsync(IToDo item)
        {
            return await Add(item);
        }

        public async Task<IToDo> GetToDoById(long id)
        {
            return _lists.Value.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<IToDo>> GetAllAsync()
        {
            return await DeserializeDataAsync();
        }

        public async Task<bool> Remove(long id)
        {
            bool isDeleted = false;

            var data = _lists.Value.FirstOrDefault(x => x.Id == id);
            
            if (data != null)
            {
                _lists.Value.Remove(data);
                await SerealizeData(_lists.Value);

                isDeleted = true;
            }
            
            return isDeleted;
        }

        public async Task<bool> Update(IToDo item)
        {
            bool isUpdated = false;

            var data = _lists.Value.FirstOrDefault(x => x.Id == item.Id);
            _lists.Value.Remove(data);

            await Add(item);

            return isUpdated;
        }

        private async Task<bool> Add(IToDo item)
        {
            bool isAdd = false;

            if (item == null)
            {
                return isAdd;
            }

            _lists.Value.Add((ToDo)item);
            await SerealizeData(_lists.Value);

            return isAdd = true;
        }

        public async Task<bool> IsIdExist(long id)
        {
            bool isExist = false;

            var data = _lists.Value.FirstOrDefault(x => x.Id == id);

            return data != null ? isExist = true : false;
        }

        private async Task SerealizeData(IList<ToDo> lists)
        {
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                var data = JsonSerializer.Serialize(lists);

                await writer.WriteLineAsync(data);
            }
        }

        private static IEnumerable<ToDo> DeserializeData()
        {
            return JsonSerializer.Deserialize<List<ToDo>>(File.ReadAllText(FILE_NAME));
        }

        private async Task<IEnumerable<ToDo>> DeserializeDataAsync()
        {
            return JsonSerializer.Deserialize<List<ToDo>>(await File.ReadAllTextAsync(FILE_NAME));
        }
    }
}

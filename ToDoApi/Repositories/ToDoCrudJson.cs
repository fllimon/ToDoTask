using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ToDoApi
{
    class ToDoCrudJson : IToDoCrud
    {
        public const string FILE_NAME = "todo.json";
        private Lazy<IList<ToDo>> _lists = new Lazy<IList<ToDo>>(DeserializeData().ToList());

        public async Task<bool> AddAsync(ToDo item)
        {
            return await Add(item);
        }

        public async Task<ToDo> GetToDoById(long id)
        {
            return _lists.Value.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
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

        public async Task<bool> Update(ToDo item)
        {
            bool isUpdated = false;

            var data = _lists.Value.FirstOrDefault(x => x.Id == item.Id);
            _lists.Value.Remove(data);

            await Add(item);

            return isUpdated;
        }

        private async Task<bool> Add(ToDo item)
        {
            bool isAdd = false;

            if (item == null)
            {
                return isAdd;
            }

            _lists.Value.Add(item);
            await SerealizeData(_lists.Value);

            return isAdd = true;
        }

        private async Task SerealizeData(IList<ToDo> lists)
        {
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                var data = JsonConvert.SerializeObject(lists);

                await writer.WriteLineAsync(data);
            }
        }

        private static IEnumerable<ToDo> DeserializeData()
        {
            return JsonConvert.DeserializeObject<List<ToDo>>(File.ReadAllText(FILE_NAME));
        }

        private async Task<IEnumerable<ToDo>> DeserializeDataAsync()
        {
            return JsonConvert.DeserializeObject<List<ToDo>>(await File.ReadAllTextAsync(FILE_NAME));
        }
    }
}

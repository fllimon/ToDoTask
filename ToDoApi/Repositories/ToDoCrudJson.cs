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
        private static IList<ToDo> _lists = new List<ToDo>();
       
        public async Task<bool> AddAsync(ToDo item)
        {
            return await Add(item);
        }

        public async Task<ToDo> GetToDoById(long id)
        {
            return _lists.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await DesetializeData();
        }

        public async Task<bool> Remove(long id)
        {
            bool isDeleted = false;

            var data = _lists.FirstOrDefault(x => x.Id == id);
            _lists.Remove(data);

            await SerealizeData(_lists);

            return isDeleted;
        }

        public async Task<bool> Update(ToDo item)
        {
            bool isUpdated = false;

            var data = _lists.FirstOrDefault(x => x.Id == item.Id);
            _lists.Remove(data);

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

            _lists.Add(item);
            await SerealizeData(_lists);

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

        private async Task<IEnumerable<ToDo>> DesetializeData()
        {
            return JsonConvert.DeserializeObject<List<ToDo>>(await File.ReadAllTextAsync(FILE_NAME));
        }
    }
}

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
            return await Task.Run(() => Add(item));
        }

        public ToDo GetToDoById(long id)
        {
            IEnumerable<ToDo> data = DesetializeData();

            foreach (ToDo item in data)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            using (StreamReader reader = new StreamReader(FILE_NAME))
            {
                return await Task.Run(() => DesetializeData());
            }
        }

        public async Task<bool> Remove(long id)
        {
            bool isDeleted = false;
            IEnumerable<ToDo> data = DesetializeData();

            foreach (ToDo item in data)
            {
                if (item.Id == id)
                {
                    ToDo obj = new ToDo(item);
                    _lists.Remove(obj);
                    isDeleted = true;

                    break;
                }
            }

            SerealizeData(_lists);

            return isDeleted;
        }

        public async Task<bool> Update(ToDo item)
        {
            bool isUpdated = false;
            IEnumerable<ToDo> data = DesetializeData();

            foreach (ToDo tmp in data)
            {
                if (tmp.Id == item.Id)
                {
                    ToDo obj = new ToDo(tmp);
                    _lists.Remove(obj);

                    Add(item);
                    isUpdated = true;

                    break;
                }
            }
            return isUpdated;
        }

        private bool Add(ToDo item)
        {
            bool isAdd = false;

            if (item == null)
            {
                return isAdd;
            }

            _lists.Add(item);
            SerealizeData(_lists);

            return isAdd = true;
        }

        private void SerealizeData(IList<ToDo> lists)
        {
            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                var data = JsonConvert.SerializeObject(lists);

                writer.WriteLine(data);
            }
        }

        private IEnumerable<ToDo> DesetializeData()
        {
            return JsonConvert.DeserializeObject<List<ToDo>>(File.ReadAllText(FILE_NAME));
        }
    }
}

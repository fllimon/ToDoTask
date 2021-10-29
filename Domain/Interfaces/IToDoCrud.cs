using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IToDoCrud
    {
        Task<bool> AddAsync(IToDo item);

        Task<IEnumerable<IToDo>> GetAllAsync();

        Task<IToDo> GetToDoById(long id);

        Task<bool> Remove(long id);

        Task<bool> Update(IToDo item);

        Task<bool> IsIdExist(long id);
    }
}

using System;

namespace Domain.Interfaces
{
    public interface IToDo
    {
        long Id { get; set; }

        string Description { get; set; }

        DateTime Date { get; set; }

        byte IsComplete { get; set; }

        byte IsDeleted { get; set; }
    }
}

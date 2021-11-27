using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Test
{
    public class ToDoTest : IToDo
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte IsComplete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

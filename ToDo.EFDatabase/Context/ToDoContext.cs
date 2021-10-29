using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDo.EFDatabase.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option) 
            : base(option)
        {

        }

        public DbSet<Models.ToDo> ToDo { get; set; }
    }
}

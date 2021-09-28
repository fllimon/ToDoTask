using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDo
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }   

        public string Key { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public byte IsComplete { get; set; } 
        
        public byte IsDeleted { get; set; }
    }
}

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
        [JsonIgnore]
        public long Id { get; set; }   

        [Column("KeyToDo")]
        public string Key { get; set; }

        [Column("DescriptionToDo")]
        public string Description { get; set; }

        [Column("DateTimeToDo")]
        public DateTime Date { get; set; }

        [Column("IsComplete")]
        public byte IsComplete { get; set; } 
        
        [JsonIgnore]
        public byte IsDeleted { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }    //ToDo: Можно ли убрать это поле?

        [Column("KeyToDo")]
        public string Key { get; set; }

        [Column("DescriptionToDo")]
        public string Description { get; set; }

        [Column("DateTimeToDo")]
        public DateTime Date { get; set; }

        [Column("IsComplete")]
        public byte IsComplete { get; set; }    //ToDo: tinyint to bool ?? 
    }
}

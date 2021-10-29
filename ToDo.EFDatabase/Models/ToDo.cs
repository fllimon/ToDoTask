using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDo.EFDatabase.Models
{
    public class ToDo : IToDo
    {
        [JsonConstructor]
        public ToDo(long id, string description, DateTime date, byte isComplete, byte isDeleted)
        {
            Id = id;
            Description = description;
            Date = date;
            IsComplete = isComplete;
            IsDeleted = isDeleted;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }   

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public byte IsComplete { get; set; }

        public byte IsDeleted { get; set; }
    }
}

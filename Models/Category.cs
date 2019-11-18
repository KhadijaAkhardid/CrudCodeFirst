using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCodeFirst.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName ="varchar(255)")]
        public string Description { get; set; }
    }
}

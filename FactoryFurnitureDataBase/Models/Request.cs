using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class Request
    {
        public int? Id { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }
        [Required]
        public int Count { get; set; }
        [ForeignKey("RequestId")]
        public List<Material> Material { get; set; }
    }
}

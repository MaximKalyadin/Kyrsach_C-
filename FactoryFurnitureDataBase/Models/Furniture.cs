using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        [Required]
        public string FurnitureName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("FurnitureId")]
        public virtual List<Order> Order { get; set; }
        [ForeignKey("FurnitureId")]
        public virtual List<FurnitureMaterial> FurnitureMaterial { get; set; }
    }
}

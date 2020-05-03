using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class FurnitureMaterial
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int MaterialId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Furniture Furniture { get; set; }
        public virtual Material Material { get; set; }
    }
}

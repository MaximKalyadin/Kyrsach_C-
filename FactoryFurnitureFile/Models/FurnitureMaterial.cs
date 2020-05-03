using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureFile.Models
{
    public class FurnitureMaterial
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}

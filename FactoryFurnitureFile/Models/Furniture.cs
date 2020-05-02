using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureFile.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string FurnitureName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

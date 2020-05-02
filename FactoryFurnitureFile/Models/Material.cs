using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureFile.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

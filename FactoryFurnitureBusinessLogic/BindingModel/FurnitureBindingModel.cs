using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class FurnitureBindingModel
    {
        public int? Id { get; set; }
        public string FurnitureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureMaterials { get; set; }
    }
}

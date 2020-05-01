using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class FurnitureBindingModel
    {
        public int? Id { get; set; }
        public string FurnitureName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

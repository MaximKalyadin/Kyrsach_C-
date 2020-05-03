using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class FurnitureMaterialBindingModel
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class RequestMaterialBindingModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}

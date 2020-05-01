using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public DateTime DataCreate { get; set; }
        public int Count { get; set; }
    }
}

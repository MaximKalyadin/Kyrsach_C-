using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime? DataImplement { get; set; }
        public int ClientId { get; set; }
    }
}

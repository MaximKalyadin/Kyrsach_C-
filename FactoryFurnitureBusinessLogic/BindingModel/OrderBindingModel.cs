using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.Enum;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime? DataImplement { get; set; }
        public int ClientId { get; set; }
        public int Count { get; set; }
        public string ClientFIO { get; set; }
        public int FurnitureId { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
    }
}

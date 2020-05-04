using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using FactoryFurnitureBusinessLogic.Enum;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class OrderViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DataCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DataImplement { get; set; }
        public int ClientId { get; set; }
        public int FurnitureId { get; set; }
        public string ClientFIO { get; set; }
        public decimal Price { get; set; }
        public string FurnitureName { get; set; }
        public int Count { get; set; }
        public Status Status { get; set; }
    }
}

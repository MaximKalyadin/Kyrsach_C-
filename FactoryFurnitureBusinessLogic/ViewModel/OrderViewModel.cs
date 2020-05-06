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
        [DisplayName("Мебель")]
        public string FurnitureName { get; set; }
        public int FurnitureId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Price { get; set; }
        [DisplayName("Статус")]
        public Status Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DataCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DataImplement { get; set; }
        public int ClientId { get; set; }
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }
    }
}

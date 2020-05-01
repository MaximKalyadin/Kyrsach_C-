using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class RequestViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DataCreate { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}

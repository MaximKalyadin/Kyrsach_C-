using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class RequestViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Название заявки")]
        public string RequestName { get; set; }
        [DisplayName("Дата заявки")]
        public DateTime? DataCreate { get; set; }
        public Dictionary<int, (string, int)> RequestMaterials { get; set; }
    }
}

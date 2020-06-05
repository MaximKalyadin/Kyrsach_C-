using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class RequestMaterialViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int MaterialId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}

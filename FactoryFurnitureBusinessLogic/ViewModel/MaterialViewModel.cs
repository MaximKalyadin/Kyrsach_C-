using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class MaterialViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Наименование материала")]
        public string MaterialName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}

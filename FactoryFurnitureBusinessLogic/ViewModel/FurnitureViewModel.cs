using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class FurnitureViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Наименование мебели")]
        public string FurnitureName { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class FurnitureViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Наименование мебели")]
        public string FurnitureName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> FurnitureMaterials { get; set; }
    }
}

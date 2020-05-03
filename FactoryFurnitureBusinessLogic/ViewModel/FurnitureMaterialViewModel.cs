using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class FurnitureMaterialViewModel
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int MaterialId { get; set; }
        [DisplayName("Наименование Мебели")]
        public string FurnitureName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}

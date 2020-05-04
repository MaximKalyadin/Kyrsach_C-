using FactoryFurnitureBusinessLogic.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class ReportViewModel
    {
        public DateTime DateCreate { get; set; }
        public string FurnitureName { get; set; }
        public int Count { get; set; }
        public decimal price { get; set; }
        public Status Status { get; set; }
    }
}

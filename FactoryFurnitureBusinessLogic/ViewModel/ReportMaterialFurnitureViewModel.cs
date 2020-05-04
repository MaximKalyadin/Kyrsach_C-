using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class ReportMaterialFurnitureViewModel
    {
        public string MaterialName { get; set; }
        public int Count { get; set; }
        public List<Tuple<string, int>> Furnitures { get; set; }
    }
}

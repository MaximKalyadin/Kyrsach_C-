using FactoryFurnitureBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.HelperModel
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportViewModel> Orders { get; set; }
    }
}

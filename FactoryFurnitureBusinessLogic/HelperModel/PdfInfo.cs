using FactoryFurnitureBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.HelperModel
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<RequestPdfViewModel> Request { get; set; }
        public List<FurniturePdfViewModel> Furniture { get; set; }
    }
}

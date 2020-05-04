using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.HelperModel
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPizzaIngredientViewModel> Pizzas { get; set; }
    }
}

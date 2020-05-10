using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.HelperModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IMaterialLogic materialLogic;

        public ReportLogic(IMaterialLogic materialLogic)
        {
            this.materialLogic = materialLogic;
        }

        /*public void SaveMaterialToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Пиццы",
                //Materials = pizzaLogic.Read(null)
            });
        }*/

        public void SaveMaterialToExcelFile(ReportBindingModel model, Dictionary<int, (string, int) > materials)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Материалы",
                Materials = materials
            });
        }

    }
}

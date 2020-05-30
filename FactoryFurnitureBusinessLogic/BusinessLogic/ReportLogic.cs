using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Drawing.Charts;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.HelperModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IMaterialLogic materialLogic;
        private readonly IRequestLogic requestLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IFurnitureLogic furnitureLogic;

        public ReportLogic(IMaterialLogic materialLogic, IRequestLogic requestLogic, IOrderLogic orderLogic, IFurnitureLogic furnitureLogic)
        {
            this.materialLogic = materialLogic;
            this.requestLogic = requestLogic;
            this.orderLogic = orderLogic;
            this.furnitureLogic = furnitureLogic;
        }

        public void SaveMaterialToWordFile(ReportBindingModel model, Dictionary<int, (string, int)> materials)
        { 
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Mатериалы",
                Materials = materials
            });
        }

        public void SaveMaterialToExcelFile(ReportBindingModel model, Dictionary<int, (string, int) > materials)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Материалы",
                Materials = materials
            });
        }

        public List<RequestPdfViewModel> GetRequests()
        {
            var requests = requestLogic.Read(null);
            List<RequestPdfViewModel> requestPdfViewModels = new List<RequestPdfViewModel>();
            foreach (var request in requests)
            {
                    foreach (var material in request.RequestMaterials)
                    {
                        requestPdfViewModels.Add(new RequestPdfViewModel()
                        {
                            RequestName = request.RequestName,
                            MaterialName = material.Value.Item1,
                            Count = material.Value.Item2
                        });
                    }
            }
            return requestPdfViewModels;
        }

        public List<FurniturePdfViewModel> GetFurnitures()
        {
            var orders = orderLogic.Read(null);
            var furnitures = furnitureLogic.Read(null);
            List<FurniturePdfViewModel> furnitureModel = new List<FurniturePdfViewModel>();
            foreach (var order in orders)
            {
                    foreach (var furniture in furnitures)
                    {
                        if (order.FurnitureName == furniture.FurnitureName)
                        {
                            foreach (var material in furniture.FurnitureMaterials)
                            {
                                furnitureModel.Add(new FurniturePdfViewModel()
                                {
                                    FurnitureName = furniture.FurnitureName,
                                    MaterialName = material.Value.Item1,
                                    Count = material.Value.Item2 * order.Count
                                });
                            }
                        }
                    }
            }
            return furnitureModel;
        }

        public void SaveToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Отчет",
                Request = GetRequests(),
                Furniture =  GetFurnitures()
            });
        }
    }
}

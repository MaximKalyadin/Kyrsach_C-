using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.Interface
{
    public interface IFurnitureLogic
    {
        List<FurnitureViewModel> Read(FurnitureBindingModel model);
        void CreateOrUpdate(FurnitureBindingModel model);
        void Delete(FurnitureBindingModel model);
    }
}

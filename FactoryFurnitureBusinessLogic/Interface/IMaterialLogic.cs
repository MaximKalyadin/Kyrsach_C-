using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.Interface
{
    public interface IMaterialLogic
    {
        List<MaterialViewModel> Read(MaterialBindingModel model);
        void CreateOrUpdate(MaterialBindingModel model);
        void Delete(MaterialBindingModel model);
        void RemoveMaterials(int FurnitureId, int Count);
    }
}

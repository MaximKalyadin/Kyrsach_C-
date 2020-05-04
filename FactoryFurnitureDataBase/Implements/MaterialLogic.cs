using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureDataBase.Models;
using FactoryFurnitureBusinessLogic.ViewModel;
using System.Linq;

namespace FactoryFurnitureDataBase.Implements
{
    public class MaterialLogic : IMaterialLogic
    {
        public void CreateOrUpdate(MaterialBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Material element = context.Materials.FirstOrDefault(rec => rec.MaterialName == model.MaterialName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть материал с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Material();
                    context.Materials.Add(element);
                }
                element.MaterialName = model.MaterialName;
                element.Count = model.Count;
                context.SaveChanges();
            }
        }

        public void Delete(MaterialBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Material element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Materials.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<MaterialViewModel> Read(MaterialBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                return context.Materials
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new MaterialViewModel
                {
                    Id = rec.Id,
                    MaterialName = rec.MaterialName,
                    Count = rec.Count
                })
                .ToList();
            }
        }
    }
}

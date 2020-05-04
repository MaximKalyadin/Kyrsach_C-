using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureDataBase.Models;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FactoryFurnitureDataBase.Implements
{
    public class FurnitureLogic : IFurnitureLogic
    {
        public void CreateOrUpdate(FurnitureBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Furniture element = context.Furnitures.FirstOrDefault(rec => rec.FurnitureName == model.FurnitureName && rec.Id != model.Id);
                        if (model.Id.HasValue)
                        {
                            element = context.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Furniture();
                            context.Furnitures.Add(element);
                        }
                        element.FurnitureName = model.FurnitureName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var furniturematerial = context.FurnitureMaterials.Where(rec => rec.FurnitureId == model.Id.Value).ToList();
                            context.FurnitureMaterials.RemoveRange(furniturematerial.Where(rec => !model.FurnitureMaterials.ContainsKey(rec.MaterialId)).ToList());
                            context.SaveChanges();
                            foreach (var updateMaterial in furniturematerial)
                            {
                                updateMaterial.Count = model.FurnitureMaterials[updateMaterial.MaterialId].Item2;
                                model.FurnitureMaterials.Remove(updateMaterial.MaterialId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.FurnitureMaterials)
                        {
                            context.FurnitureMaterials.Add(new FurnitureMaterial
                            {
                                FurnitureId = element.Id,
                                MaterialId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(FurnitureBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.FurnitureMaterials.RemoveRange(context.FurnitureMaterials.Where(rec => rec.FurnitureId == model.Id));
                        Furniture element = context.Furnitures.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Furnitures.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<FurnitureViewModel> Read(FurnitureBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                return context.Furnitures
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new FurnitureViewModel
                {
                    Id = rec.Id,
                    FurnitureName = rec.FurnitureName,
                    Price = rec.Price,
                    FurnitureMaterials = context.FurnitureMaterials
                .Include(recPC => recPC.Material)
                .Where(recPC => recPC.FurnitureId == rec.Id)
                .ToDictionary(recPC => recPC.MaterialId, recPC =>
                (recPC.Material?.MaterialName, recPC.Count))
                })
                .ToList();
            }
        }
    }
}

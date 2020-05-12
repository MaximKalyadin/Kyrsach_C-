using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FactoryFurnitureDataBase.Models;

namespace FactoryFurnitureDataBase.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Request element = context.Requests.FirstOrDefault(rec => rec.RequestName == model.RequestName && rec.Id != model.Id);
                        if (model.Id.HasValue)
                        {
                            element = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Request();
                            context.Requests.Add(element);
                        }
                        element.RequestName = model.RequestName;
                        element.DataCreate = model.DataCreate;
                        context.SaveChanges();


                        if (model.Id.HasValue)
                        {
                            var reqmat = context.RequestMaterials.Where(rec => rec.RequestId == model.Id.Value).ToList();
                            context.RequestMaterials.RemoveRange(reqmat.Where(rec => !model.RequestMaterials.ContainsKey(rec.MaterialId)).ToList());
                            context.SaveChanges();

                            foreach (var updateMaterial in reqmat)
                            {
                                updateMaterial.Count = model.RequestMaterials[updateMaterial.MaterialId].Item2;
                                model.RequestMaterials.Remove(updateMaterial.MaterialId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.RequestMaterials)
                        {
                            context.RequestMaterials.Add(new RequestMaterial
                            {
                                RequestId = element.Id,
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

        public void Delete(RequestBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RequestMaterials.RemoveRange(context.RequestMaterials.Where(rec => rec.RequestId == model.Id));
                        Request element = context.Requests.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Requests.Remove(element);
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

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                return context.Requests
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    RequestName = rec.RequestName,
                    DataCreate = rec.DataCreate,
                    RequestMaterials = context.RequestMaterials
                .Include(recPC => recPC.Material)
                .Where(recPC => recPC.RequestId == rec.Id)
                .ToDictionary(recPC => recPC.MaterialId, recPC =>
                (recPC.Material?.MaterialName, recPC.Count))
                })
                .ToList();
            }
        }
    }
}

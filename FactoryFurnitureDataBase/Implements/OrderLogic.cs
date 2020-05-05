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
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Order order;
                if (model.Id.HasValue)
                {
                    order = context.Orders.ToList().FirstOrDefault(rec => rec.Id == model.Id);
                    if (order == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    order = new Order();
                    context.Orders.Add(order);
                }
                order.ClientFIO = model.ClientFIO;
                order.ClientId = model.ClientId;
                order.FurnitureId = model.FurnitureId;
                order.Count = model.Count;
                order.Price = model.Price;
                order.DataCreate = model.DataCreate;
                order.DataImplement = model.DataImplement;
                order.Status = model.Status;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
                context.SaveChanges();
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                return context.Orders.Where(rec => model == null || rec.Id == model.Id || model.ClientId == rec.ClientId)
                .Include(ord => ord.Furnitures)
                .Select(rec => new OrderViewModel()
                {
                    Id = rec.Id,
                    FurnitureId = rec.FurnitureId,
                    ClientFIO = rec.ClientFIO,
                    ClientId = rec.ClientId,
                    FurnitureName = context.Furnitures.FirstOrDefault((r) => r.Id == rec.FurnitureId).FurnitureName,
                    Count = rec.Count,
                    DataCreate = rec.DataCreate,
                    DataImplement = rec.DataImplement,
                    Price = rec.Price,
                    Status = rec.Status
                }).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.Enum;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.ViewModel;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IMaterialLogic materialLogic;
        public MainLogic(IOrderLogic orderLogic, IMaterialLogic materialLogic)
        {
            this.orderLogic = orderLogic;
            this.materialLogic = materialLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                FurnitureId = model.FurnitureId,
                Count = model.Count,
                Price = model.Price,
                DataCreate = DateTime.Now,
                ClientId = model.ClientId,
                ClientFIO = model.ClientFIO,
                Status = Status.Start
            });
        }
        public bool FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != Status.Start)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            if ((materialLogic as IMaterialLogic).RemoveMaterials(order.FurnitureId, order.Count))
            {
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    FurnitureId = order.FurnitureId,
                    Count = order.Count,
                    Price = order.Price,
                    DataCreate = order.DataCreate,
                    DataImplement = DateTime.Now,
                    ClientId = order.ClientId,
                    ClientFIO = order.ClientFIO,
                    Status = Status.Finish
                });
                return true;
            }
            return false;
        }
    }
}

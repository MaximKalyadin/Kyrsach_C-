using System;
using System.Collections.Generic;
using System.Text;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.Enum;
using FactoryFurnitureBusinessLogic.BindingModel;

namespace FactoryFurnitureBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        public MainLogic(IOrderLogic orderLogic)
        {
            this.orderLogic = orderLogic;
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
        public void FinishOrder(ChangeStatusBindingModel model)
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
        }

    }
}

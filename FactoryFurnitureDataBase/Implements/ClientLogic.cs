using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;
using FactoryFurnitureDataBase.Models;

namespace FactoryFurnitureDataBase.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Client client;
                if (model.Id.HasValue)
                {
                    client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (client == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    client = new Client();
                    context.Clients.Add(client);
                }
                client.ClientFIO = model.ClientFIO;
                client.Adress = model.Adress;
                client.PhoneNumber = model.PhoneNumber;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new FactoryFurnitureDataBase())
            {
                return context.Clients
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFIO = rec.ClientFIO,
                    Adress = rec.Adress,
                    PhoneNumber = rec.PhoneNumber
                })
                .ToList();
            }
        }
    }
}

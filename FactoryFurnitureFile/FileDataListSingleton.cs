using FactoryFurnitureFile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace FactoryFurnitureFile
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ClientFileName = "Client.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string MaterialFileName = "Material.xml";
        private readonly string FurnitureFileName = "Furniture.xml";
        private readonly string RequestFileName = "Request.xml";
        private readonly string FurnitureMaterialFileName = "FurnitureMaterial.xml";

        public List<Client> Clients { get; set; }
        public List<Order> Orders { get; set; }
        public List<Material> Materials { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<Request> Requests { get; set; }
        public List<FurnitureMaterial> FurnitureMaterials { get; set; }

        private FileDataListSingleton()
        {
            Clients = LoadClients();
            Orders = LoadOrders();
            Materials = LoadMaterials();
            Furnitures = LoadFurnitures();
            Requests = LoadRequests();
            FurnitureMaterials = LoadFurnitureMaterials();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveClients();
            SaveOrders();
            SaveMaterials();
            SaveFurnitures();
            SaveRequests();
            SaveFurnitureMaterials();
        }

        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Adress = elem.Element("Adress").Value,
                        PhoneNumber = Convert.ToInt32(elem.Element("PhoneNumber").Value)
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DataCreate = Convert.ToDateTime(elem.Element("DataCreate").Value),
                        DataImplement = string.IsNullOrEmpty(elem.Element("DataImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DataImplement").Value),
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value)
                    });
                }
            }
            return list;
        }

        private List<Material> LoadMaterials()
        {
            var list = new List<Material>();
            if (File.Exists(MaterialFileName))
            {
                XDocument xDocument = XDocument.Load(MaterialFileName);
                var xElements = xDocument.Root.Elements("Material").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Material
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MaterialName = elem.Element("MaterialName").Value,
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private List<Furniture> LoadFurnitures()
        {
            var list = new List<Furniture>();
            if (File.Exists(FurnitureFileName))
            {
                XDocument xDocument = XDocument.Load(FurnitureFileName);
                var xElements = xDocument.Root.Elements("Furniture").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Furniture
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureName = elem.Element("FurnitureName").Value,
                        Price = Convert.ToInt32(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }

        private List<Request> LoadRequests()
        {
            var list = new List<Request>();
            if (File.Exists(RequestFileName))
            {
                XDocument xDocument = XDocument.Load(RequestFileName);
                var xElements = xDocument.Root.Elements("Request").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Request
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DataCreate = Convert.ToDateTime(elem.Element("DataCreate").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private List<FurnitureMaterial> LoadFurnitureMaterials()
        {
            var list = new List<FurnitureMaterial>();
            if (File.Exists(FurnitureMaterialFileName))
            {
                XDocument xDocument = XDocument.Load(FurnitureMaterialFileName);
                var xElements = xDocument.Root.Elements("FurnitureMaterial").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new FurnitureMaterial
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureId = Convert.ToInt32(elem.Element("FurnitureId").Value),
                        MaterialId = Convert.ToInt32(elem.Element("MaterialId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                        new XAttribute("Id", client.Id),
                        new XAttribute("ClientFIO", client.ClientFIO),
                        new XAttribute("Adress", client.Adress),
                        new XAttribute("PhoneNumber", client.PhoneNumber)

                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveFurnitures()
        {
            if (Furnitures != null)
            {
                var xElement = new XElement("Furnitures");
                foreach (var furniture in Furnitures)
                {
                    xElement.Add(new XElement("Furniture",
                        new XAttribute("Id", furniture.Id),
                        new XAttribute("FurnitureName", furniture.FurnitureName),
                        new XAttribute("Price", furniture.Price)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureFileName);
            }
        }

        private void SaveMaterials()
        {
            if (Materials != null)
            {
                var xElement = new XElement("Materials");
                foreach (var material in Materials)
                {
                    xElement.Add(new XElement("Material",
                        new XAttribute("Id", material.Id),
                        new XAttribute("MaterialName", material.MaterialName),
                        new XAttribute("Count", material.Count)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MaterialFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XAttribute("DataCreate", order.DataCreate),
                        new XAttribute("DataImplement", order.DataImplement),
                        new XAttribute("ClientId", order.ClientId)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveRequests()
        {
            if (Requests != null)
            {
                var xElement = new XElement("Requests");
                foreach (var request in Requests)
                {
                    xElement.Add(new XElement("Request",
                        new XAttribute("Id", request.Id),
                        new XAttribute("DataCreate", request.DataCreate),
                        new XAttribute("Count", request.Count)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(RequestFileName);
            }
        }

        private void SaveFurnitureMaterials()
        {
            if (FurnitureMaterials != null)
            {
                var xElement = new XElement("FurnitureMaterials");
                foreach (var elem in FurnitureMaterials)
                {
                    xElement.Add(new XElement("Request",
                        new XAttribute("Id", elem.Id),
                        new XAttribute("FurnitureId", elem.FurnitureId),
                        new XAttribute("MaterialId", elem.MaterialId),
                        new XAttribute("Count", elem.Count)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureMaterialFileName);
            }
        }
    }
}

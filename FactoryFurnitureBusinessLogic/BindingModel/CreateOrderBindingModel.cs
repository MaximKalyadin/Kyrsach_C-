using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        public int FurnitureId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}

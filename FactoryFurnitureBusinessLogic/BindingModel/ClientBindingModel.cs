using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string ClientFIO { get; set; }
        public string Adress { get; set; }
        public int? PhoneNumber { get; set; }
    }
}

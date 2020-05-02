using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureFile.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
    }
}

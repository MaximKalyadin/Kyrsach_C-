using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FactoryFurnitureBusinessLogic.ViewModel
{
    public class ClientViewModel
    {
        public int? Id { get; set; }
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }
        [DisplayName("Адрес")]
        public string Adress { get; set; }
        [DisplayName("Номер телефона")]
        public int? PhoneNumber { get; set; }
    }
}

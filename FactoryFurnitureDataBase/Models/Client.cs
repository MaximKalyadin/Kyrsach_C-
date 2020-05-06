using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public string Adress { get; set; }
        public int? PhoneNumber { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { set; get; }
    }
}

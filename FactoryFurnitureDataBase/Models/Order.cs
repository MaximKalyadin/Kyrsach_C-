using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using FactoryFurnitureBusinessLogic.Enum;

namespace FactoryFurnitureDataBase.Models
{
    public class Order
    {
        public int? Id { get; set; }
        [Required]
        public DateTime DataCreate { get; set; }
        public DateTime? DataImplement { get; set; }
        [Required]
        public int ClientId { get; set; }
        public int FurnitureId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Client Client { set; get; }
        public virtual Furniture Furnitures { get; set; }
    }
}

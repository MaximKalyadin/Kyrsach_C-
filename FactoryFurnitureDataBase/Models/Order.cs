﻿using System;
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
        public int ClientId { get; set; }
        public int FurnitureId { get; set; }
        public string ClientFIO { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
        [Required]
        public int Count { get; set; }
        [ForeignKey("OrderId")]
        public List<Client> Client { get; set; }
        [ForeignKey("OrderId")]
        public List<Furniture> Furniture { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class Material
    {
        public int? Id { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Count { get; set; }
        [ForeignKey("MaterialId")]
        public List<Furniture> Furniture { get; set; }
        [ForeignKey("MaterialId")]
        public List<Request> Request { get; set; }
    }
}

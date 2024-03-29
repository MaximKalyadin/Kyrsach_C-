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
        public int Count { get; set; }
        [ForeignKey("MaterialId")]
        public virtual List<FurnitureMaterial> FurnitureMaterial { get; set; }
        [ForeignKey("MaterialId")]
        public virtual List<RequestMaterial> RequestMaterial { get; set; }
    }
}

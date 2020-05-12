using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class RequestMaterial
    {
        public int Id { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Request Request { get; set; }
        public virtual Material Material { get; set; }
    }
}

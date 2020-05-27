using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FactoryFurnitureDataBase.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        public int Identification_Number { get; set; }
    }
}

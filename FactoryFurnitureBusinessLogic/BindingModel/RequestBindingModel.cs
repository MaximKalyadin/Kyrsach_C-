﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.BindingModel
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public string RequestName { get; set; }
        public DateTime DataCreate { get; set; }
        public Dictionary<int, (string, int)> RequestMaterials { get; set; }
    }
}

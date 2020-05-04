﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryFurnitureBusinessLogic.HelperModel
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<PizzaViewModel> Pizzas { get; set; }
    }
}
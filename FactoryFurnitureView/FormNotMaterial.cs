﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FactoryFurnitureView
{
    public partial class FormNotMaterial : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public FormNotMaterial()
        {
            InitializeComponent();
        }
    }
}

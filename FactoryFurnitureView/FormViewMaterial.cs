using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryFurnitureBusinessLogic.BindingModel;
using Unity;
using FactoryFurnitureBusinessLogic.Interface;

namespace FactoryFurnitureView
{
    public partial class FormViewMaterial : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IMaterialLogic logic;
        public FormViewMaterial(IMaterialLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddMaterialToFurniture>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //LoadData();
            }
        }
    }
}

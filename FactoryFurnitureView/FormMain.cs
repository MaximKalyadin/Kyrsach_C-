using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.BusinessLogic;

namespace FactoryFurnitureView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic reportLogic;
        public FormMain(MainLogic logic, IOrderLogic orderLogic, ReportLogic reportLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.reportLogic = reportLogic;
        }

        private void создатьМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormViewMaterial>();
            form.ShowDialog();
        }
    }
}

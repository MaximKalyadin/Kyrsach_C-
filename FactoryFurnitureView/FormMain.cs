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

        private void создатьКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormViewClient>();
            form.ShowDialog();
        }

        private void создатьМебельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormViewFurniture>();
            form.ShowDialog();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}

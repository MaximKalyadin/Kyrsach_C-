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

        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[8].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                dataGridView.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    if (!logic.FinishOrder(new ChangeStatusBindingModel { OrderId = id }))
                    {
                        var form = Container.Resolve<FormNotMaterial>();
                        form.ShowDialog();
                        LoadData();
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void заявкиНаПополнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormViewRequest>();
            form.ShowDialog();
        }

        private void отчетПоМатериаламToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFulllReport>();
            form.ShowDialog();
        }
    }
}

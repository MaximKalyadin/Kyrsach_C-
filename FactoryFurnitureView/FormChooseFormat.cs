using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.BusinessLogic;
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

namespace FactoryFurnitureView
{
    public partial class FormChooseFormat : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public Dictionary<int, (string, int)> material = new Dictionary<int, (string, int)>();
        public FormChooseFormat(ReportLogic logic)
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("MaterialName", "Материал");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = logic;
        }

        private void LoadData()
        {
            try
            {
                if (material != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in material)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
                        pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddmaterial_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddMaterialToReport>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (material.ContainsKey(form.Id))
                {
                    material[form.Id] = (form.MaterialName, form.Count);
                }
                else
                {
                    material.Add(form.Id, (form.MaterialName, form.Count));
                }
                LoadData();
            }
        }

        private void FormChooseFormat_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveMaterialToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }, material);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

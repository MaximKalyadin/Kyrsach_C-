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
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.ViewModel;

namespace FactoryFurnitureView
{
    public partial class FormAddMaterialToFurniture : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxName.SelectedValue); }
            set { comboBoxName.SelectedValue = value; }
        }
        public string MaterialName { get { return comboBoxName.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormAddMaterialToFurniture(IMaterialLogic logic)
        {
            InitializeComponent();
            List<MaterialViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxName.DisplayMember = "MaterialName";
                comboBoxName.ValueMember = "Id";
                comboBoxName.DataSource = list;
                comboBoxName.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxName.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

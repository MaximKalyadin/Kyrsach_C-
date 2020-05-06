using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.BusinessLogic;
using FactoryFurnitureBusinessLogic.Interface;
using FactoryFurnitureBusinessLogic.ViewModel;
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
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IFurnitureLogic logicP;
        private readonly MainLogic logicM;
        private readonly IClientLogic logicC;
        public FormCreateOrder(IFurnitureLogic logicP, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxFurniture.SelectedValue == null)
            {
                MessageBox.Show("Выберите пиццу", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    FurnitureId = Convert.ToInt32(comboBoxFurniture.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ClientId = (comboBoxClient.SelectedItem as ClientViewModel).Id,
                    ClientFIO = (comboBoxClient.SelectedItem as ClientViewModel).ClientFIO
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listP = logicP.Read(null);
                if (listP != null)
                {
                    comboBoxFurniture.DisplayMember = "FurnitureName";
                    comboBoxFurniture.ValueMember = "Id";
                    comboBoxFurniture.DataSource = listP;
                    comboBoxFurniture.SelectedItem = null;
                }
                var listClients = logicC.Read(null);
                if (listClients != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.DataSource = listClients;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CalcSum()
        {
            if (comboBoxFurniture.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxFurniture.SelectedValue);
                    FurnitureViewModel product = logicP.Read(new FurnitureBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxPrice.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxFurniture_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}

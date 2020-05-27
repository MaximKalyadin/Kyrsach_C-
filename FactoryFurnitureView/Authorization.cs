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
using FactoryFurnitureDataBase.Implements;
using FactoryFurnitureDataBase.Models;

namespace FactoryFurnitureView
{
    public partial class Authorization : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly AuthorizationLogic logic;
        public Authorization(AuthorizationLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff()
            {
                Identification_Number = Convert.ToInt32(textBoxNumber.Text)
            };

            if (logic.Input(staff))
            {
                var form = Container.Resolve<FormMain>();
                form.ShowDialog();
            } 
            else
            {
                MessageBox.Show("Нет такого сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

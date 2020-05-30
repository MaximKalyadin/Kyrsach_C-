using FactoryFurnitureBusinessLogic.BindingModel;
using FactoryFurnitureBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FactoryFurnitureView
{
    public partial class FormFulllReport : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic reportLogic;
        private readonly MailLogic mailLogic;
        public FormFulllReport(ReportLogic reportLogic, MailLogic mailLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
            this.mailLogic = mailLogic;
        }

        private void buttonSendToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SaveToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });
                        mailLogic.SendMassege(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }, textBoxEmail.Text, textBoxTeg.Text, "Полный отчет по заявкам и заказанной мебели");
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

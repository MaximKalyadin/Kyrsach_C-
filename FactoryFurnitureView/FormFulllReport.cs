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
        public FormFulllReport(ReportLogic reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
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
                        SendMassege(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
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

        public void SendMassege(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("kalyadin.maxim@gmail.com");
            MailAddress to = new MailAddress(textBoxEmail.Text);
            MailMessage mes = new MailMessage(from, to);
            mes.Subject = textBoxTeg.Text;
            mes.Body = "Полный отчет по заявкам и заказанной мебели";
            mes.Attachments.Add(new Attachment(model.FileName));
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("kalyadin.maxim@gmail.com", "42MAKS01253");
            client.EnableSsl = true;
            client.Send(mes);

        }
    }
}

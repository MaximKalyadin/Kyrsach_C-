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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FactoryFurnitureView
{
    public partial class FormCreateRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IRequestLogic logic;
        private readonly ReportLogic reportLogic;
        private readonly IMaterialLogic materialLogic;
        private int? id;
        private Dictionary<int, (string, int)> material; //= new Dictionary<int, (string, int)>();
        public FormCreateRequest(IRequestLogic logic, ReportLogic reportLogic, IMaterialLogic materialLogic)
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("RequestName", "Заявка");
            dataGridView.Columns.Add("DataCreate", "Дата формирования");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = logic;
            this.reportLogic = reportLogic;
            this.materialLogic = materialLogic;
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddMaterialToRequest>();
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

        private void buttonSaveToWord_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveMaterialToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    }, material);
                    SendMassege(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SaveMaterialToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }, material);
                        SendMassege(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (material == null || material.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new RequestBindingModel
                {
                    Id = id,
                    RequestName = textBoxName.Text,
                    DataCreate = DateTime.Now,
                    RequestMaterials = material
                });
                materialLogic.AddMaterial(material);
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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

        private void FormCreateRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = logic.Read(new RequestBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RequestName;
                        material = view.RequestMaterials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                material = new Dictionary<int, (string, int)>();
            }
        }

        public void SendMassege(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("kalyadin.maxim@gmail.com");
            MailAddress to = new MailAddress(textBoxEmail.Text);
            MailMessage mes = new MailMessage(from, to);
            mes.Subject = textBoxName.Text;
            mes.Body = "Заявка на заказ материалов";
            mes.Attachments.Add(new Attachment(model.FileName));
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("kalyadin.maxim@gmail.com", "42MAKS01253");
            client.EnableSsl = true;
            client.Send(mes);

        }
    }
}

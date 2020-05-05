namespace FactoryFurnitureView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.дополнительноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьМебельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьМатериалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(968, 462);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(991, 46);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(219, 36);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "Создать заказ";
            this.buttonCreate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(991, 181);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(218, 36);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Удалить заказ";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дополнительноToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1227, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // дополнительноToolStripMenuItem
            // 
            this.дополнительноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКлиентовToolStripMenuItem,
            this.создатьМебельToolStripMenuItem,
            this.создатьМатериалыToolStripMenuItem});
            this.дополнительноToolStripMenuItem.Name = "дополнительноToolStripMenuItem";
            this.дополнительноToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.дополнительноToolStripMenuItem.Text = "Дополнительно";
            // 
            // создатьКлиентовToolStripMenuItem
            // 
            this.создатьКлиентовToolStripMenuItem.Name = "создатьКлиентовToolStripMenuItem";
            this.создатьКлиентовToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.создатьКлиентовToolStripMenuItem.Text = "Создать клиентов";
            // 
            // создатьМебельToolStripMenuItem
            // 
            this.создатьМебельToolStripMenuItem.Name = "создатьМебельToolStripMenuItem";
            this.создатьМебельToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.создатьМебельToolStripMenuItem.Text = "Создать мебель";
            // 
            // создатьМатериалыToolStripMenuItem
            // 
            this.создатьМатериалыToolStripMenuItem.Name = "создатьМатериалыToolStripMenuItem";
            this.создатьМатериалыToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.создатьМатериалыToolStripMenuItem.Text = "Создать материалы";
            this.создатьМатериалыToolStripMenuItem.Click += new System.EventHandler(this.создатьМатериалыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docФайлToolStripMenuItem,
            this.excelФайлToolStripMenuItem,
            this.pdfФайлToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты ";
            // 
            // docФайлToolStripMenuItem
            // 
            this.docФайлToolStripMenuItem.Name = "docФайлToolStripMenuItem";
            this.docФайлToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.docФайлToolStripMenuItem.Text = "Doc файл";
            // 
            // excelФайлToolStripMenuItem
            // 
            this.excelФайлToolStripMenuItem.Name = "excelФайлToolStripMenuItem";
            this.excelФайлToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.excelФайлToolStripMenuItem.Text = "Excel файл";
            // 
            // pdfФайлToolStripMenuItem
            // 
            this.pdfФайлToolStripMenuItem.Name = "pdfФайлToolStripMenuItem";
            this.pdfФайлToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.pdfФайлToolStripMenuItem.Text = "Pdf файл";
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(991, 114);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(218, 36);
            this.buttonFinish.TabIndex = 4;
            this.buttonFinish.Text = "Завершить заказ";
            this.buttonFinish.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 494);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem дополнительноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьМебельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьМатериалыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pdfФайлToolStripMenuItem;
        private System.Windows.Forms.Button buttonFinish;
    }
}
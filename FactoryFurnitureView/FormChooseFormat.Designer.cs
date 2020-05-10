namespace FactoryFurnitureView
{
    partial class FormChooseFormat
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
            this.buttonAddmaterial = new System.Windows.Forms.Button();
            this.buttonWord = new System.Windows.Forms.Button();
            this.buttonSendToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(570, 405);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonAddmaterial
            // 
            this.buttonAddmaterial.Location = new System.Drawing.Point(587, 12);
            this.buttonAddmaterial.Name = "buttonAddmaterial";
            this.buttonAddmaterial.Size = new System.Drawing.Size(147, 47);
            this.buttonAddmaterial.TabIndex = 1;
            this.buttonAddmaterial.Text = "Добавить материалы ";
            this.buttonAddmaterial.UseVisualStyleBackColor = true;
            this.buttonAddmaterial.Click += new System.EventHandler(this.buttonAddmaterial_Click);
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(587, 76);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(147, 47);
            this.buttonWord.TabIndex = 2;
            this.buttonWord.Text = "Отправить в Word";
            this.buttonWord.UseVisualStyleBackColor = true;
            // 
            // buttonSendToExcel
            // 
            this.buttonSendToExcel.Location = new System.Drawing.Point(587, 140);
            this.buttonSendToExcel.Name = "buttonSendToExcel";
            this.buttonSendToExcel.Size = new System.Drawing.Size(147, 47);
            this.buttonSendToExcel.TabIndex = 3;
            this.buttonSendToExcel.Text = "Отправить в Excel";
            this.buttonSendToExcel.UseVisualStyleBackColor = true;
            this.buttonSendToExcel.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormChooseFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 408);
            this.Controls.Add(this.buttonSendToExcel);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.buttonAddmaterial);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormChooseFormat";
            this.Text = "Выбор формата";
            this.Load += new System.EventHandler(this.FormChooseFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAddmaterial;
        private System.Windows.Forms.Button buttonWord;
        private System.Windows.Forms.Button buttonSendToExcel;
    }
}
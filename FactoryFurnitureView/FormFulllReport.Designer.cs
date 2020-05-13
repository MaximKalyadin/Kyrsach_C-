namespace FactoryFurnitureView
{
    partial class FormFulllReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxTeg = new System.Windows.Forms.TextBox();
            this.buttonSendToPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Почта отправителя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тег письма";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(156, 9);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(373, 22);
            this.textBoxEmail.TabIndex = 2;
            // 
            // textBoxTeg
            // 
            this.textBoxTeg.Location = new System.Drawing.Point(156, 38);
            this.textBoxTeg.Name = "textBoxTeg";
            this.textBoxTeg.Size = new System.Drawing.Size(373, 22);
            this.textBoxTeg.TabIndex = 3;
            // 
            // buttonSendToPdf
            // 
            this.buttonSendToPdf.Location = new System.Drawing.Point(358, 66);
            this.buttonSendToPdf.Name = "buttonSendToPdf";
            this.buttonSendToPdf.Size = new System.Drawing.Size(171, 35);
            this.buttonSendToPdf.TabIndex = 4;
            this.buttonSendToPdf.Text = "Отправить в PDF";
            this.buttonSendToPdf.UseVisualStyleBackColor = true;
            this.buttonSendToPdf.Click += new System.EventHandler(this.buttonSendToPdf_Click);
            // 
            // FormFulllReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 116);
            this.Controls.Add(this.buttonSendToPdf);
            this.Controls.Add(this.textBoxTeg);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormFulllReport";
            this.Text = "FormFulllReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxTeg;
        private System.Windows.Forms.Button buttonSendToPdf;
    }
}
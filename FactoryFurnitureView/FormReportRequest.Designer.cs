namespace FactoryFurnitureView
{
    partial class FormReportRequest
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
            this.buttonFormirovat = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFormirovat
            // 
            this.buttonFormirovat.Location = new System.Drawing.Point(12, 12);
            this.buttonFormirovat.Name = "buttonFormirovat";
            this.buttonFormirovat.Size = new System.Drawing.Size(160, 47);
            this.buttonFormirovat.TabIndex = 0;
            this.buttonFormirovat.Text = "Сформировать";
            this.buttonFormirovat.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(189, 12);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(160, 47);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // FormReportRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 582);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonFormirovat);
            this.Name = "FormReportRequest";
            this.Text = "FormReportRequest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFormirovat;
        private System.Windows.Forms.Button buttonSend;
    }
}
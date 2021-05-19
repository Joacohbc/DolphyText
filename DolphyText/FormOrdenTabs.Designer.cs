namespace DolphyText
{
    partial class FormOrdenTabs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdenTabs));
            this.cmbPrimerPage = new System.Windows.Forms.ComboBox();
            this.cmbSegudaPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPrimerPage
            // 
            this.cmbPrimerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrimerPage.FormattingEnabled = true;
            this.cmbPrimerPage.Location = new System.Drawing.Point(12, 12);
            this.cmbPrimerPage.Name = "cmbPrimerPage";
            this.cmbPrimerPage.Size = new System.Drawing.Size(270, 21);
            this.cmbPrimerPage.TabIndex = 0;
            // 
            // cmbSegudaPage
            // 
            this.cmbSegudaPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSegudaPage.FormattingEnabled = true;
            this.cmbSegudaPage.Location = new System.Drawing.Point(12, 39);
            this.cmbSegudaPage.Name = "cmbSegudaPage";
            this.cmbSegudaPage.Size = new System.Drawing.Size(270, 21);
            this.cmbSegudaPage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cambiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormOrdenTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 101);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSegudaPage);
            this.Controls.Add(this.cmbPrimerPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOrdenTabs";
            this.Text = "Cambiar orden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrimerPage;
        private System.Windows.Forms.ComboBox cmbSegudaPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
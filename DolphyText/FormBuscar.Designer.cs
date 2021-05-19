namespace DolphyText
{
    partial class FormBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuscar));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtRemplazar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemplazar = new System.Windows.Forms.Button();
            this.btnRemplazarTodo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkDistinguir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(78, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(207, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(18, 75);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(133, 22);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtRemplazar
            // 
            this.txtRemplazar.Location = new System.Drawing.Point(78, 38);
            this.txtRemplazar.Name = "txtRemplazar";
            this.txtRemplazar.Size = new System.Drawing.Size(207, 20);
            this.txtRemplazar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Remplazar";
            // 
            // btnRemplazar
            // 
            this.btnRemplazar.Location = new System.Drawing.Point(155, 75);
            this.btnRemplazar.Name = "btnRemplazar";
            this.btnRemplazar.Size = new System.Drawing.Size(133, 22);
            this.btnRemplazar.TabIndex = 6;
            this.btnRemplazar.Text = "Buscar y Remplazar";
            this.btnRemplazar.UseVisualStyleBackColor = true;
            this.btnRemplazar.Click += new System.EventHandler(this.btnRemplazar_Click);
            // 
            // btnRemplazarTodo
            // 
            this.btnRemplazarTodo.Location = new System.Drawing.Point(18, 103);
            this.btnRemplazarTodo.Name = "btnRemplazarTodo";
            this.btnRemplazarTodo.Size = new System.Drawing.Size(133, 22);
            this.btnRemplazarTodo.TabIndex = 7;
            this.btnRemplazarTodo.Text = "Remplazar todo";
            this.btnRemplazarTodo.UseVisualStyleBackColor = true;
            this.btnRemplazarTodo.Click += new System.EventHandler(this.btnRemplazarTodo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(157, 103);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(133, 22);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // chkDistinguir
            // 
            this.chkDistinguir.AutoSize = true;
            this.chkDistinguir.Location = new System.Drawing.Point(18, 131);
            this.chkDistinguir.Name = "chkDistinguir";
            this.chkDistinguir.Size = new System.Drawing.Size(127, 17);
            this.chkDistinguir.TabIndex = 9;
            this.chkDistinguir.Text = "Distinguir mayusculas";
            this.chkDistinguir.UseVisualStyleBackColor = true;
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 160);
            this.Controls.Add(this.chkDistinguir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRemplazarTodo);
            this.Controls.Add(this.btnRemplazar);
            this.Controls.Add(this.txtRemplazar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBuscar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtRemplazar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemplazar;
        private System.Windows.Forms.Button btnRemplazarTodo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.CheckBox chkDistinguir;
    }
}
﻿namespace DolphyNotes
{
    partial class FormNotas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotas));
            this.lblCompletar = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblCompletar
            // 
            this.lblCompletar.AutoSize = true;
            this.lblCompletar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCompletar.Location = new System.Drawing.Point(0, 234);
            this.lblCompletar.Name = "lblCompletar";
            this.lblCompletar.Size = new System.Drawing.Size(54, 13);
            this.lblCompletar.TabIndex = 1;
            this.lblCompletar.Text = "Completar";
            this.lblCompletar.Visible = false;
            // 
            // txtNotas
            // 
            this.txtNotas.AllowDrop = true;
            this.txtNotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(0, 0);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(253, 247);
            this.txtNotas.TabIndex = 0;
            this.txtNotas.Text = "";
            this.txtNotas.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtNotas_DragDrop);
            this.txtNotas.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtNotas_DragEnter);
            this.txtNotas.SelectionChanged += new System.EventHandler(this.txtNotas_SelectionChanged);
            this.txtNotas.TextChanged += new System.EventHandler(this.txtNotas_TextChanged);
            this.txtNotas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotas_KeyDown);
            this.txtNotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevo_KeyPress);
            // 
            // FormNotas
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 247);
            this.Controls.Add(this.lblCompletar);
            this.Controls.Add(this.txtNotas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 40);
            this.Name = "FormNotas";
            this.ShowIcon = false;
            this.Text = "DolphyNotes";
            this.Load += new System.EventHandler(this.FormNotas_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormNotas_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormNotas_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompletar;
        private System.Windows.Forms.RichTextBox txtNotas;
    }
}


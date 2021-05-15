namespace DolphyText
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enFrenteSiempreOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirEscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarFuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDeFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atajosTecladoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.edicionToolStripMenuItem,
            this.formatoToolStripMenuItem,
            this.atajosTecladoToolStripMenuItem,
            this.resultadoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem1,
            this.guardarComoToolStripMenuItem,
            this.nuevaVentanaToolStripMenuItem,
            this.mostrarRutaToolStripMenuItem,
            this.enFrenteSiempreOFFToolStripMenuItem,
            this.toolStripSeparator2,
            this.salirEscToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.abrirToolStripMenuItem.Text = "Abrir                    Ctrl+0";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.guardarToolStripMenuItem1.Text = "Guardar               Ctrl+S";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // nuevaVentanaToolStripMenuItem
            // 
            this.nuevaVentanaToolStripMenuItem.Name = "nuevaVentanaToolStripMenuItem";
            this.nuevaVentanaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.nuevaVentanaToolStripMenuItem.Text = "Nueva ventana  Ctrl+N";
            this.nuevaVentanaToolStripMenuItem.Click += new System.EventHandler(this.nuevaVentanaToolStripMenuItem_Click);
            // 
            // mostrarRutaToolStripMenuItem
            // 
            this.mostrarRutaToolStripMenuItem.Name = "mostrarRutaToolStripMenuItem";
            this.mostrarRutaToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.mostrarRutaToolStripMenuItem.Text = "Mostrar ruta(No)";
            this.mostrarRutaToolStripMenuItem.Click += new System.EventHandler(this.mostrarRutaToolStripMenuItem_Click);
            // 
            // enFrenteSiempreOFFToolStripMenuItem
            // 
            this.enFrenteSiempreOFFToolStripMenuItem.Name = "enFrenteSiempreOFFToolStripMenuItem";
            this.enFrenteSiempreOFFToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.enFrenteSiempreOFFToolStripMenuItem.Text = "Siempre en Frente(No)";
            this.enFrenteSiempreOFFToolStripMenuItem.Click += new System.EventHandler(this.enFrenteSiempreOFFToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // salirEscToolStripMenuItem
            // 
            this.salirEscToolStripMenuItem.Name = "salirEscToolStripMenuItem";
            this.salirEscToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.salirEscToolStripMenuItem.Text = "Salir                      Esc";
            this.salirEscToolStripMenuItem.Click += new System.EventHandler(this.salirEscToolStripMenuItem_Click);
            // 
            // edicionToolStripMenuItem
            // 
            this.edicionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarToolStripMenuItem});
            this.edicionToolStripMenuItem.Name = "edicionToolStripMenuItem";
            this.edicionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.edicionToolStripMenuItem.Text = "Edicion";
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.buscarToolStripMenuItem.Text = "Buscar y Remplazar   Ctrl+F";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // formatoToolStripMenuItem
            // 
            this.formatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarFuenteToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.colorDeFondoToolStripMenuItem});
            this.formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            this.formatoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.formatoToolStripMenuItem.Text = "Formato";
            // 
            // cambiarFuenteToolStripMenuItem
            // 
            this.cambiarFuenteToolStripMenuItem.Name = "cambiarFuenteToolStripMenuItem";
            this.cambiarFuenteToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.cambiarFuenteToolStripMenuItem.Text = "Fuente del texo         Ctrl+Shift+F";
            this.cambiarFuenteToolStripMenuItem.Click += new System.EventHandler(this.cambiarFuenteToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.colorToolStripMenuItem.Text = "Color  del texto         Ctrl+Shift+C";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // colorDeFondoToolStripMenuItem
            // 
            this.colorDeFondoToolStripMenuItem.Name = "colorDeFondoToolStripMenuItem";
            this.colorDeFondoToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.colorDeFondoToolStripMenuItem.Text = "Color de Fondo         Ctrl+Shift+B";
            this.colorDeFondoToolStripMenuItem.Click += new System.EventHandler(this.colorDeFondoToolStripMenuItem_Click);
            // 
            // atajosTecladoToolStripMenuItem
            // 
            this.atajosTecladoToolStripMenuItem.Name = "atajosTecladoToolStripMenuItem";
            this.atajosTecladoToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.atajosTecladoToolStripMenuItem.Text = "Atajos Teclado";
            this.atajosTecladoToolStripMenuItem.Click += new System.EventHandler(this.atajosTecladoToolStripMenuItem_Click);
            // 
            // resultadoToolStripMenuItem
            // 
            this.resultadoToolStripMenuItem.Name = "resultadoToolStripMenuItem";
            this.resultadoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.resultadoToolStripMenuItem.Text = "Resultado: ";
            this.resultadoToolStripMenuItem.Visible = false;
            this.resultadoToolStripMenuItem.Click += new System.EventHandler(this.resultadoToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(634, 426);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.DoubleClick += new System.EventHandler(this.tabControl_DoubleClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DolphyText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edicionToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.ToolStripMenuItem nuevaVentanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarFuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorDeFondoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enFrenteSiempreOFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarRutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atajosTecladoToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem salirEscToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }

}


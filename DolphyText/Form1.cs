using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolphyText
{
    public partial class Form1 : Form
    {
        //Rutas
        public String rutaCarpetaApp = "C:\\DolphyText";
        public String rutaTabsGuardadas = "C:\\DolphyText\\tabs.txt";
        //public String rutaConfig = "C:\\DolphyText\\configuraciones.txt";

        //Configuraciones
        private bool guardarVentanas = true;
        
        //Metodos
        public Boolean validarTabs()
        {
            if (tabControl.TabCount > 0 && tabControl.SelectedIndex >= 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Para hacer esta accion necesita seleccionar una ventana(o minimo tener una ventana abierta)", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }///

        public Boolean validarTabsSinAdv()
        {
            if (tabControl.TabCount > 0 && tabControl.SelectedIndex >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }///

        public void abrirArchivos(String path)
        {
            try
            {
                RichTextBox txtNuevo = nuevoTxtBox();

                //Declaro el lector
                StreamReader sr = new StreamReader(path);
                bool valido = true;
                if (Path.GetExtension(path) == ".rtf")
                {
                    //Cargo el RTF en el RichTextBox con texto con estilo
                    txtNuevo.LoadFile(path);
                }
                else if (Path.GetExtension(path) == ".txt")
                {
                    //Cargo el RTF en el RichTextBox con texto simple
                    txtNuevo.Text = sr.ReadToEnd();
                }
                else
                {
                    MessageBox.Show("Extension no soportada del archivo " + Path.GetFileName(path), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valido = false;
                }

                sr.Close();//Para que deje de usar el archivo

                if (valido)//Para que no cree un tab vacio
                {
                    //Pongo la ruta
                    Label ruta = nuevoLabel();
                    ruta.Text = path;

                    TabPage nuevaTab = new TabPage(Path.GetFileName(path));
                    nuevaTab.Name = "Nueva ventana " + (tabControl.TabCount + 1).ToString();

                    //Agrego todo al Tab
                    nuevaTab.Controls.Add(ruta);
                    nuevaTab.Controls.Add(txtNuevo);
                    tabControl.TabPages.Add(nuevaTab);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }

        public bool mostrarOpciones(String texto, String titulo, MessageBoxIcon icono, MessageBoxDefaultButton botonesDefault)
        {
            DialogResult result = MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, icono, botonesDefault);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void quitarAsterisco()
        {
            if (tabControl.SelectedTab.Text.LastIndexOf('*') == tabControl.SelectedTab.Text.Length - 1)
            {
                tabControl.SelectedTab.Text = tabControl.SelectedTab.Text.Substring(0, tabControl.SelectedTab.Text.Length - 1);
            }
        }
        
        //Generador de rtxtBox
        public RichTextBox nuevoTxtBox()
        {
            RichTextBox txtEjemplo = new RichTextBox();
            txtEjemplo.Name = "txtNuevo";
            txtEjemplo.Dock = System.Windows.Forms.DockStyle.Fill;
            txtEjemplo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtEjemplo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress);
            txtEjemplo.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_KeyDown);
            txtEjemplo.SelectionChanged += new System.EventHandler(textBox_SelectionChanged);
            txtEjemplo.TextChanged += new System.EventHandler(textBox_textChanged);
            
            //Para poder dropear los archivos en el RichBox
            txtEjemplo.AllowDrop = true;
            txtEjemplo.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            txtEjemplo.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);

            return txtEjemplo;
        }///

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validarTabsSinAdv())
            {

                //Sacado de https://www.c-sharpcorner.com/UploadFile/f5a10c/auto-complete-brackets-in-C-Sharpvb-net877/
                RichTextBox txtEjemplo = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                String s = e.KeyChar.ToString();
                int sel = txtEjemplo.SelectionStart;
                switch (s)
                {
                    case "(":
                        txtEjemplo.SelectedText = "()";
                        e.Handled = true;//Para que no se duplique el primer caracter "(", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "{":
                        txtEjemplo.SelectedText = "{}";
                        e.Handled = true;//Para que no se duplique el primer caracter "{", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "[":
                        txtEjemplo.SelectedText = "[]";
                        e.Handled = true;//Para que no se duplique el primer caracter "[", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "'":
                        txtEjemplo.SelectedText = "''";
                        e.Handled = true;//Para que no se duplique el primer caracter "'", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "\"":
                        txtEjemplo.SelectedText = "\"\"";
                        e.Handled = true;//Para que no se duplique el primer caracter ", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "?":
                        txtEjemplo.SelectedText = "¿?";
                        e.Handled = true;//Para que no se duplique el primer caracter "?", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                    case "!":
                        txtEjemplo.SelectedText = "¡!";
                        e.Handled = true;//Para que no se duplique el primer caracter "!", como que anula lo que se inserto
                        txtEjemplo.SelectionStart = sel + 1;
                        break;

                }
            }
        }///

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (validarTabsSinAdv())
            {
                RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                //Poner negrita
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.B))
                {
                    Font vieja = txtTexto.SelectionFont;
                    if (!txtTexto.SelectionFont.Bold)
                    {

                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style | FontStyle.Bold);
                    }
                    else
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style & ~FontStyle.Bold);
                    }

                }
                //Poner Subrayado
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.U))
                {
                    Font vieja = txtTexto.SelectionFont;
                    if (!txtTexto.SelectionFont.Underline)
                    {

                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style | FontStyle.Underline);
                    }
                    else
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style & ~FontStyle.Underline);
                    }
                }
                //Poner Italica
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.K))
                {
                    Font vieja = txtTexto.SelectionFont;
                    if (!txtTexto.SelectionFont.Italic)
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style | FontStyle.Italic);
                    }
                    else
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style & ~FontStyle.Italic);
                    }
                }
                //Poner Rayado
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.T))//el Contro+R ya hacia algo :/
                {
                    Font vieja = txtTexto.SelectionFont;
                    if (!txtTexto.SelectionFont.Strikeout)
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style | FontStyle.Strikeout);
                    }
                    else
                    {
                        txtTexto.SelectionFont = new Font(txtTexto.Font, vieja.Style & ~FontStyle.Strikeout);
                    }
                }
                //Poner Mayusculas en Minusculas en viciversa
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.M))
                {
                    if (!String.IsNullOrEmpty(txtTexto.SelectedText))
                    {
                        String textoNuevo = "";
                        if (Char.IsLower(txtTexto.SelectedText[0]))
                        {
                            foreach (char c in txtTexto.SelectedText)
                            {
                                textoNuevo += Char.ToUpper(c);
                            }
                            txtTexto.SelectedText = textoNuevo;
                        }
                        else
                        {
                            foreach (char c in txtTexto.SelectedText)
                            {
                                textoNuevo += Char.ToLower(c);
                            }
                            txtTexto.SelectedText = textoNuevo;
                        }

                    }

                }
                //Quitar estilos
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Q))
                {
                    txtTexto.SelectionFont = new Font(txtTexto.Font, FontStyle.Regular);
                }
                //Completar
                else if (resultadoToolStripMenuItem.Visible)
                {
                    if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.CapsLock))//El Control+Space cambiaba todo
                    {
                        e.Handled = true;
                        String texto = txtTexto.SelectedText;
                        String op = "";
                        if (texto.Length >= 3)
                        {
                            op = resultadoToolStripMenuItem.Text.Substring(0, 4);
                        }
                        else
                        {
                            op = texto;
                        }

                        if (op == "R = ")
                        {
                            txtTexto.SelectedText = resultadoToolStripMenuItem.Text.Substring(4);
                        }
                        else if (op == "n")
                        {
                            txtTexto.SelectedText = resultadoToolStripMenuItem.Text;
                        }
                        else if (op == "N")
                        {
                            txtTexto.SelectedText = resultadoToolStripMenuItem.Text;
                        }

                    }
                }


            }
        }///

        private void textBox_SelectionChanged(object sender, EventArgs e)
        {

            if (validarTabsSinAdv())
            {

                RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                String texto = txtTexto.SelectedText;
                texto = texto.Replace(" ", String.Empty);
                int i = 0;

                foreach (char c in texto)
                {
                    if (char.IsDigit(c) || c == '+' || c == '-' || c == '/' || c == '*') i++;
                }

                if (i == texto.Length && i >= 3)//Si es minimo una cuenta osae 3+3, 3 digitos minimo
                {
                    //Try para que no crashee en caso de ser un valor invalido
                    try
                    {
                        double resultado = Convert.ToDouble(new DataTable().Compute(texto, null));
                        resultadoToolStripMenuItem.Text = "R = " + resultado.ToString();
                        resultadoToolStripMenuItem.Visible = true;
                    }
                    catch (Exception) { }

                }
                else if (texto == "n")
                {
                    resultadoToolStripMenuItem.Text = "ñ";
                    resultadoToolStripMenuItem.Visible = true;
                }
                else if (texto == "N")
                {
                    resultadoToolStripMenuItem.Text = "Ñ";
                    resultadoToolStripMenuItem.Visible = true;
                }
                else
                {
                    resultadoToolStripMenuItem.Visible = false;
                }

            }

        }///

        private void textBox_textChanged(object sender, EventArgs e)
        {
            if (validarTabsSinAdv())
            {
                if (tabControl.SelectedTab.Text.LastIndexOf('*') != tabControl.SelectedTab.Text.Length - 1)
                {
                    tabControl.SelectedTab.Text += "*";
                }
            }
        }
        
        //Generador de lbl
        public Label nuevoLabel()
        {
            Label lblNuevo = new Label();
            lblNuevo.Name = "lblPath";
            lblNuevo.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblNuevo.Visible = false;

            return lblNuevo;
        }///

        ////////////////////////
        /*Resto del programa:*/
        ///////////////////////

        //Iniciar programa
        public Form1()
        {
            InitializeComponent();
        }///

        //Primera ventana y agregar menucito
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Que agregue el menu la iconinito
            ContextMenu menuIconito = new ContextMenu();
            MenuItem itemSalir = new MenuItem("Salir");
            itemSalir.Click += new EventHandler(itemSalir_Click);
            menuIconito.MenuItems.Add(itemSalir);
            notifyIcon1.ContextMenu = menuIconito;

            //Crea  las capertas y archivos que ne
            if (!Directory.Exists(rutaCarpetaApp))
            {
                Directory.CreateDirectory(rutaCarpetaApp);
            }

            if (!File.Exists(rutaTabsGuardadas))
            {
                File.Create(rutaTabsGuardadas);
            }
            else
            {//Si existe
                string[] tabs = File.ReadAllLines(rutaTabsGuardadas.ToString());
                for (int i = 0; i < tabs.Length; i++)
                {
                    if (File.Exists(tabs[i]))
                    {
                        abrirArchivos(tabs[i]);
                    }
                    else
                    {
                        MessageBox.Show("El archivo " + tabs[i] + " se elimino, se cambio de lugar o se le cambio el nombre y no se le puede abrir", "DolphtNet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (tabControl.TabCount == 0)
            {
                nuevaVentanaToolStripMenuItem.PerformClick();
            }

            //Porque cuando inicia la primera ventana pone el asterisco
            quitarAsterisco();

        }///

        //Cerrar
        private void itemSalir_Click(object Sender, EventArgs e)
        {
            salirEscToolStripMenuItem.PerformClick();
        }

        //Nueva ventana
        public void nuevaVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creo una tab nueva
            TabPage nuevaTab = new TabPage("Nueva ventana " + (tabControl.TabCount + 1).ToString());

            //Creo un rtbox y pongo que ocupe todo
            RichTextBox txtNuevo = nuevoTxtBox();

            //Almacennar la path del archivo
            Label path = nuevoLabel();
            nuevaTab.Controls.Add(path);
            nuevaTab.Controls.Add(txtNuevo);
            tabControl.TabPages.Add(nuevaTab);
            //Pongo la nueva ventana con el focus
            tabControl.SelectedIndex = tabControl.TabCount - 1;

        }///

        //Borrar ventana
        private void tabControl_DoubleClick(object sender, EventArgs e)
        {

            if (validarTabs())
            {

                if (mostrarOpciones("¿Seguro quiere cerrar la ventana \"" + tabControl.SelectedTab.Text + "\"?", "Cerrar", MessageBoxIcon.None, MessageBoxDefaultButton.Button2))
                {
                    int index = tabControl.SelectedIndex - 1;
                    tabControl.Controls.Remove(tabControl.SelectedTab);
                    if (index > 0)
                    {
                        //Que se vaya el index al anterior
                        tabControl.SelectedIndex = index;
                    }
                    else
                    {
                        /*
                         Sirve para que cuando se borre el primer tab, que no quede en la "nada" 
                         sino en el siguiente a ese
                         */
                        tabControl.SelectedIndex = index + 1;
                    }
                }

            }
        }///

        //Cambiar fuente
        private void cambiarFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarTabs())
            {
                //Busco un "Control" que tenga el nombre txtNuevo mas index seleccionado que es el que cree
                if (tabControl.SelectedTab.Controls.ContainsKey("txtNuevo"))
                {
                    //Si existe que le ponga la font que seleccione
                    FontDialog fontDialog = new FontDialog();
                    fontDialog.Font = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).Font;
                    fontDialog.ShowDialog();
                    ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).Font = fontDialog.Font;
                }
            }

        }///

        //Color foreground
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (validarTabs())
            {
                //Busco un "Control" que tenga el nombre txtNuevo mas index seleccionado que es el que cree
                if (tabControl.SelectedTab.Controls.ContainsKey("txtNuevo"))
                {
                    //Si existe que le ponga la font que se leccione
                    ColorDialog colorDialog = new ColorDialog();
                    colorDialog.Color = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).ForeColor;
                    colorDialog.ShowDialog();
                    ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).ForeColor = colorDialog.Color;
                }
            }

        }///

        //Abrir ventana nueva
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Todos los archivos|*.*|Archivos RTF |*.rtf |Archivos de texto|*.txt";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                abrirArchivos(abrir.FileName);
            }

        }///

        //Guardar
        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (validarTabs())
            {
                try
                {
                    String ruta = ((Label)tabControl.SelectedTab.Controls["lblPath"]).Text;
                    if (File.Exists(ruta))
                    {//Si el archivo existe
                        quitarAsterisco();
                        RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);

                        if (Path.GetExtension(ruta) == ".rtf")
                        {
                            txtTexto.SaveFile(ruta);
                        }
                        else if (Path.GetExtension(ruta) == ".txt")
                        {
                            StreamWriter sw = new StreamWriter(ruta);
                            sw.WriteLine(txtTexto.Text);
                            sw.Close();

                        }
                        else
                        {
                            MessageBox.Show("Extension no soportada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }//Si no existe el archivo
                    else
                    {
                        guardarComoToolStripMenuItem.PerformClick();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }

        }///

        //Guardar como...
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (validarTabs())
            {
                try
                {

                    SaveFileDialog guardar = new SaveFileDialog();
                    guardar.FileName = tabControl.SelectedTab.Text;
                    guardar.Filter = "Archivos RTF |*.rtf|Archivos de texto|*.txt|Todos los archivos|*.*";

                    if (guardar.ShowDialog() == DialogResult.OK)
                    {
                        quitarAsterisco();
                        RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                        Label lblRuta = ((Label)tabControl.SelectedTab.Controls["lblPath"]);
                        if (Path.GetExtension(guardar.FileName) == ".rtf")
                        {
                            txtTexto.SaveFile(guardar.FileName);

                            //Pongo su ruta en el Label
                            tabControl.SelectedTab.Text = Path.GetFileName(guardar.FileName);
                            lblRuta.Text = guardar.FileName;

                        }
                        else if (Path.GetExtension(guardar.FileName) == ".txt")
                        {
                            StreamWriter sw = new StreamWriter(guardar.FileName);
                            sw.WriteLine(txtTexto.Text);
                            sw.Close();

                            //Pongo su ruta en el Label
                            tabControl.SelectedTab.Text = Path.GetFileName(guardar.FileName);
                            lblRuta.Text = guardar.FileName;

                        }
                        else
                        {
                            MessageBox.Show("Extension no soportada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString());
                }
            }

        }///

        //Buscar
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarTabs())
            {
                buscarToolStripMenuItem.Enabled = false;
                RichTextBox richTextBox = (RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"];
				FormBuscar formBuscar = new FormBuscar(ref this.buscarToolStripMenuItem, ref richTextBox);
                formBuscar.Show();
            }
        }///

        //Color backgorund
        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarTabs())
            {

                if (tabControl.SelectedTab.Controls.ContainsKey("txtNuevo"))
                {
                    //Si existe que le ponga la font que se leccione
                    ColorDialog colorDialog = new ColorDialog();
                    colorDialog.Color = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).BackColor;
                    colorDialog.ShowDialog();
                    ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]).BackColor = colorDialog.Color;
                }
            }
        }///

        //Auto completar
        private void resultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarTabs())
            {
                RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                String texto = txtTexto.SelectedText;
                if (resultadoToolStripMenuItem.Visible)
                {
                    String op = "";
                    if (texto.Length >= 3)
                    {
                        op = resultadoToolStripMenuItem.Text.Substring(0, 4);
                    }
                    else
                    {
                        op = texto;
                    }

                    if (op == "R = ")
                    {
                        txtTexto.SelectedText = resultadoToolStripMenuItem.Text.Substring(4);
                    }
                    else if (op == "n")
                    {
                        txtTexto.SelectedText = resultadoToolStripMenuItem.Text;
                    }
                    else if (op == "N")
                    {
                        txtTexto.SelectedText = resultadoToolStripMenuItem.Text;
                    }

                }
            }
        }///

        //Always top
        private void enFrenteSiempreOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String texto = enFrenteSiempreOFFToolStripMenuItem.Text;
            if (texto.IndexOf("No") != -1)
            {
                this.TopMost = true;
                enFrenteSiempreOFFToolStripMenuItem.Text = "Siempre en Frente(Si)";
            }
            else
            {
                this.TopMost = false;
                enFrenteSiempreOFFToolStripMenuItem.Text = "Siempre en Frente(No)";
            }

        }///

        //Mostrar ruta
        private void mostrarRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (validarTabs())
            {
                String texto = mostrarRutaToolStripMenuItem.Text;
                if (texto.IndexOf("No") != -1)
                {
                    ((Label)tabControl.SelectedTab.Controls["lblPath"]).Visible = true;
                    mostrarRutaToolStripMenuItem.Text = "Mostrar ruta(Si)";
                }
                else
                {
                    ((Label)tabControl.SelectedTab.Controls["lblPath"]).Visible = false;
                    mostrarRutaToolStripMenuItem.Text = "Mostrar ruta(No)";
                }
            }
        }///

        //Cambiar "Mostrar Ruta" 
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (validarTabsSinAdv())
            {
                //Cuando cambie de Tab que cambie el mostrar tab de si a no, o viceversa
                //Label lbl = ((Label)tabControl.SelectedTab.Controls["lblPath"]);
                Label lbl = ((Label)tabControl.SelectedTab.Controls["lblPath"]);
                if (lbl.Visible)
                {
                    mostrarRutaToolStripMenuItem.Text = "Mostrar ruta(Si)";
                }
                else
                {
                    mostrarRutaToolStripMenuItem.Text = "Mostrar ruta(No)";
                }


            }

        }///

        //Informacion de Atajos
        private void atajosTecladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Ctrl+B = Negrita \n" +
            "Ctrl+U = Subrayado \n" +
            "Ctrl+K = Italica \n" +
            "Ctrl+T = Tachado \n" +
            "Ctrl+Q = quitar estilo \n" +
            "Ctrl+M = convertir Mayusculas en Minusculas, y viceversa \n" +
            "Caps Lock = Autocompletar(Cuentas basicas y las Ñs) \n" +
            "Ctrl+W = Borrar la ventana seleccionada(O doble click sobre ella) \n" +
            "F11 = Activar/Desactivar guardado final de las ventanas \n" +
            "F12 = Salir instantaneamente(Sin preguntar ni guardar)"
            , "Informacion");
        }///

        //Teclas
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.N))
            {
                nuevaVentanaToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.S))
            {
                guardarToolStripMenuItem1.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.O))
            {
                abrirToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.F))
            {
                buscarToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.W))
            {

                if (validarTabs())
                {

                    if (mostrarOpciones("¿Seguro quiere cerrar la ventana \"" + tabControl.SelectedTab.Text + "\"?", "Cerrar", MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        int index = tabControl.SelectedIndex - 1;
                        tabControl.Controls.Remove(tabControl.SelectedTab);
                        if (index > 0)
                        {
                            //Que se vaya el index al anterior
                            tabControl.SelectedIndex = index;
                        }
                        else
                        {
                            /*
                             Sirve para que cuando se borre el primer tab, que no quede en la "nada" 
                             sino en el siguiente a ese
                             */
                            tabControl.SelectedIndex = index + 1;
                        }
                    }

                }

            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.F))
            {
                cambiarFuenteToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.C))
            {
                colorToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.B))
            {
                colorDeFondoToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Escape))
            {
                salirEscToolStripMenuItem.PerformClick();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F11))
            {
                if (guardarVentanas)
                {
                    MessageBox.Show("Se desactivo el guardado final de las ventanas", "Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guardarVentanas = false;
                }
                else
                {
                    MessageBox.Show("Se activo el guardado final de las ventanas", "Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guardarVentanas = true;
                }
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F12))
            {
                Application.Exit();
            }

        }

        //Crear el NotifyIcon
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)//Cancela el que se cierre la ventana
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }

            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;

            notifyIcon1.Visible = true;
        }

        //Abrir programa(Iconito)
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && !this.Visible)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;

            }
            else
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }///

        //Salir y guardar pestanias
        private void salirEscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mostrarOpciones("¿Quiere cerrar la ventana?", "Cerrar", MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                if (!Directory.Exists(rutaCarpetaApp))
                {
                    Directory.CreateDirectory(rutaCarpetaApp);
                    if (!File.Exists(rutaTabsGuardadas))
                    {
                        File.Create(rutaTabsGuardadas);
                    }
                }
                //Si existe
                if (guardarVentanas)
                {
                    StreamWriter sw = new StreamWriter(rutaTabsGuardadas.ToString());
                    tabControl.SelectedIndex = 0;
                    for (int i = 0; i < tabControl.TabCount; i++)
                    {
                        Label ruta = ((Label)tabControl.SelectedTab.Controls["lblPath"]);
                        RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                        if (File.Exists(ruta.Text))//Si el tab es un archivo guardado en el PC que lo guarde
                        {
                            sw.WriteLine(ruta.Text);//Escribe la ruta del archivo
                            if (tabControl.SelectedTab.Text.LastIndexOf('*') == tabControl.SelectedTab.Text.Length - 1)
                            {
                                if (mostrarOpciones("La ventana actual no esta guardada en su ultima version, ¿Quiere guardarla?", "Guardar", MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                                {
                                    guardarToolStripMenuItem1.PerformClick();
                                }
                            }
                        }
                        else
                        {
                            if (mostrarOpciones("La ventana actual no esta guardada, ¿Quiere guardarla?", "Guardar", MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                            {
                                guardarComoToolStripMenuItem.PerformClick();
                                if (File.Exists(ruta.Text))
                                {
                                    sw.WriteLine(ruta.Text);
                                }

                            }
                        }

                        tabControl.SelectedIndex++;
                    }
                    sw.Close();
                }


                Application.Exit();
            }
        }

        //Abrir la nueva ventana si droppeas
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Any())
            {
                foreach (string file in files)
                {

                    List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
                    //Si es una imagen la agrego al rich box
                    if (ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant()))
                    {
                        RichTextBox txtTexto = ((RichTextBox)tabControl.SelectedTab.Controls["txtNuevo"]);
                        //Guardo el clipboard antes de agregar la imagen
                        var clipBoardAntes = Clipboard.GetDataObject();
                        //Guardo la imagen como BitMap y lo pongo en el clipboard
                        Bitmap myBitmap = new Bitmap(file);
                        Clipboard.SetDataObject(myBitmap);
                        //Verifico si puedo pegar la imagen y si puedo la pego
                        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (txtTexto.CanPaste(myFormat))
                        {
                            txtTexto.Paste(myFormat);
                        }
                        //Y devuelvo el clipboard a su estado anterior
                        Clipboard.SetDataObject(clipBoardAntes);
                    }
                    //Sino intento abrir
                    else
                    {
                        abrirArchivos(file);
                    }
                }
            }

        }

        //Poner efectos al Dropear 
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
        }

    }//
}

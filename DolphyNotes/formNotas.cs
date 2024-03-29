﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DolphyNotes
{
    public partial class FormNotas : Form
    {
        private static String rutaRaiz = "C:\\DolphyCompany";
        private String rutaNotasGuardadasDefault = rutaRaiz + "\\DolphyNotes\\Notes";
        private String rutaNotasArchivoConfig = rutaRaiz + "\\DolphyNotes\\config.dolphy";
        //private String rutaNotasArchivoConfig = ".\\config.dolphy";
        private String rutaDondeEstaGuardado = "";

        //Variables de configuracion
        private bool avisoCambioPropiedad = true;

        private void camiarPropiedad(String texto)
        {
            if (avisoCambioPropiedad)
            {
                MessageBox.Show(texto, Texto.Propiedades, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void crearCarpetas()
        {
            if (!Directory.Exists(rutaRaiz))
            {
                Directory.CreateDirectory(rutaRaiz);
            }

            if (!Directory.Exists(rutaNotasGuardadasDefault))
            {
                Directory.CreateDirectory(rutaNotasGuardadasDefault);
            }

            if (!File.Exists(rutaNotasArchivoConfig))
            {
                File.CreateText(rutaNotasArchivoConfig).Close();
                String configs =
                    "#Si esta o no el modo escuro activado \n" +
                    "Oscuro=YES \n" +
                    "#Idioma en el que esta el programa \n" +
                    "Idioma=ES \n" +
                    "#Que muestre los avisos de cambio de propiedad \n" +
                    "AvisoCambioPropiedad=YES";
                File.WriteAllText(rutaNotasArchivoConfig, configs);
            }

        }

        public FormNotas()
        {
            InitializeComponent();
        }

        //Completar signos
        private void txtNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Sacado de https://www.c-sharpcorner.com/UploadFile/f5a10c/auto-complete-brackets-in-C-Sharpvb-net877/
            String s = e.KeyChar.ToString();
            int sel = txtNotas.SelectionStart;
            switch (s)
            {
                case "(":
                    txtNotas.SelectedText = "()";
                    e.Handled = true;//Para que no se duplique el primer caracter "(", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "{":
                    txtNotas.SelectedText = "{}";
                    e.Handled = true;//Para que no se duplique el primer caracter "{", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "[":
                    txtNotas.SelectedText = "[]";
                    e.Handled = true;//Para que no se duplique el primer caracter "[", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "'":
                    txtNotas.SelectedText = "''";
                    e.Handled = true;//Para que no se duplique el primer caracter "'", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "\"":
                    txtNotas.SelectedText = "\"\"";
                    e.Handled = true;//Para que no se duplique el primer caracter ", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "?":
                    txtNotas.SelectedText = "¿?";
                    e.Handled = true;//Para que no se duplique el primer caracter "?", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

                case "!":
                    txtNotas.SelectedText = "¡!";
                    e.Handled = true;//Para que no se duplique el primer caracter "!", como que anula lo que se inserto
                    txtNotas.SelectionStart = sel + 1;
                    break;

            }
        }

        //Combinacion de teclas
        private void txtNotas_KeyDown(object sender, KeyEventArgs e)
        {
            //Poner negrita
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.B))
            {
                Font vieja = txtNotas.SelectionFont;
                if (!txtNotas.SelectionFont.Bold)
                {

                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style | FontStyle.Bold);
                }
                else
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style & ~FontStyle.Bold);
                }

            }
            //Poner Subrayado
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.U))
            {
                Font vieja = txtNotas.SelectionFont;
                if (!txtNotas.SelectionFont.Underline)
                {

                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style | FontStyle.Underline);
                }
                else
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style & ~FontStyle.Underline);
                }
            }
            //Poner Italica
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.K))
            {
                Font vieja = txtNotas.SelectionFont;
                if (!txtNotas.SelectionFont.Italic)
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style | FontStyle.Italic);
                }
                else
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style & ~FontStyle.Italic);
                }
            }
            //Poner Rayado
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.T))//el Contro+R ya hacia algo :/
            {
                Font vieja = txtNotas.SelectionFont;
                if (!txtNotas.SelectionFont.Strikeout)
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style | FontStyle.Strikeout);
                }
                else
                {
                    txtNotas.SelectionFont = new Font(txtNotas.Font, vieja.Style & ~FontStyle.Strikeout);
                }
            }
            //Poner Mayusculas en Minusculas en viciversa
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.M))
            {
                if (!String.IsNullOrEmpty(txtNotas.SelectedText))
                {
                    String textoNuevo = "";
                    if (Char.IsLower(txtNotas.SelectedText[0]))
                    {
                        foreach (char c in txtNotas.SelectedText)
                        {
                            textoNuevo += Char.ToUpper(c);
                        }
                        txtNotas.SelectedText = textoNuevo;
                    }
                    else
                    {
                        foreach (char c in txtNotas.SelectedText)
                        {
                            textoNuevo += Char.ToLower(c);
                        }
                        txtNotas.SelectedText = textoNuevo;
                    }

                }

            }
            //Quitar estilos
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Q))
            {
                txtNotas.SelectionFont = new Font(txtNotas.Font, FontStyle.Regular);
            }
            //Completar
            else if (lblCompletar.Visible)
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.CapsLock))//El Control+Space quita todo
                {
                    String texto = txtNotas.SelectedText;
                    String op = "";
                    if (texto.Length >= 3)
                    {
                        op = lblCompletar.Text.Substring(0, 4);
                    }
                    else
                    {
                        op = texto;
                    }

                    if (op == "R = ")
                    {
                        txtNotas.SelectedText = lblCompletar.Text.Substring(4);
                    }
                    else if (op == "n")
                    {
                        txtNotas.SelectedText = lblCompletar.Text;
                    }
                    else if (op == "N")
                    {
                        txtNotas.SelectedText = lblCompletar.Text;
                    }

                    /*Para que vuelva a como estaba, osea si estaba activado que se mantenga asi
                     y lo mismo con minusculas*/
                    SendKeys.Send("{CAPSLOCK}");
                }
            }
            //Cambiar BackColor
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.B))
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = txtNotas.BackColor;
                colorDialog.ShowDialog();
                txtNotas.BackColor = colorDialog.Color;
            }
            //Cambiar Font
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.F))
            {
                FontDialog fontDialog = new FontDialog();
                fontDialog.Font = txtNotas.Font;
                fontDialog.ShowDialog();
                txtNotas.Font = fontDialog.Font;
            }
            //Cambiar ForeColor
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.C))
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = txtNotas.ForeColor;
                colorDialog.ShowDialog();
                txtNotas.ForeColor = colorDialog.Color;
            }
            //Guardar
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.S))
            {
                guardar();
            }
            //Guardar como...
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Shift) + Convert.ToInt32(Keys.S))
            {
                guardarComo();
            }
            //Abrir un archivo
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.O))
            {
                abrirNota();
            }
            //Tema oscuro
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F1))
            {
                String configs = File.ReadAllText(rutaNotasArchivoConfig);
                if (configs.IndexOf("Oscuro=YES") != -1)
                {//Tema Claro
                    txtNotas.BackColor = Color.FromArgb(255, 255, 255);
                    txtNotas.ForeColor = RichTextBox.DefaultForeColor;

                    lblCompletar.BackColor = Label.DefaultBackColor;
                    lblCompletar.ForeColor = Label.DefaultForeColor;
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("Oscuro=YES", "Oscuro=NO"));
                }
                else//Tema Oscuro
                {
                    txtNotas.BackColor = Color.FromArgb(41, 39, 39);
                    txtNotas.ForeColor = Color.FromArgb(160, 160, 160);

                    lblCompletar.BackColor = Color.FromArgb(105, 105, 105);
                    lblCompletar.ForeColor = Color.FromArgb(160, 160, 160);
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("Oscuro=NO", "Oscuro=YES"));
                }
            }
            //Sacar botones
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F2))
            {
                if (this.ControlBox)
                {
                    this.ControlBox = false;
                    camiarPropiedad(Texto.DesactivarBotones);
                }
                else
                {
                    this.ControlBox = true;
                    camiarPropiedad(Texto.ActivarBotones);
                }
            }
            //Fijar pestania
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F3))
            {
                if (this.FormBorderStyle != FormBorderStyle.None)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    camiarPropiedad(Texto.ActivarFijacion);
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    camiarPropiedad(Texto.DesactivarFijacion);
                }
            }
            //Top Most
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F4))
            {
                if (this.TopMost)
                {
                    this.TopMost = false;
                    camiarPropiedad(Texto.DesactivarAlFrente);
                }
                else
                {
                    this.TopMost = true;
                    camiarPropiedad(Texto.ActivarAlFrente);
                }
            }
            //Cambiar lenguaje
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F12))
            {
                String configs = File.ReadAllText(rutaNotasArchivoConfig);
                if (configs.IndexOf("Idioma=ES") != -1)
                {
                    Texto.Culture = new CultureInfo("en-US");
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("Idioma=ES", "Idioma=EN"));
                    camiarPropiedad(Texto.IdiomaCambio + " English(USA)");
                }
                else
                {
                    Texto.Culture = new CultureInfo("es-ES");
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("Idioma=EN", "Idioma=ES"));
                    camiarPropiedad(Texto.IdiomaCambio + " Español");
                }   
            }
            //Quitar avisos de cambios
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F11))
            {
                String configs = File.ReadAllText(rutaNotasArchivoConfig);
                if (configs.IndexOf("AvisoCambioPropiedad=YES") != -1)
                {
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("AvisoCambioPropiedad=YES", "AvisoCambioPropiedad=NO"));
                    avisoCambioPropiedad = false;
                }
                else
                {
                    File.WriteAllText(rutaNotasArchivoConfig, configs.Replace("AvisoCambioPropiedad=NO", "AvisoCambioPropiedad=YES"));
                    avisoCambioPropiedad = true;
                }
            }
        }

        //Check el completo
        private void txtNotas_SelectionChanged(object sender, EventArgs e)
        {
            String texto = txtNotas.SelectedText;
            texto = texto.Replace(" ", String.Empty);
            int i = 0;

            foreach (char c in texto)
            {
                if (char.IsDigit(c) || c == '+' || c == '-' || c == '/' || c == '*') i++;
            }

            if (i == texto.Length && i >= 3)//Si es minimo una cuenta osea 3+3, 3 digitos minimo
            {
                //Try para que no crashee en caso de ser un valor invalido
                try
                {
                    double resultado = Convert.ToDouble(new DataTable().Compute(texto, null));
                    lblCompletar.Text = "R = " + resultado.ToString();
                    lblCompletar.Visible = true;
                }
                catch (Exception) { }

            }
            else if (texto == "n")
            {
                lblCompletar.Text = "ñ";
                lblCompletar.Visible = true;
            }
            else if (texto == "N")
            {
                lblCompletar.Text = "Ñ";
                lblCompletar.Visible = true;
            }
            else
            {
                lblCompletar.Visible = false;
            }
        }

        //Ingresar archivos
        private void txtNotas_DragDrop(object sender, DragEventArgs e)
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
                        //Guardo el clipboard antes de agregar la imagen
                        var clipBoardAntes = Clipboard.GetDataObject();
                        //Guardo la imagen como BitMap y lo pongo en el clipboard
                        Bitmap myBitmap = new Bitmap(file);
                        Clipboard.SetDataObject(myBitmap);
                        //Verifico si puedo pegar la imagen y si puedo la pego
                        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (txtNotas.CanPaste(myFormat))
                        {
                            txtNotas.Paste(myFormat);
                        }
                        //Y devuelvo el clipboard a su estado anterior
                        Clipboard.SetDataObject(clipBoardAntes);
                    }
                    else
                    {
                        txtNotas.LoadFile(file);
                    }

                }
            }
        }

        //Poner efectitos al ingresar
        private void txtNotas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        //Poner asterisco
        private void txtNotas_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.ElementAt(0) != '*') this.Text = "*" + this.Text;
        }

        //Abrir ventana nueva
        private void abrirNota()
        {
            crearCarpetas();

            try
            {
                OpenFileDialog abrir = new OpenFileDialog();
                abrir.InitialDirectory = rutaNotasGuardadasDefault;
                abrir.Filter = Texto.TipoArchivos;

                if (abrir.ShowDialog() == DialogResult.OK)
                {

                    //Declaro el lector
                    StreamReader sr = new StreamReader(abrir.FileName);
                    if (Path.GetExtension(abrir.FileName) == ".rtf")
                    {
                        //Cargo el RTF en el RichTextBox con texto con estilo
                        txtNotas.LoadFile(abrir.FileName);
                        rutaDondeEstaGuardado = abrir.FileName;
                        this.Text = "DolphyNotes: " + Path.GetFileNameWithoutExtension(rutaDondeEstaGuardado);
                    }
                    else if (Path.GetExtension(abrir.FileName) == ".txt")
                    {
                        //Cargo el RTF en el RichTextBox con texto simple
                        txtNotas.Text = sr.ReadToEnd();
                        rutaDondeEstaGuardado = abrir.FileName;
                        this.Text = "DolphyNotes: " + Path.GetFileNameWithoutExtension(rutaDondeEstaGuardado);

                    }
                    else
                    {
                        MessageBox.Show(Texto.ExtensionNoSoportada + " " + Path.GetFileName(abrir.FileName), Texto.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    sr.Close();//Para que deje de usar el archivo

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Texto.ErrorAbrir + " " + ex.ToString(), Texto.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }

        }///

        //Guardar
        private void guardar()
        {
            try
            {

                if (File.Exists(rutaDondeEstaGuardado))
                {//Si el archivo existe

                    if (Path.GetExtension(rutaDondeEstaGuardado) == ".rtf")
                    {
                        txtNotas.SaveFile(rutaDondeEstaGuardado);

                        //Quito la marca de no guardado
                        quitarAsterico();
                    }
                    else if (Path.GetExtension(rutaDondeEstaGuardado) == ".txt")
                    {
                        StreamWriter sw = new StreamWriter(rutaDondeEstaGuardado);
                        sw.WriteLine(txtNotas.Text);
                        sw.Close();

                        //Quito la marca de no guardado
                        quitarAsterico();
                    }
                    else
                    {
                        MessageBox.Show(Texto.ExtensionNoSoportada, Texto.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }//Si no existe el archivo
                else
                {
                    guardarComo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Texto.ErrorGuardar, Texto.ErrorGuardar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }

        }///

        //Guardar como...
        private void guardarComo()
        {
            try
            {
                crearCarpetas();

                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = Path.GetFileNameWithoutExtension(rutaNotasGuardadasDefault);
                guardar.InitialDirectory = rutaNotasGuardadasDefault;
                guardar.Filter = Texto.TipoArchivos;

                if (guardar.ShowDialog() == DialogResult.OK)
                {

                    if (Path.GetExtension(guardar.FileName) == ".rtf")
                    {
                        txtNotas.SaveFile(guardar.FileName);
                        rutaDondeEstaGuardado = guardar.FileName;
                        this.Text += ": " + Path.GetFileNameWithoutExtension(rutaDondeEstaGuardado);

                        //Quito la marca de no guardado
                        quitarAsterico();
                    }
                    else if (Path.GetExtension(guardar.FileName) == ".txt")
                    {
                        StreamWriter sw = new StreamWriter(guardar.FileName);
                        sw.WriteLine(txtNotas.Text);
                        sw.Close();
                        rutaDondeEstaGuardado = guardar.FileName;
                        this.Text += ": " + Path.GetFileNameWithoutExtension(rutaDondeEstaGuardado);

                        //Quito la marca de no guardado
                        quitarAsterico();
                    }
                    else
                    {
                        MessageBox.Show(Texto.ExtensionNoSoportada, Texto.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Texto.ErrorGuardar, Texto.ErrorGuardar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString());
            }
        }///
        
        //Quitar asterisco
        private void quitarAsterico()
        {
            if (this.Text.ElementAt(0)  == '*') this.Text = this.Text.Substring(1, this.Text.Length-1);
        }

        //Cuando carga
        private void FormNotas_Load(object sender, EventArgs e)
        {
            crearCarpetas();

            String configs = File.ReadAllText(rutaNotasArchivoConfig);
            if (configs.IndexOf("Oscuro=YES") != -1)
            {
                txtNotas.BackColor = Color.FromArgb(41, 39, 39);
                txtNotas.ForeColor = Color.FromArgb(160, 160, 160);

                lblCompletar.BackColor = Color.FromArgb(105, 105, 105);
                lblCompletar.ForeColor = Color.FromArgb(160, 160, 160);
            }
            else if (configs.IndexOf("Oscuro=NO") != -1) { }
            else
            {
                MessageBox.Show(Texto.ErrorConfiguracion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(rutaNotasArchivoConfig);
                Application.Exit();
            }


            if (configs.IndexOf("Idioma=ES") != -1)
            {
                Texto.Culture = new CultureInfo("es-ES");
            }
            else if(configs.IndexOf("Idioma=EN") != -1)
            {
                Texto.Culture = new CultureInfo("en-US");
            }
            else
            {
                MessageBox.Show(Texto.ErrorConfiguracion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(rutaNotasArchivoConfig);
                Application.Exit();
            }

            if (configs.IndexOf("AvisoCambioPropiedad=YES") != -1)
            {
                avisoCambioPropiedad = true; 
            }
            else if (configs.IndexOf("AvisoCambioPropiedad=NO") != -1)
            {
                avisoCambioPropiedad = false;
            }
            else
            {
                MessageBox.Show(Texto.ErrorConfiguracion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(rutaNotasArchivoConfig);
                Application.Exit();
            }

        }

        //Ingresar archivos
        private void FormNotas_DragDrop(object sender, DragEventArgs e)
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
                        //Guardo el clipboard antes de agregar la imagen
                        var clipBoardAntes = Clipboard.GetDataObject();
                        //Guardo la imagen como BitMap y lo pongo en el clipboard
                        Bitmap myBitmap = new Bitmap(file);
                        Clipboard.SetDataObject(myBitmap);
                        //Verifico si puedo pegar la imagen y si puedo la pego
                        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (txtNotas.CanPaste(myFormat))
                        {
                            txtNotas.Paste(myFormat);
                        }
                        //Y devuelvo el clipboard a su estado anterior
                        Clipboard.SetDataObject(clipBoardAntes);
                    }
                    else
                    {
                        txtNotas.LoadFile(file);
                    }

                }
            }
        }

        //Poner efectitos al ingresar
        private void FormNotas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}

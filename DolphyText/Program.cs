using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolphyText
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
 
            //Comprobar si ya hay una instancia del programa
            if (System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("DolphyNet ya se esta ejecuntado", "DolphyText", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                //Si tiene entrada..
                if (args != null && args.Length > 0)
                {

                    string entrada = args[0];
                    //Si es valida
                    if (File.Exists(entrada))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        Form1 MainFrom = new Form1();
                        MainFrom.abrirArchivos(entrada);
                        Application.Run(MainFrom);
                    }
                    //Entrada invalida...
                    else
                    {
                        MessageBox.Show("Este archivo no existe", "DolphyText", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                    }
                }
                //Sin entrada...
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }

        }
    }
}

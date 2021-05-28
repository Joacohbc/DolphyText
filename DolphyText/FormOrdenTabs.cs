using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolphyText
{
    public partial class FormOrdenTabs : Form
    {
        TabControl tabControl;
        TabPage tabSeleccionada;
        public FormOrdenTabs(ref TabControl tabControlEntrada)
        {
            tabControl = tabControlEntrada;
            tabSeleccionada = tabControl.SelectedTab;
            tabControl.SelectedIndex = 0;

            InitializeComponent();

            cmbPrimerPage.Items.Add("Elija la ventana orgien");
            cmbSegudaPage.Items.Add("Elija la ventana destino");
            for (int i = 0; i < tabControl.TabCount; i++)
            {
                cmbPrimerPage.Items.Add(tabControl.SelectedTab.Text);
                cmbSegudaPage.Items.Add(tabControl.SelectedTab.Text);
                tabControl.SelectedIndex++;
            }

            cmbPrimerPage.SelectedIndex = 0;
            cmbSegudaPage.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPrimerPage.SelectedIndex != 0)
            {
                if(cmbSegudaPage.SelectedIndex != 0)
                {
                    //Las "guardo:"
                    TabPage tab1 = tabControl.TabPages[cmbPrimerPage.SelectedIndex-1];
                    TabPage tab2 = tabControl.TabPages[cmbSegudaPage.SelectedIndex-1];

                    //Las cambio de lugar
                    tabControl.TabPages[cmbPrimerPage.SelectedIndex - 1] = tab2;
                    tabControl.TabPages[cmbSegudaPage.SelectedIndex - 1] = tab1;

                    //Lo pongo como antes del cambio
                    tabControl.SelectedTab = tabSeleccionada;
                     
                }
                else
                {
                    MessageBox.Show("Elija una ventana destino", "Elegir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSegudaPage.Focus();
                }
            }
            else
            {
                MessageBox.Show("Elija una ventana origen", "Elegir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPrimerPage.Focus();
            }
        }
    }
}

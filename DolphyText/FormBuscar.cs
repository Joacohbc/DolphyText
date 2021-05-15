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
    public partial class FormBuscar : Form
    {
        private ToolStripMenuItem tsmiBuscar;
        private RichTextBox txtTexto;
        private int buscar = -1;
        public FormBuscar(ref ToolStripMenuItem abrirToolStripMenuItem, ref RichTextBox richTextBox)
        {
            tsmiBuscar = abrirToolStripMenuItem;
            txtTexto = richTextBox;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text))
            {
                buscar = buscarTexto(buscar + 1);

                if (buscar != -1)
                {
                    txtTexto.SelectionStart = buscar;
                    txtTexto.SelectionLength = txtBuscar.Text.Length;
                    txtTexto.Focus();
                }
                else
                {
                    MessageBox.Show("No es encotro lo pedido", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                txtTexto.Focus();
            }
        }

        private void chkDistinguir_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsmiBuscar.Enabled = true;
        }

        public int buscarTexto(int i)
        {
            if (chkDistinguir.Checked)
            {
                return txtTexto.Text.IndexOf(txtBuscar.Text, i);
            }
            else
            {
                return txtTexto.Text.IndexOf(txtBuscar.Text.ToLower(), i);
            }
        }

        private void btnRemplazar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text))
            {
                if (!String.IsNullOrEmpty(txtRemplazar.Text))
                {
                    buscar = buscarTexto(buscar + 1);

                    if (buscar != -1)
                    {
                        txtTexto.SelectionStart = buscar;
                        txtTexto.SelectionLength = txtBuscar.Text.Length;
                        txtTexto.SelectedText = txtRemplazar.Text;
                    }
                    else
                    {
                        MessageBox.Show("No es encotro lo pedido", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void btnRemplazarTodo_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscar.Text))
            {
                if (!String.IsNullOrEmpty(txtRemplazar.Text))
                {
                    buscar = buscarTexto(buscar + 1);
                    while (buscar != -1)
                    {
                        txtTexto.SelectionStart = buscar;
                        txtTexto.SelectionLength = txtBuscar.Text.Length;
                        txtTexto.SelectedText = txtRemplazar.Text;
                        buscar = buscarTexto(buscar + 1);
                    }

                }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtRemplazar.Clear();
        }

        private void FormBuscar_Load(object sender, EventArgs e)
        {

        }
    }///
}

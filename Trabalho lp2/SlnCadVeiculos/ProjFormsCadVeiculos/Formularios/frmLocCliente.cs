using ProjLibraryCadVeiculos.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjFormsCadVeiculos.Formularios
{
    public partial class frmLocCliente : Form
    {
        public CadCliente cliente { get; set; }
        List<CadCliente> lista;
        public frmLocCliente()
        {
            InitializeComponent();
            pesquisar();
        }
        private void pesquisar()
        {
            lista = DAOCliente.LocalizarNome(ttbNome.Text);
            dgv.DataSource = lista;
            if (lista.Count == 0 && !ttbNome.Text.Equals(""))
            {
                ttbNome.BackColor = System.Drawing.Color.Red;
                ttbNome.ForeColor = System.Drawing.Color.White;
            }

            else
            {
                ttbNome.BackColor = System.Drawing.Color.White;
                ttbNome.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            cliente = dgv.CurrentRow?.DataBoundItem as CadCliente;
            Close();
        }

        private void ttbNome_TextChanged(object sender, EventArgs e)
        {
            pesquisar();
        }
    }
}

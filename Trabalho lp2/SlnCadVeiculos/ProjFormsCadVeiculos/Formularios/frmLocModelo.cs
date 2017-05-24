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
    public partial class frmLocModelo : Form
    {
        public CadModelo modelo { get; set; }
        List<CadModelo> lista;
        public frmLocModelo()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            pesquisar();
            
        }
        private void pesquisar()
        {
            lista = DAOModelo.LocalizarNome(ttbNome.Text);
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
            if (lista.Count == 0)
                MessageBox.Show("Não existe produto com a nome informada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ttbNome_TextChanged(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            modelo = dgv.CurrentRow?.DataBoundItem as CadModelo;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

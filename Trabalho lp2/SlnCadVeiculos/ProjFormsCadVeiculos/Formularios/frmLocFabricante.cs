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
    public partial class frmLocFabricante : Form
    {
        public CadFabricante Fabricante { get; set; }
        List<CadFabricante> lista;

        public frmLocFabricante()
        {
            InitializeComponent();
            pesquisar();
        }
        private void pesquisar()
        {
            lista = DAOFabricante.LocalizarNome(ttbNome.Text);
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

        private void dgv_DoubleClick_1(object sender, EventArgs e)
        {
            Fabricante = dgv.CurrentRow?.DataBoundItem as CadFabricante;
            Close();
        }

        private void ttbNome_TextChanged(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void frmLocFabricante_Load(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class frmLocVeiculos : Form
    {
        public CadVeiculo veiculo { get; set; }
        List<CadVeiculo> lista;
        public frmLocVeiculos()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            pesquisar();

        }
        private void pesquisar()
        {
            lista = DAOVeiculo.LocalizarNome(ttbDescricao.Text);
            dgv.DataSource = lista;
            if (lista.Count == 0 && !ttbDescricao.Text.Equals(""))
            {
                ttbDescricao.BackColor = System.Drawing.Color.Red;
                ttbDescricao.ForeColor = System.Drawing.Color.White;
            }

            else
            {
                ttbDescricao.BackColor = System.Drawing.Color.White;
                ttbDescricao.ForeColor = System.Drawing.Color.Black;
            }


        }

        private void ttbDescricao_TextChanged(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            veiculo = dgv.CurrentRow?.DataBoundItem as CadVeiculo;
            
                
            Close();
        }
    }
}

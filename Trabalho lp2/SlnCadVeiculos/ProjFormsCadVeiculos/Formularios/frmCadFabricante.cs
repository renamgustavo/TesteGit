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
    public partial class frmCadFabricante : Form
    {
        public CadFabricante fabricante { get; set; }
        
            
        
        public frmCadFabricante()
        {
            InitializeComponent();
            inicializa();
        }
        private void inicializa()
        {
            fabricante = new CadFabricante();
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            btnConsultar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnIncluir.Enabled = false;
            btnCancelar.Enabled = false;
            ttbNome.Enabled = false;
            ttbCodigo.Enabled = true;
            limparTela();
        }
        private void limparTela()
        {
            ttbCodigo.Clear();
            ttbNome.Clear();
        }
            private void inicializaIncluir()
            {
                btnNovo.Enabled = false;
                btnPesquisar.Enabled = false;
                btnConsultar.Enabled = false;
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnIncluir.Enabled = true;
                btnCancelar.Enabled = true;
                ttbNome.Enabled = true;
                ttbCodigo.Enabled = false;
          
            }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ttbCodigo.Clear();
            inicializaIncluir();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicializa();
        }

        private string valida()
        {
            string erro = "";
            if (string.IsNullOrEmpty(ttbNome.Text))
            {
                erro = "Informe Nome valido\n";
                ttbNome.Focus();    
            }
            else
                fabricante.nome = ttbNome.Text;
            if (!string.IsNullOrEmpty(ttbCodigo.Text))
                fabricante.codigo = Convert.ToInt32(ttbCodigo.Text);
            

            return erro;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            string erros = valida();
            if (erros.Equals(""))
            {
                DAOFabricante.Gravar(fabricante);
                MessageBox.Show("Fabricante Cadastrado");
                inicializa();
            }
            else
                MessageBox.Show(erros);


        }

        private void inicializaPesquisa()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
            btnConsultar.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = false;
            ttbCodigo.Enabled = false;
        }
        private void pesquisar()
        {
            if (ttbCodigo.Text.Equals(""))
            {
                MessageBox.Show("Informe um codigo");
                return;
            }
            fabricante = new CadFabricante();

            fabricante.codigo = Convert.ToInt32(ttbCodigo.Text);
            bool achou = DAOFabricante.LocaliarObjetos(fabricante);
            if (achou)
            {
                ttbNome.Text = fabricante.nome;
                ttbCodigo.Text = fabricante.codigo.ToString();
                inicializaPesquisa();

            }
            else
            {
                MessageBox.Show("Codigo " + ttbCodigo.Text + " nao encontrado");
                ttbCodigo.Clear();
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();       
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            inicializaIncluir();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (fabricante.codigo.ToString().Equals(""))
            {

                MessageBox.Show("Não é possivel excluir esse fabricante");
                return;
            }
            if (MessageBox.Show("Confirma exclusão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DAOFabricante.Excluir(fabricante);
                inicializa();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmLocFabricante f = new frmLocFabricante();
            f.ShowDialog();
            if (f.Fabricante != null)
            {
                fabricante = f.Fabricante;
                ttbCodigo.Text = fabricante.codigo.ToString();
                ttbNome.Text = fabricante.nome;
                inicializaPesquisa();
                
            }
        }

        private void ttbCodigo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmCadFabricante_Load(object sender, EventArgs e)
        {

        }

        private void ttbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void ttbNome_Leave(object sender, EventArgs e)
        {
           /* 
            if (ttbNome.Text == "")
            {
                ttbNome.Focus();
            }
            else
            {
                ttbNome.BackColor = System.Drawing.Color.White;
                ttbNome.ForeColor = System.Drawing.Color.Black;
                lbMensagem.Visible = false;
            }*/
        }
    }
}

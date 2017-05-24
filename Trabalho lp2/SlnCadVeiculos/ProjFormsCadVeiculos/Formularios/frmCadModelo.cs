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
    public partial class frmCadModelo : Form
    {
        private object fabricante;

        public CadModelo modelo { get; set; }
        public frmCadModelo()
        {
            InitializeComponent();
            Carregacbb();
            inicializa();
            cbbFabricantes.SelectedIndex = -1;
        }
        private void Carregacbb()
        {
            cbbFabricantes.DisplayMember = "nome";
            cbbFabricantes.ValueMember = "codigo";
            cbbFabricantes.DataSource = DAOFabricante.LocalizarNome("");
            cbbFabricantes.SelectedIndex = -1;
        }
        private void inicializa()
        {
            modelo = new CadModelo();     
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            btnConsultar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnIncluir.Enabled = false;
            btnCancelar.Enabled = false;
            btnAddFabricante.Enabled = false;
            ttbDescricao.Enabled = false;
            ttbCodigo.Enabled = true;
            cbbFabricantes.Enabled = false;
            
            limparTela();

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
            btnAddFabricante.Enabled = true;
            ttbDescricao.Enabled = true;
            ttbCodigo.Enabled = false;
            cbbFabricantes.Enabled = true;
            
        }

        private void limparTela()
        {
            ttbCodigo.Clear();
            ttbDescricao.Clear();
            cbbFabricantes.SelectedIndex = -1;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            string erros = valida();
            if (erros.Equals(""))
            {
                DAOModelo.Gravar(modelo);
                MessageBox.Show("Modelo Cadastrado");
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
            modelo = new CadModelo();
            fabricante = new CadFabricante();
            modelo.codigo = Convert.ToInt32(ttbCodigo.Text);
            bool achou = DAOModelo.LocalizarObjeto(modelo);
            if (achou)
            {
                
                ttbDescricao.Text = modelo.descricao;
                ttbCodigo.Text = modelo.codigo.ToString();
                cbbFabricantes.SelectedValue = modelo.fabricante;
                inicializaPesquisa();
                
            }
            else
            {
                MessageBox.Show("Codigo " + ttbCodigo.Text + " nao encontrado");
                ttbCodigo.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicializa();
        }
        private string valida()
        {
            string erro = "";
            if (string.IsNullOrEmpty(ttbDescricao.Text))
                erro = "Informe Descricao valida\n";
            else
                modelo.descricao = ttbDescricao.Text;

            if (!string.IsNullOrEmpty(ttbCodigo.Text))
                modelo.codigo = Convert.ToInt32(ttbCodigo.Text);

            if(cbbFabricantes.SelectedIndex <= -1)
            {
                erro += "Informe o fabricante";
            }
            else
                   modelo.fabricante = Convert.ToInt32(cbbFabricantes.SelectedValue);
            return erro;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            inicializaIncluir();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ttbCodigo.Clear();
            inicializaIncluir();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (modelo.codigo.ToString().Equals(""))
            {

                MessageBox.Show("Não é possivel excluir esse Modelo");
                return;
            }
            if (MessageBox.Show("Confirma exclusão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DAOModelo.Excluir(modelo);
                inicializa();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmLocModelo m = new frmLocModelo();
            m.ShowDialog();
            if (m.modelo != null)
            {
                modelo = m.modelo;
                ttbCodigo.Text = modelo.codigo.ToString();
                ttbDescricao.Text = modelo.descricao;
                cbbFabricantes.SelectedValue = modelo.fabricante;
                inicializaPesquisa();

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btnAddFabricante_Click(object sender, EventArgs e)
        {
            frmCadFabricante f = new frmCadFabricante();
            f.ShowDialog();
            Carregacbb();

        }

        private void ttbCodigo_TextChanged(object sender, EventArgs e)
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

        private void frmCadModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                Close();
            }
        }

        private void frmCadModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(27)) //ESC
            {
                this.Close();
            }
        }
    }
}

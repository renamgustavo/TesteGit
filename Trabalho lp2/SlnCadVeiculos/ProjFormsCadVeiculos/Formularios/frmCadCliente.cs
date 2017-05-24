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
    public partial class frmCadCliente : Form
    {
        public CadCliente cliente { get; set; }
        public frmCadCliente()
        {
            InitializeComponent();
            inicializa();
        }
        private void inicializa()
        {
            cliente = new CadCliente();
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            btnConsultar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnIncluir.Enabled = false;
            btnCancelar.Enabled = false;
            ttbNome.Enabled = false;
            ttbCodigo.Enabled = true;
            ttbObservacoes.Enabled = false;
            ttbTelefone.Enabled = false;
            limparTela();
        }

        private void limparTela()
        {
            ttbCodigo.Clear();
            ttbNome.Clear();
            ttbObservacoes.Clear();
            ttbTelefone.Clear();
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
            ttbObservacoes.Enabled = true;
            ttbTelefone.Enabled = true;

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
            ttbNome.Enabled = false;
            ttbTelefone.Enabled = false;
            ttbObservacoes.Enabled = false;
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
                erro = "Informe um nome valido\n";
                ttbNome.Focus();
            }
            else
                cliente.nome = ttbNome.Text;

            if (!string.IsNullOrEmpty(ttbCodigo.Text))
                cliente.codigo = Convert.ToInt32(ttbCodigo.Text);
            if (string.IsNullOrEmpty(ttbTelefone.Text) || ttbTelefone.Text.Length <=9)
                erro += "informe um telefone valido";
            else
                cliente.telefone = ttbTelefone.Text;

            if (string.IsNullOrEmpty(ttbObservacoes.Text))
                cliente.observacoes = "";
            else
                cliente.observacoes = ttbObservacoes.Text;  
            return erro;
        }
        private void pesquisar()
        {
            if(ttbCodigo.Text.Equals(""))
            {
                MessageBox.Show("Informe um codigo");
                return;
            }

            cliente = new CadCliente();

            cliente.codigo = Convert.ToInt32(ttbCodigo.Text);

            bool achou = DAOCliente.LocalizarObjeto(cliente);
            if(achou)
            {
                ttbNome.Text = cliente.nome;
                ttbTelefone.Text = cliente.telefone;
                ttbObservacoes.Text = cliente.observacoes;
                ttbCodigo.Text = cliente.codigo.ToString();
                inicializaPesquisa();
            }
            else
            {
                MessageBox.Show("Codigo " + ttbCodigo.Text + " Nao encontrado");
            }
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            string erros = valida();
            if (erros.Equals(""))
            {
                DAOCliente.Gravar(cliente);
                MessageBox.Show("Cliente Cadastrado");
                inicializa();
            }
            else
                MessageBox.Show(erros);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            inicializaIncluir();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(cliente.codigo.ToString().Equals(""))
            {
                MessageBox.Show("Não é Possivel excluir esse cliente");
                return;
            }
            if(MessageBox.Show("Confirma exclusão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DAOCliente.Excluir(cliente);
                inicializa();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmLocCliente c = new frmLocCliente();
            c.ShowDialog();
            if (c.cliente != null)
            {
                cliente = new CadCliente();
                cliente = c.cliente;
                ttbCodigo.Text = cliente.codigo.ToString();
                ttbNome.Text = cliente.nome;
                ttbTelefone.Text = cliente.telefone;
                ttbObservacoes.Text = cliente.observacoes;
                inicializaPesquisa();

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void ttbTelefone_TextChanged(object sender, EventArgs e)
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

        private void frmCadCliente_Load(object sender, EventArgs e)
        {

        }

        private void frmCadCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
            if(e.KeyChar.ToString().Equals("Escape"))            
                    Close();



        }

        private void frmCadCliente_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyValue.ToString());
        }
    }
}

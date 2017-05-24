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
    public partial class frmCadVeiculo : Form
    {
        private object modelo;
        private object cliente;

        public CadVeiculo veiculo { get; set; }
        public object Datatime { get; private set; }

        public frmCadVeiculo()
        {
            InitializeComponent();
            Carregacbbcliente();
            Carregacbbmodelo();
            inicializa();
        }

        private void Carregacbbmodelo()
        {
            cbbModelo.DisplayMember = "descricao";
            cbbModelo.ValueMember = "codigo";
            cbbModelo.DataSource = DAOModelo.LocalizarNome("");
            cbbModelo.SelectedIndex = -1;
        }

        private void Carregacbbcliente()
        {
            cbbCliente.DisplayMember = "nome";
            cbbCliente.ValueMember = "codigo";
            cbbCliente.DataSource = DAOCliente.LocalizarNome("");
            cbbCliente.SelectedIndex = -1;
        }

        private void inicializa()
        {
            veiculo = new CadVeiculo();
            btnAddCliente.Enabled = false;
            btnAddModelo.Enabled = false;
            btnNovo.Enabled = true;
            btnPesquisar.Enabled = true;
            btnConsultar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnIncluir.Enabled = false;
            btnCancelar.Enabled = false;
            ttbDescricao.Enabled = false;
            ttbCodigo.Enabled = true;
            ttbObservacao.Enabled = false;
            ttbValor.Enabled = false;
            cbbCliente.Enabled = false;
            cbbModelo.Enabled = false;
            dtpDatacadastro.Enabled = false;
            dtpDatavenda.Enabled = false;
            ckbAtivo.Enabled = false;
            ttbCodigo.Focus();

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
            btnAddModelo.Enabled = true;
            btnAddCliente.Enabled = true;
            ttbDescricao.Enabled = true;
            ttbObservacao.Enabled = true;
            ttbValor.Enabled = true;
            ttbCodigo.Enabled = false;
            cbbCliente.Enabled = true;
            cbbModelo.Enabled = true;
            dtpDatacadastro.Enabled = true;
            dtpDatavenda.Enabled = true;
            ckbAtivo.Enabled = true;
        


        }
        private void inicializaPesquisa()
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
            btnConsultar.Enabled = false;
            btnNovo.Enabled = false;
            btnPesquisar.Enabled = false;
            btnAddCliente.Enabled = false;
            btnAddModelo.Enabled = false;
            ttbCodigo.Enabled = false;
            ttbDescricao.Enabled = false;
            ttbObservacao.Enabled = false;
            ttbValor.Enabled = false;
            cbbCliente.Enabled = false;
            cbbModelo.Enabled = false;
            dtpDatacadastro.Enabled = false;
            dtpDatavenda.Enabled = false;
            ckbAtivo.Enabled = false;
            

        }

        private void limparTela()
        {
            ttbCodigo.Clear();
            ttbDescricao.Clear();
            ttbValor.Clear();
            ttbObservacao.Clear();
            cbbCliente.SelectedIndex = -1;
            cbbModelo.SelectedIndex = -1;
        }
        private void pesquisar()
        {
            if (ttbCodigo.Text.Equals(""))
            {
                MessageBox.Show("Informe um codigo");
                return;
            }
            veiculo = new CadVeiculo();
            cliente = new CadCliente();
            modelo = new CadModelo();
            veiculo.codigo = Convert.ToInt32(ttbCodigo.Text);
            bool achou = DAOVeiculo.LocalizarObjeto(veiculo);
            if (achou)
            {
                
                ttbDescricao.Text = veiculo.descricao;
                ttbCodigo.Text = veiculo.codigo.ToString();
                ttbObservacao.Text = veiculo.observacoes;
                ttbValor.Text = veiculo.valor.ToString();
                dtpDatacadastro.Text = veiculo.datacadastro.ToString();
                dtpDatavenda.Text = veiculo.datavenda.ToString();
                cbbCliente.SelectedValue = veiculo.cliente;
                cbbModelo.SelectedValue = veiculo.modelo;
                inicializaPesquisa();

            }
            else
            {
                MessageBox.Show("Codigo " + ttbCodigo.Text + " nao encontrado");
                ttbCodigo.Clear();
            }
        }

        private void frmCadVeiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmLocVeiculos v = new frmLocVeiculos();
            v.ShowDialog();
            if (v.veiculo != null)
            {
                veiculo = v.veiculo;
                ttbCodigo.Text = veiculo.codigo.ToString();
                ttbDescricao.Text = veiculo.descricao;
                ttbObservacao.Text = veiculo.observacoes;
                ttbValor.Text = veiculo.valor.ToString(); 
                cbbCliente.SelectedValue = veiculo.cliente;
                cbbModelo.SelectedValue = veiculo.modelo;
                dtpDatavenda.Text = veiculo.datavenda.ToString();
                dtpDatacadastro.Text = veiculo.datacadastro.ToString();
                if (veiculo.ativo == 's')
                    ckbAtivo.Checked = true;
                else
                    ckbAtivo.Checked = false;
                inicializaPesquisa();

            }
        }

        private void btnAddModelo_Click(object sender, EventArgs e)
        {
            frmCadModelo m = new frmCadModelo();
            m.ShowDialog();
            Carregacbbmodelo();
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            frmCadCliente c = new frmCadCliente();
            c.ShowDialog();
            Carregacbbcliente();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ttbCodigo.Clear();
            inicializaIncluir();

        }
        private string valida()
        {
            string erro = "";
            if (string.IsNullOrEmpty(ttbDescricao.Text))
                erro = "Informe Descricao valida\n";
            else
                veiculo.descricao = ttbDescricao.Text;

            if (!string.IsNullOrEmpty(ttbCodigo.Text))
                veiculo.codigo = Convert.ToInt32(ttbCodigo.Text);

            if (cbbCliente.SelectedIndex <= -1)
            {
                erro += "Informe o Cliente\n";
            }
            else
                veiculo.cliente = Convert.ToInt32(cbbCliente.SelectedValue);
           

            if (cbbModelo.SelectedIndex <= -1)
            {
                erro += "infome o Modelo\n";
            }
            else
                veiculo.modelo = Convert.ToInt32(cbbModelo.SelectedValue);

            if (dtpDatacadastro.Text == null)
                erro += "informe data de cadastror\t";
            else
                veiculo.datacadastro = Convert.ToDateTime(dtpDatacadastro.Text);
            //veiculo.datacadastro = Convert.ToDateTime(dtpDatacadastro.Text);
            if (dtpDatacadastro.Value.Date >= dtpDatavenda.Value.Date)
                erro += "data de venda é anterior a de cadastro";
            else
                veiculo.datavenda = Convert.ToDateTime(dtpDatavenda.Text);
            //if (dtpDatacadastro.Text != "" && dtpDatavenda.Text != "")
            //{
            //    DateTime Inicio, Final;
            //    Inicio = Convert.ToDateTime(dtpDatacadastro.Text);
            //    Final = Convert.ToDateTime(dtpDatacadastro.Text);

            //    if (Inicio < Final)
            //        erro += "Informe um Periodo Final maior que o Periodo Inicial\n";
            //}
            //else
            //     if (dtpDatacadastro.Text != "" || dtpDatavenda.Text != "")
            //    erro += "Informe a Data Inicial e Final\n";
            veiculo.observacoes = ttbObservacao.Text;
            try
            {
                veiculo.valor = Convert.ToDecimal(ttbValor.Text);
                if(veiculo.valor<=0)
                    erro += "Valor invalido\n";

            }
            catch
            {
                erro += "Valor invalido\n";
            }
            
            if (ckbAtivo.Checked)
                veiculo.ativo = 's';
            else
                veiculo.ativo = 'n';

            return erro;

        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            string erros = valida();
            if (erros.Equals(""))
            {
                DAOVeiculo.Gravar(veiculo);
                MessageBox.Show("Veiculo Cadastrado");
                inicializa();
            }
            else
                MessageBox.Show(erros);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicializa();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            inicializaIncluir();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (veiculo.codigo.ToString().Equals(""))
            {

                MessageBox.Show("Não é possivel excluir esse Veiculo");
                return;
            }
            if (MessageBox.Show("Confirma exclusão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DAOVeiculo.Excluir(veiculo);
                inicializa();
            }
        }

        private void dtpDatavenda_ValueChanged(object sender, EventArgs e)
        {
             
        }

        private void ttbValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void ttbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != ',')
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
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
    }
}

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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void fabricanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFabricante fabricante = new frmCadFabricante();
            fabricante.ShowDialog();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadModelo modelo = new frmCadModelo();
            modelo.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCliente cliente = new frmCadCliente();
            cliente.ShowDialog();
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadVeiculo veiculo = new frmCadVeiculo();
            veiculo.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCadFabricante fabricante = new frmCadFabricante();
            fabricante.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fabricanteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLocFabricante fabricante = new frmLocFabricante();
            fabricante.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCadModelo modelo = new frmCadModelo();
            modelo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCadCliente cliente = new frmCadCliente();
            cliente.ShowDialog();
        }

        private void modeloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLocModelo modelo = new frmLocModelo();
            modelo.ShowDialog();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLocCliente cliente = new frmLocCliente();
            cliente.ShowDialog();
        }

        private void veiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocVeiculos veiculo = new frmLocVeiculos();
            veiculo.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmLocFabricante fabricante = new frmLocFabricante();
            fabricante.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmLocModelo modelo = new frmLocModelo();
            modelo.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmLocCliente cliente = new frmLocCliente();
            cliente.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmLocVeiculos veiculo = new frmLocVeiculos();
            veiculo.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCadVeiculo veiculo = new frmCadVeiculo();
            veiculo.ShowDialog();
        }
    }
}

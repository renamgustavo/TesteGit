using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLibraryCadVeiculos.Classes
{
    public class CadVeiculo
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string ncliente { get; set; }
        public string nmodelo { get; set; }
        public int cliente { get; set; }
        public int modelo { get; set; }
        public decimal valor { get; set; }
        public DateTime datacadastro { get; set; }
        public DateTime datavenda { get; set; }
        public string observacoes { get; set; }
        public char ativo { get; set; }

        public CadVeiculo()
        {
            codigo = 0;
            descricao = "";
            cliente = 0;
            modelo = 0;
            valor = 0;
            datacadastro = DateTime.Now.Date;
            datavenda = DateTime.Now.Date;
            observacoes = "";
            ativo = 'N';
        }
        public CadVeiculo(int codigo, string descricao, int cliente, int modelo, decimal valor, DateTime datacadastro, DateTime datavenda, string observacoes, char ativo)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.cliente = cliente;
            this.modelo = modelo;
            this.valor = valor;
            this.datacadastro = datacadastro;
            this.datavenda = datavenda;
            this.observacoes = observacoes;
            this.ativo = ativo;
        }
    }
}

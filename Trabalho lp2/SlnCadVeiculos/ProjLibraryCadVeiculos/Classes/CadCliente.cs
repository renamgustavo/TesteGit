using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLibraryCadVeiculos.Classes
{
    public class CadCliente
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string observacoes { get; set; }

        public CadCliente()
        {
            codigo = 0;
            nome = "";
            telefone = "";
            observacoes = "";

        }
        public CadCliente(int codigo, string nome, string telefone, string observacoes)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.telefone = telefone;
            this.observacoes = observacoes;
        }
    }
}

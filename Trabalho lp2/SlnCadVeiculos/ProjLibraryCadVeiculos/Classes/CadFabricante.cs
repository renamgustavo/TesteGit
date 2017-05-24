using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLibraryCadVeiculos.Classes
{
    public class CadFabricante
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        public CadFabricante()
        {
            codigo = 0;
            nome = "";
        }
        public CadFabricante(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }
    }
}

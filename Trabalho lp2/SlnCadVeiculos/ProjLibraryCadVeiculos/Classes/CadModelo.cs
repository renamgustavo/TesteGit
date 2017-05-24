using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLibraryCadVeiculos.Classes
{
    public class CadModelo
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public int fabricante { get; set; }
        public string nFabricante { get; set; }

        public CadModelo()
        {
            codigo = 0;
            descricao = "";
            fabricante = 0;

        } 
        public CadModelo(int codigo, string descricao, int fabricante)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.fabricante = fabricante;
        }
    }
}

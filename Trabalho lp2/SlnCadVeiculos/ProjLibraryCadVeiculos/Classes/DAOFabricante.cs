using ProjBibliotecaBancoDeDados.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjLibraryCadVeiculos.Classes
{
    public class DAOFabricante
    {
        public static void Gravar(CadFabricante fabricante)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql;

                if (fabricante.codigo == 0)
                    sql = "insert into fabricantes (nome) values (@nome)";
                else
                    sql = "update fabricantes set nome = @nome where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@codigo", fabricante.codigo);
                cmd.Parameters.AddWithValue("@nome", fabricante.nome);

                con.Open();
                cmd.ExecuteNonQuery();
                if (fabricante.codigo == 0)
                    fabricante.codigo = Banco.GetIdentity(con);
            }
        }

       

        public static void Excluir(CadFabricante fabricante)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "delete from fabricantes where codigo = @codigo";
    
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", fabricante.codigo);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Impossivel excluir esse fabricante \n Existe modelo(s) que utilizam ele");
                }

                
            }
        }

        public static bool LocaliarObjetos(CadFabricante fabricante)
        {
            bool achou = false;
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "select codigo, nome from fabricantes where codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", fabricante.codigo);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        fabricante.nome = dr["nome"].ToString();
                        achou = true;
                    }
                        

                }
            }
                return achou;
        }

        public static List<CadFabricante> LocalizarNome(string nome)
        {
            List<CadFabricante> lista = new List<CadFabricante>();
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "";
                if (nome.Equals(""))
                {
                    sql = "select codigo, nome from fabricantes ";

                }
                else
                {
                    sql = "select codigo, nome from fabricantes where nome like @nome order by nome";
                    
                  
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                
                if (!nome.Equals(""))
                    cmd.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CadFabricante fabricante = new CadFabricante();
                        fabricante.codigo = Convert.ToInt32(dr["codigo"]);
                        fabricante.nome = dr["nome"].ToString();
                        lista.Add(fabricante);
                    }
                }
            }
            return lista;
        }
    }
}

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
    public class DAOModelo
    {
        private static object modelo;

        public static void Gravar(CadModelo modelo)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql;

                if (modelo.codigo == 0)
                    sql = "insert into modelos (descricao,fabricante) values (@descricao,@fabricante)";
                else
                    sql = "update modelos set descricao = @descricao, fabricante = @fabricante where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@codigo",modelo.codigo);
                cmd.Parameters.AddWithValue("@descricao",modelo.descricao);
                cmd.Parameters.AddWithValue("@fabricante", modelo.fabricante);

                con.Open();
                cmd.ExecuteNonQuery();

                if(modelo.codigo == 0)
                    modelo.codigo = Banco.GetIdentity(con); 
            }

        }

        public static void Excluir(CadModelo modelo)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "delete from modelos where codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo",modelo.codigo);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Impossivel excluir esse modelo\nModelo possui vinculo com veiculo(s)");
                }
                
            }
        }

        public static bool LocalizarObjeto(CadModelo modelo)
        {

            bool achou = false;

            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "select codigo, descricao, fabricante from modelos where codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", modelo.codigo);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        modelo.descricao = dr["descricao"].ToString();
                        modelo.fabricante = Convert.ToInt32(dr["fabricante"]);

                        achou = true;

                    }
                }
            }

                return achou;
        }
        public static List<CadModelo> LocalizarNome(string descricao)
        {
            List<CadModelo> lista = new List<CadModelo>();
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "";
                if (descricao.Equals(""))
                {
                    sql = "select m.codigo, m.descricao,f.nome as fabricante, f.codigo as cf from modelos m inner join fabricantes f on f.codigo = m.fabricante;";
                }
                else
                {
                    sql = "select m.codigo, m.descricao,f.nome as fabricante, f.codigo as cf from modelos m inner join fabricantes f on f.codigo = m.fabricante where descricao like @descricao order by descricao";
                }

                SqlCommand cmd = new SqlCommand(sql, con);

                if (!descricao.Equals(""))
                    cmd.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CadModelo modelo = new CadModelo();
                        modelo.codigo = Convert.ToInt32(dr["codigo"]);
                        modelo.descricao = dr["descricao"].ToString();
                        modelo.fabricante = Convert.ToInt32(dr["cf"]);
                        modelo.nFabricante= dr["fabricante"].ToString();
                        lista.Add(modelo);
                    }
                }
            }
            return lista;
        }
        public static void Gravar(object modelo)
        {
            throw new NotImplementedException();
        }
    }
}

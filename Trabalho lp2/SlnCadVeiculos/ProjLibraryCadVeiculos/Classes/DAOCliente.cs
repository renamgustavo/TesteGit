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
    public class DAOCliente
    {
        private static CadCliente cliente;

        public static void Gravar(CadCliente cliente)
        {
            using (SqlConnection  con =  new SqlConnection(Banco._strCon))
            {
                string sql;

                if (cliente.codigo == 0)
                    sql = "insert into clientes (nome,telefone,observacoes) values (@nome,@telefone,@observacoes);";
                else
                    sql = "update clientes set nome = @nome, telefone = @telefone, observacoes = @observacoes where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@codigo", cliente.codigo);
                cmd.Parameters.AddWithValue("@nome", cliente.nome);
                cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
                cmd.Parameters.AddWithValue("@observacoes", cliente.observacoes);

                con.Open();
                cmd.ExecuteNonQuery();
                if (cliente.codigo == 0)
                    cliente.codigo = Banco.GetIdentity(con);
            }

        }


        public static void Excluir (CadCliente cliente)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "delete from clientes where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", cliente.codigo);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Impossivel excluir o cliente \n Ele está atrelado a um veiculo");
                }
                
            }
        }

        public static bool LocalizarObjeto(CadCliente cliente)
        {
            bool achou = false;

            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "select codigo,nome,telefone,observacoes from clientes where codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", cliente.codigo);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        cliente.nome = dr["nome"].ToString();
                        cliente.telefone = dr["telefone"].ToString();
                        cliente.observacoes = dr["observacoes"].ToString();
                        achou = true;
                    }
                }

            }

                return achou;
        }

        public static List<CadCliente> LocalizarNome(string nome)
        {
            List<CadCliente> lista = new List<CadCliente>();
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "";
                if (nome.Equals(""))
                {
                    sql = "select codigo, nome,telefone,observacoes from clientes ";

                }
                else
                {
                    sql = "select codigo, nome,telefone,observacoes from clientes where nome like @nome order by nome";


                }

                SqlCommand cmd = new SqlCommand(sql, con);

                if (!nome.Equals(""))
                    cmd.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CadCliente cliente = new CadCliente();
                        cliente.codigo = Convert.ToInt32(dr["codigo"]);
                        cliente.nome = dr["nome"].ToString();
                        cliente.telefone = dr["telefone"].ToString();
                        cliente.observacoes = dr["observacoes"].ToString();
                        lista.Add(cliente);
                    }
                }
            }
            return lista;
        }
    }
}

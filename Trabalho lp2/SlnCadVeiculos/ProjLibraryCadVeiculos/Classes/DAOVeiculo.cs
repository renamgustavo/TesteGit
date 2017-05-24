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
    public class DAOVeiculo
    {
        private static object veiculo;

        public static object MessagemBox { get; private set; }

        public static void Gravar(CadVeiculo veiculo)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql ;

                if (veiculo.codigo == 0)
                    sql = "insert into veiculos (descricao,cliente,modelo,valor,datacadastro,datavenda,observacoes,ativo) values (@descricao,@cliente,@modelo,@valor,@datacadastro,@datavenda,@observacoes,@ativo)";
                else
                    sql = "update veiculos set descricao = @descricao, cliente = @cliente, modelo = @modelo, valor = @valor, datacadastro = @datacadastro, datavenda = @datavenda, observacoes = @observacoes, ativo = @ativo where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@codigo", veiculo.codigo);
                cmd.Parameters.AddWithValue("@descricao", veiculo.descricao);
                cmd.Parameters.AddWithValue("@cliente", veiculo.cliente);
                cmd.Parameters.AddWithValue("@modelo", veiculo.modelo);
                cmd.Parameters.AddWithValue("@valor", veiculo.valor);
                cmd.Parameters.AddWithValue("@datacadastro", veiculo.datacadastro);
                cmd.Parameters.AddWithValue("@datavenda", veiculo.datavenda);
                cmd.Parameters.AddWithValue("@observacoes", veiculo.observacoes);
                cmd.Parameters.AddWithValue("@ativo", veiculo.ativo);

                con.Open();
                cmd.ExecuteNonQuery();

                if (veiculo.codigo == 0)
                    veiculo.codigo = Banco.GetIdentity(con);

            }
        }



        public static void Excluir(CadVeiculo veiculo)
        {
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "delete from veiculos where codigo = @codigo";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo",veiculo.codigo);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Impossivel excluir esse veiculo");
                }
                
            }
        }


        public static bool LocalizarObjeto(CadVeiculo veiculo)
        {
            bool achou = false;
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "select codigo, descricao, cliente, modelo, valor, datacadastro, datavenda,observacoes,ativo from veiculos where codigo = @codigo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", veiculo.codigo);
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        veiculo.descricao = dr["descricao"].ToString();
                        veiculo.observacoes = dr["observacoes"].ToString();
                        veiculo.cliente = Convert.ToInt32(dr["cliente"]);
                        veiculo.modelo = Convert.ToInt32(dr["modelo"]);
                        veiculo.valor = Convert.ToDecimal(dr["valor"]);
                        veiculo.datacadastro = Convert.ToDateTime(dr["datacadastro"]);
                        veiculo.datavenda = Convert.ToDateTime(dr["datavenda"]);
                        veiculo.ativo = Convert.ToChar(dr["ativo"]);

                        achou = true;
                    }
                }
            }

                return achou;
        }

        public static List<CadVeiculo> LocalizarNome(string desc)
        {
            List<CadVeiculo> lista = new List<CadVeiculo>();
            using (SqlConnection con = new SqlConnection(Banco._strCon))
            {
                string sql = "";
                if(desc.Equals(""))
                {
                    sql = "select v.codigo, v.descricao, c.nome as cliente, c.codigo as cc, m.descricao as modelo, m.codigo as cm, v.valor, v.datacadastro,v.datavenda,v.observacoes,v.ativo from veiculos v inner join clientes c on v.cliente = c.codigo inner join modelos m on m.codigo = v.modelo";
                                                                                                                                                                                             
                }
                else
                {
                    sql = "select v.codigo, v.descricao, c.nome as cliente, c.codigo as cc, m.descricao as modelo, m.codigo as cm, v.valor, v.datacadastro,v.datavenda,v.observacoes,v.ativo from veiculos v inner join clientes c on v.cliente = c.codigo inner join modelos m on m.codigo = v.modelo where v.descricao like @descricao order by descricao";
                }

                SqlCommand cmd = new SqlCommand(sql, con);
                if (!desc.Equals(""))
                    cmd.Parameters.AddWithValue("@descricao","%" +desc.Trim()+"%");

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        CadVeiculo veiculo = new CadVeiculo();
                        veiculo.codigo = Convert.ToInt32(dr["codigo"]);
                        veiculo.descricao = dr["descricao"].ToString();
                        veiculo.cliente = Convert.ToInt32(dr["cc"]);
                        veiculo.ncliente = dr["cliente"].ToString();
                        veiculo.modelo = Convert.ToInt32(dr["cm"]);
                        veiculo.nmodelo = dr["modelo"].ToString();
                        veiculo.valor = Convert.ToDecimal(dr["valor"]);
                        veiculo.datacadastro = Convert.ToDateTime(dr["datacadastro"]);
                        veiculo.datavenda = Convert.ToDateTime(dr["datavenda"]);
                        veiculo.observacoes = dr["observacoes"].ToString();
                        veiculo.ativo = Convert.ToChar(dr["ativo"]);

                        lista.Add(veiculo);
                    }
                }
            } 
                return lista;
        }
    }
}

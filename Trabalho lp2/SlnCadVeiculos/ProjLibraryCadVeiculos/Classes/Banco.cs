using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjBibliotecaBancoDeDados.Classes
{
    public class Banco
    {
        private static string _caminhoExe = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath));
#if DEBUG
        private static string _caminhoBanco = Path.Combine(Directory.GetParent(_caminhoExe).Parent.FullName, "BancoDeDados", "Banco.mdf");
#else
        private static string _caminhoBanco = Path.Combine(_caminhoExe, "BancoDeDados", "Banco.mdf");
#endif
        public static string _strCon = string.Format(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Renam\Desktop\Trabalho lp2\SlnCadVeiculos\ProjFormsCadVeiculos\BancoDeDados\Banco.mdf;Integrated Security = True");
                                                                                                                                                                                            

        public static int GetIdentity(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select @@IDENTITY as id", con);
            Object i = cmd.ExecuteScalar();
            if (i != DBNull.Value)
                return Convert.ToInt32(i);
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory
    {
        private SqlConnection conexao;

        public SqlConnection Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }
        private SqlCommand comando;

        public SqlCommand Comando
        {
            get { return comando; }
            set { comando = value; }
        }

        public string connectionName = "ConexaoHoracio";

        public ConnectionFactory()
        {
            string strConn = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            conexao = new SqlConnection(strConn);
        }

        public bool TestarConexao()
        {
            bool conectado = false;

            try
            {
                conexao.Open();
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conectado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            return conectado;
        }
    }
}

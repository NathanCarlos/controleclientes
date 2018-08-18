using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class StatusClienteDAL
    {
        ConnectionFactory cf;
        public List<StatusCliente> FindAll()
        {
            cf = new ConnectionFactory();
            string query = "SELECT id_status, desc_status FROM status_cliente";
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query;
            cf.Conexao.Open();

            List<StatusCliente> lista = new List<StatusCliente>();
            SqlDataReader dr = cf.Comando.ExecuteReader();
            while (dr.Read())
            {
                StatusCliente s = new StatusCliente();
                s.Id = Convert.ToInt32(dr["id_status"]);
                s.Descricao = Convert.ToString(dr["desc_status"]);
                lista.Add(s);
            }
            cf.Conexao.Close();
            return lista;
        }
    }
}

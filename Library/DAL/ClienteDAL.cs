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
    public class ClienteDAL
    {
        ConnectionFactory cf = new ConnectionFactory();
        public void Insert(Cliente c) 
        {
            cf = new ConnectionFactory();
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO cliente ");
            query.AppendLine("(nome_cli, endereco_cli, email_cli, telefone_cli, status_cli) ");
            query.AppendLine("VALUES (@CLI_NOME, @CLI_ENDERECO, @CLI_EMAIL, @CLI_TELEFONE, @CLI_STATUS) ");
            query.AppendLine("SELECT SCOPE_IDENTITY(); ");
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.Parameters.AddWithValue("CLI_NOME", c.Nome);
            cf.Comando.Parameters.AddWithValue("CLI_ENDERECO", c.Endereco);
            cf.Comando.Parameters.AddWithValue("CLI_EMAIL", c.Email);
            cf.Comando.Parameters.AddWithValue("CLI_TELEFONE", c.Telefone);
            cf.Comando.Parameters.AddWithValue("CLI_STATUS", Convert.ToInt32(c.Status));

            cf.Comando.CommandType = CommandType.Text;

            cf.Comando.CommandText = query.ToString();

            cf.Conexao.Open();

            c.Id = Convert.ToInt32(cf.Comando.ExecuteScalar());

            cf.Conexao.Close();
        }
        public List<Cliente> FindAll()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT a.id_cli, a.nome_cli, a.endereco_cli, a.email_cli, a.telefone_cli, b.desc_status ");
            query.AppendLine("FROM cliente a");
            query.AppendLine("INNER JOIN status_cliente b ON a.status_cli = b.id_status");

            cf = new ConnectionFactory();
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();

            List<Cliente> listaCliente = new List<Cliente>();
            cf.Conexao.Open();
            SqlDataReader reader = cf.Comando.ExecuteReader();

            while(reader.Read()){
                Cliente c = new Cliente();
                c.Id = Convert.ToInt32(reader["id_cli"]);
                c.Nome = reader["nome_cli"].ToString();
                c.Endereco = reader["endereco_cli"].ToString();
                c.Email = reader["email_cli"].ToString();
                c.Telefone = reader["telefone_cli"].ToString();
                c.Desc_status = reader["desc_status"].ToString();

                listaCliente.Add(c);
            }
            cf.Conexao.Close();
            return listaCliente;
        }
        public Cliente FindById(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT a.id_cli, a.nome_cli, a.endereco_cli, a.email_cli, a.telefone_cli, a.status_cli ");
            query.AppendLine("FROM cliente a");
            query.AppendLine("INNER JOIN status_cliente b ON a.status_cli = b.id_status");
            query.AppendLine("WHERE id_cli = @id_cli");

            cf = new ConnectionFactory();
            cf.Comando = cf.Conexao.CreateCommand();
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();

            cf.Comando.Parameters.AddWithValue("@id_cli", id);

            Cliente c = null;
            cf.Conexao.Open();
            SqlDataReader reader = cf.Comando.ExecuteReader();

            if (reader.Read())
            {
                c = new Cliente();
                c.Id = Convert.ToInt32(reader["id_cli"]);
                c.Nome = reader["nome_cli"].ToString();
                c.Endereco = reader["endereco_cli"].ToString();
                c.Email = reader["email_cli"].ToString();
                c.Telefone = reader["telefone_cli"].ToString();
                c.Status = Convert.ToInt32(reader["status_cli"]);
            }
            cf.Conexao.Close();
            return c;
            
        }
        public int Update(Cliente c)
        {
            cf = new ConnectionFactory();
            StringBuilder query = new StringBuilder();
            int linhasAfetados = 0;
            query.AppendLine("UPDATE cliente SET");
            query.AppendLine("nome_cli = @NOME_CLI, ");
            query.AppendLine("endereco_cli = @ENDERECO_CLI, ");
            query.AppendLine("email_cli = @EMAIL_CLI, ");
            query.AppendLine("telefone_cli = @TELEFONE_CLI, ");
            query.AppendLine("status_cli = @STATUS_CLI ");
            query.AppendLine("WHERE id_cli = @ID_CLI ");

            cf.Comando = cf.Conexao.CreateCommand();

            cf.Comando.Parameters.AddWithValue("@NOME_CLI", c.Nome);
            cf.Comando.Parameters.AddWithValue("@ENDERECO_CLI", c.Endereco);
            cf.Comando.Parameters.AddWithValue("@EMAIL_CLI", c.Email);
            cf.Comando.Parameters.AddWithValue("@TELEFONE_CLI", c.Telefone);
            cf.Comando.Parameters.AddWithValue("@STATUS_CLI", c.Status);
            cf.Comando.Parameters.AddWithValue("@ID_CLI", c.Id);
            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();
            cf.Conexao.Open();

            linhasAfetados = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();
            return linhasAfetados;
        }
        public int Delete(int id)
        {
            cf = new ConnectionFactory();
            StringBuilder query = new StringBuilder();
            int linhasAfetadas = 0;

            query.AppendLine("DELETE FROM cliente ");
            query.AppendLine("WHERE id_cli = @ID ");

            cf.Comando = cf.Conexao.CreateCommand();

            cf.Comando.Parameters.AddWithValue("@ID", id);

            cf.Comando.CommandType = CommandType.Text;
            cf.Comando.CommandText = query.ToString();
            cf.Conexao.Open();

            linhasAfetadas = cf.Comando.ExecuteNonQuery();
            cf.Conexao.Close();

            return linhasAfetadas;
        }
    }
}

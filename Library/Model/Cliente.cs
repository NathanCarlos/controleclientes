using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Cliente
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string desc_status;

        public string Desc_status
        {
            get { return desc_status; }
            set { desc_status = value; }
        }

    }
}

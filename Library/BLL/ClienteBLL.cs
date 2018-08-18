using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ClienteBLL
    {
        public bool Insert(Cliente c)
        {
            bool salvou = false;
            new ClienteDAL().Insert(c);

            if (c.Id > 0)
            {
                salvou = true;
            }
            return salvou;
        }
        public List<Cliente> FindALL()
        {
            ClienteDAL cDAL = new ClienteDAL();
            return cDAL.FindAll();
        }
        public Cliente FindById(int id)
        {
            ClienteDAL cDAL = new ClienteDAL();
            return cDAL.FindById(id);
        }
        public bool Update(Cliente c)
        {
            bool atualizou = false;
            ClienteDAL dDAL = new ClienteDAL();
            if (c.Id == 0)
            {
                throw new Exception("Selecione uma pessoa para atualziar");
            }
            if (dDAL.Update(c) > 0)
            {
                atualizou = true;
            }
            return atualizou;
        }
        public bool Delete(int id)
        {
            bool deletou = false;
            ClienteDAL dDAL = new ClienteDAL();
            if (dDAL.Delete(id) > 0)
            {
                deletou = true;
            }
            return deletou;
        }
    }
}

using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL
{
    public class StatusClienteBLL
    {
        public List<StatusCliente> FindAll()
        {
            StatusClienteDAL dal = new StatusClienteDAL();
            return dal.FindAll();
        }
    }
}

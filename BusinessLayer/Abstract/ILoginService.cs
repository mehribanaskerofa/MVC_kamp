using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {
        List<Admin> GetListBL();

        void AdminAddBL(Admin admin);

        void AdminDeleteBL(Admin admin);

        void AdminUpdateBL(Admin admin);

        Admin GetByIDBL(int id);

        Admin GetAdmin(string username, string password);

        
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public void AdminAddBL(Admin admin)
        {
            _loginDal.Insert(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            _loginDal.Delete(admin);
        }

        public void AdminUpdateBL(Admin admin)
        {
            _loginDal.Update(admin);
        }

        public Admin GetAdmin(string username, string password)
        {
            return _loginDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }

        public Admin GetByIDBL(int id)
        {
            return _loginDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetListBL()
        {
            return _loginDal.List();
        }

    }
    }

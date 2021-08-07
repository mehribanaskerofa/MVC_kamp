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
    public class RolesManager : IRoles
    {
        IRolesDal _rolesDal;

        public RolesManager(IRolesDal rolesDal)
        {
            _rolesDal = rolesDal;
        }

        public List<Roles> GetRoles()
        {
            return _rolesDal.List();
        }
    }
}

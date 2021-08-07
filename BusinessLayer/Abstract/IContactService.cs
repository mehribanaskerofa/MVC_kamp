using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetListBL();

        void ContactAddBL(Contact contact);

        void ContactDeleteBL(Contact contact);

        void ContactUpdateBL(Contact contact);

        Contact GetByIDBL(int id);
    }
}

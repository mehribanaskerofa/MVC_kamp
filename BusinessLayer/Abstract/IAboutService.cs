using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetListBL();

        void AboutAddBL(About about);

        void AboutDeleteBL(About about);

        void AboutUpdateBL(About about);

        About GetByIDBL(int id);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetListBL();

        List<Heading> GetListByWriterBL(int id);

        List<Heading> GetListByCategoryBL(int id);

        void HeadingAddBL(Heading heading);

        void HeadingDeleteBL(Heading heading);

        void HeadingUpdateBL(Heading heading);

        Heading GetByIDBL(int id);
    }
}

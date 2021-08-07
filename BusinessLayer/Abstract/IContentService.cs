using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetListBL();

        List<Content> GetListByHeadingIDBL(int id);

        void ContentAddBL(Content content);

        void ContentDeleteBL(Content content);

        void ContentUpdateBL(Content content);

        Content GetByIDBL(int id);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetListBL();

        void TalentAddBL(Talent talent);

        void TalentDeleteBL(Talent talent);

        void TalentUpdateBL(Talent  talent);

        Talent GetByIDBL(int id);
    }
}

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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public Talent GetByIDBL(int id)
        {
            return _talentDal.Get(x=>x.TalentId==id);
        }

        public List<Talent> GetListBL()
        {
            return _talentDal.List();
        }

        public void TalentAddBL(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void TalentDeleteBL(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public void TalentUpdateBL(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}

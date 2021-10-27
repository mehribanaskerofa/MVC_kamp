using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllMessage();

        List<Message> GetListInbox(string p);

        List<Message> GetListSendbox(string p);

        void MessageAddBL(Message message);

        void MessageDeleteBL(Message message);

        void MessageUpdate(Message message);

        Message GetByID(int id);
    }
}

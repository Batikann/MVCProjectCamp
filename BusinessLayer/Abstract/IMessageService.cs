using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IServiceBase<Message>
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSenbox(string p);
        List<Message> GetListReadMessage();
        List<Message> GetListUnReadMessage();
        List<Message> GetDraftBox();
    }
}

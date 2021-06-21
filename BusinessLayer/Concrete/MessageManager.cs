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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(x=>x.MessageID==id);
        }

        public List<Message> GetList()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListReadMessage()
        {
            return _messageDal.List(x => x.IsRead == true);
        }

        public List<Message> GetListSenbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.IsDraft==false);
        }

        public List<Message> GetDraftBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == true);
        }


        public List<Message> GetListUnReadMessage()
        {
            return _messageDal.List(x=>x.IsRead==false);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}

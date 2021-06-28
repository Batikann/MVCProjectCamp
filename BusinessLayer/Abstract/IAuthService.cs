using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(string adminUserName,string adminMail, string password);
        bool AdminLogIn(LoginDto loginDto);

        void WriterRegister(string writerName, string writerSurname, string writerUserName, string writerMail, string writerPassword);
        bool WriterLogin(WriterLoginDto writerLoginDto);
    }
}

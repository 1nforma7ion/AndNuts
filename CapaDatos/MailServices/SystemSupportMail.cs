using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.MailServices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail()
        {
            senderMail = "facundonl99@gmail.com";
            password = "Onepiece99";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;

            initializeSmtpClient();
        }
    }
}

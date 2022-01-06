using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
   public class MailSettingAddViews
    {
        public string SenderInformation { get; set; }

        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string MailSender { get; set; }
        public string Email { get; set; }
        public string EmailPass { get; set; }
    }
}

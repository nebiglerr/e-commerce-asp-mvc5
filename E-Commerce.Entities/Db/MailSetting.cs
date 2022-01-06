using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public class MailSetting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SenderInformation { get; set; }

        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string MailSender { get; set; }
        public string Email { get; set; }
        public string EmailPass { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Entities
{
    public class ContactUS
    {
        public string EmailFrom { get; set; }
        public string SMTP { get; set; }
        public int SMTPPort { get; set; }
        public string UserName { get; set; }
        public string EmailPassword { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool EnableSsl { get; set; }
    }
}

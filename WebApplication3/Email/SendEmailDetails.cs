using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Email
{
    public class SendEmailDetails
    {
        //Name of the sender
        public string FromName { get; set; }

        public string Fommail { get; set; }

        public string ToName { get; set; }

        public string ToEmail { get; set; }

        public string Subject { get; set;}

        public string Content { get; set; }

        public bool IsHtml { get; set; }

    }
}

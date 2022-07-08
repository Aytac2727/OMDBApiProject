using System;
using System.Collections.Generic;
using System.Text;

namespace EmailServicee
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}

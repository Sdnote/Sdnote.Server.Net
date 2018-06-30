using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SdnoteServer.Service
{
    public class LocalMailService
    {
        private string _mailTo = "muzi@derwer.com ";
        private string _mailFrom = "noreply@leepush.com";

        public void Send(string subject, string msg)
        {
            //伪发送
            Debug.WriteLine($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailService)}发送了邮件");
        }
    }
}

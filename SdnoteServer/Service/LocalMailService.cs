using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SdnoteServer.Service
{
    public interface IMaillServer
    {
        void Send(string subject, string msg);
        
    }

    public class LocalMailServer : IMaillServer
    {
        private string _mailTo = "muzi@derwer.com";
        private string _mailFrom = "noreply@leepush.com";
        private readonly ILogger<LocalMailServer> _logger;

        public LocalMailServer(ILogger<LocalMailServer> logger)
        {
            _logger = logger;
        }

        public void Send(string subject, string msg)
        {
            //伪发送
            Debug.WriteLine($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailServer)}发送了邮件");
            _logger.LogInformation($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailServer)}发送了邮件");
        }
    }

    public class CloudMailServer : IMaillServer
    {
        private string _mailTo = "muzi@niconiconi.in";
        private string _mailFrom = "noreply@leepush.com";
        readonly ILogger<CloudMailServer> _logger;

        public CloudMailServer(ILogger<CloudMailServer> logger)
        {
            _logger = logger;
        }

        public void Send(string subject, string msg)
        {
            //伪发送
            //Debug.WriteLine($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailServer)}发送了邮件");
            _logger.LogInformation($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailServer)}发送了邮件");
        }
    }
}

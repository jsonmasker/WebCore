using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.SMSServices
{
    public interface ISMSService
    {
        public Task<bool> SendSMSAsync(string phoneNumber, string message);
    }
}

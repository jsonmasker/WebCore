using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ConvertWordToPdfServices
{
    public interface IConvertWordToPdfService
    {
        public Task<byte[]> ConvertWordToPdf(string filePath);
    }
}

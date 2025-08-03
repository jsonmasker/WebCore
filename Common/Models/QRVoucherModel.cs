using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class QRVoucherModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public QRVoucherModel()
        {
            Name = string.Empty;
            Code = string.Empty;
        }
    }
}

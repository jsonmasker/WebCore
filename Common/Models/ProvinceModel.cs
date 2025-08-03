using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DistrictModel> Districts { get; set; }
        public ProvinceModel()
        {
            Name = string.Empty;
            Districts = new List<DistrictModel>();
        }
    }
    public class DistrictModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    public class Parameter
    {
        public int Id {  get; set; }

        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ParameterValue> ParameterValues { get; set; } = new List<ParameterValue>();
    }
}

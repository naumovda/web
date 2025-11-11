using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    public class ParameterValue
    {
        public int ParameterId { get; set; }

        public Parameter Parameter { get; set; } = null!;

        public int MakeupId { get; set; }

        public Makeup Makeup { get; set; } = null!;

        public double? Value { get; set; }
    }
}

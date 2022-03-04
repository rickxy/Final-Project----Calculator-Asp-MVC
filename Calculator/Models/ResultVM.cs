using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class ResultVM
    {
        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public string CommandText { get; set; }
        public double Result { get;  set; }
        public string CommandOperator { get;  set; }
    }
}

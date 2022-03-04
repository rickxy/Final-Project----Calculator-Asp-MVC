using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Helpers
{
    public class StringHelper
    {
        public static string GetOperator(string command)
        {
            string op= "";
            if (string.IsNullOrEmpty(command))
                return op;

            switch (command.ToLower())
            {
                case "add":
                    op = "+";
                    break;
                case "sub":
                    op = "-";
                    break;
                case "mul":
                    op = "*";
                    break;
                case "div":
                    op = "/";
                    break;
                default:
                    break;
            }

            return op;
        }
    }
}

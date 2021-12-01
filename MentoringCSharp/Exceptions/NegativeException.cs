using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Exceptions
{
    public class NegativeException : Exception
    {
        public NegativeException() : base("Value is Negative!") { }

        public NegativeException(string msg) : base(msg) { }
        
        public NegativeException(string msg, Exception ex) : base(msg, ex) { }
    }
}

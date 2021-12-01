using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Exceptions
{
    public class OddException : Exception
    {
        public OddException() : base("The number is odd.") { }
    }
}

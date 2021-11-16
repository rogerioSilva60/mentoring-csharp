using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Challenge
{
    public class AccessAttribute
    {
        int value = 10;

        public static void Execute()
        {
            //Access instance attribute without adding static to variable
            //Console.WriteLine(Value);
        }
    }
}

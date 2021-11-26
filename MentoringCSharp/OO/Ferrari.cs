using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.OO
{
    internal class Ferrari : Car
    {
        public Ferrari() : base(350)
        {
        }

        /*
            The override modifier only works if you have the virutal in the parent class's method. 
        */
        public override int SpeedUp()
        {
            return ChangeSpeed(15);
        }

        /*
            Hides the parent class method 
        */
        public new int Break()
        {
            return ChangeSpeed(-15);
        }
    }
}

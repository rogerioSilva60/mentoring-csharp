using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.OO
{
    internal class Car
    {
        protected readonly int MaximumSpeed;
        int CurrentSpeed;

        public Car(int maximumSpeed)
        {
            MaximumSpeed = maximumSpeed;
        }

        protected int ChangeSpeed(int delta)
        {
            int newSpeed = CurrentSpeed + delta;

            if(newSpeed < 0)
            {
                CurrentSpeed = 0;
            }
            else if (newSpeed > MaximumSpeed)
            {
                CurrentSpeed = MaximumSpeed;
            } else
            {
                CurrentSpeed = newSpeed;
            }
            return CurrentSpeed;
        }

        /*
            The virtual modifier is needed if you need to overwrite the method. 
        */
        public virtual int SpeedUp()
        {
            return ChangeSpeed(5);
        }

        public int Break()
        {
            return ChangeSpeed(-5);
        }
    }
}

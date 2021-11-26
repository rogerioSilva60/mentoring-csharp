using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.OO
{
    public class HeritageMain
    {
        public static void Execute()
        {
            Console.WriteLine("Onix...");
            Onix onix = new Onix();
            Console.WriteLine(onix.SpeedUp());
            Console.WriteLine(onix.SpeedUp());
            Console.WriteLine(onix.Break());
            Console.WriteLine(onix.Break());
            Console.WriteLine(onix.Break());

            Console.WriteLine("Ferrari...");
            Ferrari ferrari = new Ferrari();
            Console.WriteLine(ferrari.SpeedUp());
            Console.WriteLine(ferrari.SpeedUp());
            Console.WriteLine(ferrari.Break());
            Console.WriteLine(ferrari.Break());
            Console.WriteLine(ferrari.Break());
            Console.WriteLine();

            /* Polimorfismo */
            Console.WriteLine("Onix Car...");
            Car onixCar = new Onix();
            Console.WriteLine(onixCar.SpeedUp());
            Console.WriteLine(onixCar.SpeedUp());
            Console.WriteLine(onixCar.Break());
            Console.WriteLine(onixCar.Break());
            Console.WriteLine(onixCar.Break());

            Console.WriteLine("Ferrari Car...");
            Car ferrariCar = new Ferrari();
            Console.WriteLine(ferrariCar.SpeedUp());
            Console.WriteLine(ferrariCar.SpeedUp());
            Console.WriteLine(ferrariCar.Break());
            Console.WriteLine(ferrariCar.Break());
            Console.WriteLine(ferrariCar.Break());


            Console.ReadKey();
        }
    }
}

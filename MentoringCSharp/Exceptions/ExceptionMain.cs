using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Exceptions
{
    public class ExceptionMain
    {
        public static void Execute()
        {
            StandardException();
            Console.WriteLine();
            CustomException();
            Console.ReadKey();
        }

        public static void StandardException()
        {
            try
            {
                var account = new Account(1000);
                account.Withdraw(100);
                //OR
                //account.Withdraw(1100); Trigger the exception
                Console.WriteLine("Successful withdrawal!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Thanks!");
            }
        }

        public static void CustomException()
        {
            try
            {
                var value = PositiveAndPar();
                Console.WriteLine(value);
            }
            catch(NegativeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OddException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End");
            }
        }

        static int PositiveAndPar()
        {
            Random random = new Random();
            int value = random.Next(-30, 30);

            if (value < 0)
            {
                throw new NegativeException();
            }

            if (value % 2 == 1)
            {
                throw new OddException();
            }
            return value;
        }
    }
}

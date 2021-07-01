using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo
{
    class FuncAction
    {
       private static void cout(string txt)
        {
            Console.WriteLine(txt);
        }
        private static decimal Sum(decimal a, decimal b)
        {
            return a + b;
        }
        private static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        static void Main(string[] args)
        {
            Action<string> coutAction = cout;
            coutAction.Invoke("abcd");

            Func<decimal, decimal, decimal> sumFunc = new Func<decimal, decimal, decimal>(Sum);
            Console.WriteLine(sumFunc(10,10));

            Predicate<int> isEvenPredicate = IsEven;
            if (isEvenPredicate(32))
            {
                Console.WriteLine("Even");
            }
            else
            {
                Console.WriteLine("Odd");
            }
        }
    }
}

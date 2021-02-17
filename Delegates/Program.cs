using System;
using System.Linq;
using Learnings.Extensions;
using Learnings.Exceptions;
using System.Collections.Generic;

namespace Learnings
{
    public class Program
    {
       internal delegate void AdditionCallback(int a, int b);
        internal delegate bool EvenNumbersCallback(int number);


        static void Main(string[] args)
        {
            Calculator cal = new Calculator();

            AdditionCallback a, b, c;
            //EvenNumbersCallback numbersCallback = EvenNumber; 

            var numbers = Enumerable.Range(0, 100);


            var evenNumbers = numbers.Where(new Func<int, bool>(EvenNumber),
                new Func<IEnumerable<int>, Exception>(HandleException));


            
            //var evenNumbers = numbers.Where(delegate (int n)
            //{
            //    return n % 2 == 0;
            //});


            //var evenNumbers = numbers.Where(new Func<int, bool>(n => n % 2 == 0));
            // DynamicInvoke(c);

        }

        internal static Exception HandleException (IEnumerable<int> matched)
        {
            return new MovieServiceBaseException($"The amount matched was :{ matched.Count()}");

        }


        internal static bool EvenNumber(int n)
        {
            return n % 2 == 0;
        }


        static void DynamicInvoke(AdditionCallback acb)
        {
         
            for (int ctr = 0; ctr < acb.GetInvocationList().Length; ctr++)
            {
                (acb.GetInvocationList()[ctr]).DynamicInvoke(12, 30);
            }
        }

        public class Calculator
        {


            internal void Add(int a, int b)
            {
                Console.WriteLine("addition result: { " + (a + b) + " }");
            }

            public void Subtract(int a, int b)
            {
                Console.WriteLine("subtraction result: { " + (a - b) + " }");
            }
        }

    }
}

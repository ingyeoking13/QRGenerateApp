using System;

namespace Partial_Class_Property_Test
{
    partial class Program
    {
        public int MyProperty { get; set; }
        static void Main(string[] args)
        {
            var myP = new Program();
            myP.myNumber = 5;

            Console.WriteLine("Hello World!");
        }
    }
}

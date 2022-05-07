using System;

namespace lab_05
{
    public delegate void Print();
    public delegate int Max(int a);
    class Program
    {
        static void Main(string[] args)
        {
            
            Printer printer = new Printer();

            printer.print = () =>
            {
                Console.WriteLine("Wiadomosc");
            };

            Max max = delegate (int a)
            {
                return a*2;
            };

            Max min = (int a) =>
            {
                return a / 2;
            };



            printer.Print();

          
            
            Console.WriteLine(max(10));
            Console.WriteLine(min(30));
            Console.WriteLine("Hello World!");
        }
    }

    class Printer
    {
        public Print print;

        public void Print()
        {
            if (this.print != null)
                this.print();
        }
    }
}

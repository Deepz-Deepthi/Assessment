using System.ComponentModel;

namespace Question2
{
    public class Program
    {
        public static int Add(int a,int b,int c)
        {
            return a + b + c;
        }
        public static double Add(double a,double b,double c)
        {
            return a + b + c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Add(10, 20, 30));
            Console.WriteLine(Add(10.2, 20.3, 30.4));
        }
    }
}

using System;

namespace M11_01_01_Exceptions_SemExcepcao
{
    class Program
    {
        static void Main(string[] args)
        {
            string exemplo = "123";
            int teste = Int32.Parse(exemplo);
            Console.WriteLine($"Resultado da conversão: {teste}");

            Console.ReadKey();
        }
    }
}

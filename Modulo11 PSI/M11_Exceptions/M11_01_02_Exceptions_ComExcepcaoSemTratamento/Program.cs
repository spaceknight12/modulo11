using System;

namespace M11_01_02_Exceptions_ComExcepcaoSemTratamento
{
    class Program
    {
        static void Main(string[] args)
        {
            string exemplo = "123ab";
            int teste = Int32.Parse(exemplo);
            Console.WriteLine($"Resultado da conversão: {teste}");

            Console.ReadKey();
        }
    }
}

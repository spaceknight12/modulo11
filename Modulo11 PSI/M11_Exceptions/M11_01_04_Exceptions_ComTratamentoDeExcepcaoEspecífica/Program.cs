using System;

namespace M11_01_04_Exceptions_ComTratamentoDeExcepcaoEspecífica
{
    class Program
    {
        static void Main(string[] args)
        {
            string exemplo = "123ab";

            try
            {
                int teste = Int32.Parse(exemplo);
                Console.WriteLine($"Resultado da Conversão : {teste}");
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Erro Formatação !!!! -> {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

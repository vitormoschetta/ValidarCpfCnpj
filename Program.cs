using System;

namespace ValidarCpfCnpj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um CPF ou CNPJ");
            var doc = Console.ReadLine();

            bool valido = new Validar().ValidarCpfCnpj(doc);

            if (valido)
                Console.WriteLine("Documento Válido");
            else
                Console.WriteLine("Documento Inválido");

        }
    }
}

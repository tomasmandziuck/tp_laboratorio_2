using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Prueba_de_funcionamiento
{
    public class Program
    {
        static void Main(string[] args)
        {

            Numero num1 = new Numero(20);
            Numero num2 = new Numero(30);
            char operador = '*';
            double resultado;

            resultado = Calculadora.Operar(num1, num2, operador);
            

            Console.WriteLine(resultado);
            Console.ReadKey();
        }
    }
}

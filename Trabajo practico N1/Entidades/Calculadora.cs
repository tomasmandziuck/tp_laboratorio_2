using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            char retorno = '+';

            if(operador== '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador;
            }

            
            return retorno.ToString();
        }
        
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double total=0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    total = num1 + num2;
                    break;
                case "-":
                    total = num1 - num2;
                    break;
                case "/":
                    total = num1 / num2;
                    break;
                case "*":
                    total = num1 * num2;
                    break;
            }

            return total;
        }
    }
}

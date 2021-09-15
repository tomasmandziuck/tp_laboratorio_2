using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida el que el operador sea uno de los 4 permitidos 
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>devuelve el operador si es uno de los permitidos pasado a string 
        /// de lo contrario devuelve "+"</returns>
        private static string ValidarOperador(char operador)
        {
            char retorno = '+';

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador;
            }


            return retorno.ToString();
        }
        /// <summary>
        /// llama a ValidarOperador para validar el operador pasado por parametro 
        /// opera con los dos Numero de los parametros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>devuelve el resultado de la operacion </returns>
        public static double Operar(Numero num1, Numero num2, char operador)
        {
            double total = 0;

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

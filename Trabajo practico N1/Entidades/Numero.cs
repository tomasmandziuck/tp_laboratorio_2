using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// asigna un valor al atributo numero, previa validacion
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// llama al metodo EsBinario para verificar que el string pasado por parametro sea un numero binario
        /// Pasa el string binario a un array para convertirlo de binario a decimal
        /// </summary>
        /// <param name="binario">tipo string</param>
        /// <returns>devuelve el numero decimal pasado a string
        /// por defecto devuelve "valor invalido" si no puede hacer la conversion</returns>
        public static string BinarioDecimal(string binario)
        {
            char[] array;
            int suma = 0;
            string retorno = "Valor invalido";
            if (EsBinario(binario))
            {
                array = binario.ToCharArray();
                Array.Reverse(array);
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        suma += (int)Math.Pow(2, i);
                    }
                }
                retorno = suma.ToString();
            }
            return retorno;
        }
        /// <summary>
        /// transforma el numero pasado por parametro de decimal a binario
        /// </summary>
        /// <param name="numero">tipo double</param>
        /// <returns>devuelve el numero binario en formato string
        /// por defecto devuelve "valor invalido" si no puede hacer la conversion</returns>
        public static string DecimalBinario(double numero)
        {

            string cadena = "";
            string retorno = "valor invalido";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);

                }
                retorno = cadena;
            }
            return retorno;
        }
        /// <summary>
        /// pasa el string de parametro a double para poder llamar a la sobrecarga que recibe double
        /// </summary>
        /// <param name="numero">tipo string</param>
        /// <returns>devuelve el numero binario en formato string
        /// por defecto devuelve "valor invalido" si no puede hacer la conversion</returns>
        public static string DecimalBinario(string numero)
        {
            double aux;
            string retorno = "Valor invalido";
            if (double.TryParse(numero, out aux))
            {

                retorno = DecimalBinario(aux);
            }

            return retorno;
        }
        /// <summary>
        /// Valida que el binario pasado por parametro sea un numero binario
        /// </summary>
        /// <param name="binario">tipo string</param>
        /// <returns>devuelve por defecto false y devuelve true si se pudo verificar</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = false;
            int contador = 0;
            foreach (char aux in binario)
            {
                if (aux == '0' || aux == '1')
                {
                    retorno = true;
                    contador++;
                }
                if (contador != binario.Length)
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        /// <summary>
        /// constructor de instancia por defecto
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// Constructor de instancia con parametro tipo double
        /// </summary>
        /// <param name="numero">tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// constructor de instancia con parametro tipo string
        /// </summary>
        /// <param name="strNumero">tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// retorna el resultado de la resta de los campos numero 
        /// </summary>
        /// <param name="n1">Tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// retorna el resultado de la multiplicacion de los campos numero 
        /// </summary>
        /// <param name="n1">Tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// retorna el resultado de la division de los campos numero
        /// si el campo numero del Numero n2 es cero devuelve MinValue
        /// </summary>
        /// <param name="n1">Tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;

        }
        /// <summary>
        /// retorna el resultado de la suma de los campos numero 
        /// </summary>
        /// <param name="n1">Tipo Numero</param>
        /// <param name="n2">Tipo Numero</param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Valida que la cadena sea un valor numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private static double ValidarNumero(string strNumero)
        {
            double aux;
            double.TryParse(strNumero, out aux);
            return aux;
        }
    }

}

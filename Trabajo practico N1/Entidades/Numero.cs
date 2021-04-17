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

        public string SetNumero
        {
            set
            {
                this.numero=ValidarNumero(value);
            }
        }

        public static string BinarioDecimal(string binario)
        {
            char[] array;
            int suma = 0;
            string retorno="Valor invalido";
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

        public static string DecimalBinario(double numero)
        {

            string cadena = "";
            string retorno="valor invalido";
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
        private static bool EsBinario(string binario)
        {
            bool retorno = false;
            int contador=0;
            foreach(char aux in binario)
            {
                if(aux == '0' || aux == '1')
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

        public Numero():this(0)
        {
            
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        private static double ValidarNumero (string strNumero)
        {
            double aux;
            double.TryParse(strNumero, out aux);
            return aux;
        }
    }
}

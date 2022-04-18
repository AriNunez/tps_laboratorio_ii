using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Propiedad que asigna un valor validado de formato string en el atributo privado numero.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero):this()
        {
            this.numero = numero;
        }

        public Operando(string strNumero):this()
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Valida un valor recibido en formato string e intenta convertirlo a formato double.
        /// </summary>
        /// <param name="strNumero">Valor en formato string para validar</param>
        /// <returns>Retorna el valor recibido, ya convertido y en formato double</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero = 0;

            if(Double.TryParse(strNumero.Trim(),out numero))
            {
                return numero;
            }

            return numero;
        }

        /// <summary>
        /// Recibe un numero del cual obtiene unicamente su parte entera y positiva, y la convierte de decimal
        /// a binario. Luego retorna en formato string el resultado en binario.
        /// </summary>
        /// <param name="numero">Valor a convertir en binario</param>
        /// <returns>Retorna un valor en formato string que representa el binario</returns>
        public string DecimalBinario(double numero)
        {
            int numeroAbsoluto = (int)Math.Abs(numero);
            string binario = string.Empty;

            if(numeroAbsoluto == 0)
            {
                binario = "0";
            }
            else
            {
                while (numeroAbsoluto > 0)
                {
                    binario = (numeroAbsoluto % 2) + binario;
                    numeroAbsoluto = (int)numeroAbsoluto / 2;
                }
            }

            return binario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario en caso de ser posible.
        /// </summary>
        /// <param name="numero">Valor en formato string para convertir a binario</param>
        /// <returns>Retorna un string. Si se pudo convertir el valor a binario lo retorna, sino retorna un valor invalido</returns>
        public string DecimalBinario(string numero)
        {
            double numeroAuxiliar;
            if(Double.TryParse(numero,out numeroAuxiliar))
            {
                return DecimalBinario(numeroAuxiliar);
            }

            return "Valor inválido";
        }

        /// <summary>
        /// Valida que el valor recibido en formato string sea un binario, y luego lo convierte a decimal en caso
        /// de ser posible.
        /// </summary>
        /// <param name="binario">Valor de formato string para convertir</param>
        /// <returns>Retorna un string. Si se pudo convertir el valor a decimal lo retorna, sino retorna un valor invalido</returns>
        public string BinarioDecimal(string binario)
        {
            char[] arrayBinario = binario.ToCharArray();
            int numeroDecimal = 0;
            
            Array.Reverse(arrayBinario);

            if(EsBinario(binario))
            {
                for(int i = 0; i < arrayBinario.Length; i++)
                {
                    if(arrayBinario[i] == '1')
                    {
                        numeroDecimal += (int)Math.Pow(2, i);
                    }
                }

                return numeroDecimal.ToString();
            }

            return "Valor inválido";
        }

        /// <summary>
        /// Valida que el valor recibido en formato string sea un binario.
        /// </summary>
        /// <param name="binario">Valor en formato string para validar</param>
        /// <returns>Retorna true en caso de ser binario, o false si no lo es</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Realiza la suma entre los atributos numero de los dos Operando recibidos.
        /// </summary>
        /// <param name="n1">Primer valor para operar</param>
        /// <param name="n2">Segundo valor para operar</param>
        /// <returns>Retorna un double que contiene el resultado de la suma</returns>
        public static double operator +(Operando n1,Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la resta entre los atributos numero de los dos Operando recibidos.
        /// </summary>
        /// <param name="n1">Primer valor para operar</param>
        /// <param name="n2">Segundo valor para operar</param>
        /// <returns>Retorna un double que contiene el resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion entre los atributos numero de los dos Operando recibidos.
        /// </summary>
        /// <param name="n1">Primer valor para operar</param>
        /// <param name="n2">Segundo valor para operar</param>
        /// <returns>Retorna un double que contiene el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division en caso de ser posible entre los atributos numero de los dos Operando recibidos.
        /// </summary>
        /// <param name="n1">Primer valor para operar</param>
        /// <param name="n2">Segundo valor para operar</param>
        /// <returns>Si el segundo operando es distinto de cero, retorna un double que contiene el resultado de la division. 
        /// Si no lo es retorna el valor minimo de double.</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }

            return double.MinValue;
        }


    }
}

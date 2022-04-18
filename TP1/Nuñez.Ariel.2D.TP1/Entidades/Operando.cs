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
        /// 
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

        private double ValidarOperando(string strNumero)
        {
            double numero = 0;

            if(Double.TryParse(strNumero.Trim(),out numero))
            {
                return numero;
            }

            return numero;
        }

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

        public string DecimalBinario(string numero)
        {
            double numeroAuxiliar;
            if(Double.TryParse(numero,out numeroAuxiliar))
            {
                return DecimalBinario(numeroAuxiliar);
            }

            return "Valor inválido";
        }
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

        public static double operator +(Operando n1,Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
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

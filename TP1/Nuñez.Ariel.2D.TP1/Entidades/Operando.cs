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

        // constructores no se comentan
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

        //public static string BinarioDecimal(string binario)
        //{

        //}

        //public static string DecimalBinario(double numero)
        //{

        //}

        //public static string DecimalBinario(string numero)
        //{

        //}


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

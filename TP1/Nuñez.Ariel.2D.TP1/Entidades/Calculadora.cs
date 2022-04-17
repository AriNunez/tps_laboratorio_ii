using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            char operadorValidado;
            if (num1 != null && num2 != null)
            {
                operadorValidado = ValidarOperador(operador);


                switch (operadorValidado)
                {
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                }
            }
            return resultado;
        }

        private static char ValidarOperador(char operador)
        {
            
            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            else
            {
                return '+'; 

            }

        }
    }
}

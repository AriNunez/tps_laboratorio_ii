using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 
    public static class Calculadora
    {
        /// <summary>
        /// Realiza una operacion utilizando dos Operando y un operador.
        /// </summary>
        /// <param name="num1">Primer valor de formato Operando para operar</param>
        /// <param name="num2">Segundo valor de formato Operando para operar</param>
        /// <param name="operador">Operador en formato char para operar</param>
        /// <returns>Retorna el resultado de la operacion entre los valores recibidos en formato double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado=0;
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

        /// <summary>
        /// Valida un operador recibido de formato char.
        /// </summary>
        /// <param name="operador">Operador en formato char para validar</param>
        /// <returns>Retorna el operador validado en formato char</returns>
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

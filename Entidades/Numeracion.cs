using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Dos numeraciones serán iguales si no son nulas y son del mismo tipo.
    // Implementar una conversión explicita de Numeración a double. Esta 
    // devolverá el valor de la Numeración.

    public abstract class Numeracion
    {
        protected static string msgErorr = "Numero Invalido";
        protected string valor;

        public string Valor { get { return valor; } }
        public abstract double ValorNumerico
        {
            get;
        }

        public virtual Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                return new SistemaBinario(this.Valor);
            }
            return new SistemaDecimal(this.Valor);
        }

        protected Numeracion(string valor)
        {
            InicializaValor(valor);
        }
        private void InicializaValor(string valor)
        {
            if (double.TryParse(valor, out double resultado))
            {
                this.valor = $"{resultado}";
            }
            else
            {
                this.valor = $"double.NaN";
            }
        }

        protected virtual bool EsNumeracionValida(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return false;
            }
            return true;
        }


        public static explicit operator double(Numeracion numeracion)
        {
            return numeracion.ValorNumerico;
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            if (n1 is null || n2 is null)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }
    }
}

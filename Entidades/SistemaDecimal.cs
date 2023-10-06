using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {
        private Numeracion value;

        public SistemaDecimal(string valor) : base(valor)
        {

        }

        public override double ValorNumerico
        {
            get { return double.Parse(base.Valor); }
        }

        private bool EsSistemaDecimalValido(string valor)
        {
            if (double.TryParse(valor, out double valorParseado))
            {
                return true;
            }
            return false;
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor);
        }

        public override SistemaBinario CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                return DecimalABinario(base.Valor);
            }
            return this.Valor;
        }

        // Conversión implícita desde double a SistemaDecimal
        public static implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal($"{valor}");
        }

        // Conversión implícita desde string a SistemaDecimal
        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }

        private static SistemaBinario DecimalABinario(string valor)
        {
            string resultado = "";
            double valorParseado = double.Parse(valor);
            int valorParseadoRedondeado = (int)Math.Round(valorParseado);

            //De todas formas vuelvo a validar que sea >= 0 (Porque desconfio SIEMPRE de lo que llega por param)
            if (valorParseadoRedondeado >= 0)
            {
                while (valorParseadoRedondeado > 0)
                {
                    //Guardo en la variable string (AL PRINCIPIO) el ultimo valor.
                    resultado = valorParseadoRedondeado % 2 + resultado;
                    valorParseadoRedondeado = (int)valorParseadoRedondeado / 2;
                }
                return resultado;
            }
            else
            {
                return $"{double.NaN}";
            }
        }
    }
}

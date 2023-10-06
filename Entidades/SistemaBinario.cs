using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        public SistemaBinario(string valor) : base(valor)
        {

        }

        public override double ValorNumerico
        {
            get { return double.Parse(base.Valor); }
        }

        private SistemaDecimal BinarioADecimal()
        {
            return new SistemaDecimal(base.Valor);
        }

        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            if (sistema == ESistema.Decimal)
            {
                return new SistemaDecimal(this.Valor);
            }
            return new SistemaBinario(this.Valor);
        }

        protected override bool EsNumeracionValida(string valor)
        {
            return base.EsNumeracionValida(valor);
        }

        private static bool EsSistemaBinarioValido(string valor)
        {
            foreach (char numero in valor)
            {
                if (numero != '0' && numero != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public static implicit operator SistemaBinario(string valor)
        {
            if (!EsSistemaBinarioValido(valor))
            {
                return msgErorr;
            }

            return new SistemaBinario(valor);
        }

    }
}

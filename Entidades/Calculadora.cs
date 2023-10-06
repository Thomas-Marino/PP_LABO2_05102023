using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion resultado;
        private Numeracion segundoOperando;
        private ESistema sistema;


        public string NombreAlumno
        {
            get { return nombreAlumno; }
            set { nombreAlumno = value; }
        }
        public List<string> Operaciones
        {
            get { return operaciones; }
        }
        public Numeracion PrimerOperando
        {
            get
            {
                return primerOperando;
            }

            set
            {
                primerOperando = value;
            }

        }
        public Numeracion Resultado
        {
            get { return resultado; }
        }
        public Numeracion SegundoOperando
        {
            get
            {
                return segundoOperando;
            }

            set
            {
                segundoOperando = value;
            }

        }
        public ESistema Sistema
        {
            get
            {
                return sistema;
            }
            set
            {
                if (sistema == ESistema.Binario || sistema == ESistema.Decimal)
                {
                    sistema = value;
                }
            }
        }
        
        public void ActualizaHistorialDeOperaciones(char operador)
        {
            StringBuilder historial = new StringBuilder();
            historial.AppendLine($"Sistema: {this.Sistema}");
            historial.AppendLine($"Primer Operando: {this.primerOperando.Valor}");
            historial.AppendLine($"Segundo Operando: {this.segundoOperando.Valor}");
            historial.AppendLine($"Operador: {operador}");
            //this.operaciones.Add(historial.ToString());
        }

        public void EliminarHistorialDeOperaciones()
        {
            //this.operaciones.Clear();
        }

        public Calculadora(string nombreAlumno)
        {
            this.nombreAlumno = nombreAlumno;
        }

        public Calculadora()
        {
            this.operaciones = new List<string>();
            this.sistema = ESistema.Decimal;
        }

        public void Calcular(char operador)
        {
            double valor1 = double.Parse(primerOperando.Valor);
            double valor2 = double.Parse(segundoOperando.Valor);

            switch (operador)
            {
                case '-':
                    resultado = MapeaResultado(valor1 - valor2);
                    break;
                case '*':
                    resultado = MapeaResultado(valor1 * valor2);
                    break;
                case '/':
                    if (valor2 != 0)
                    {
                        resultado = MapeaResultado(valor1 / valor2);
                    }
                    else
                    {
                        resultado = MapeaResultado(double.NaN);
                    }
                    break;
                default:
                    resultado = MapeaResultado(valor1 + valor2);
                    break;
            }
        }
        private Numeracion MapeaResultado(double valor)
        {
            if (this.sistema == ESistema.Decimal)
            {
                return new SistemaDecimal($"{valor}");
            }
            return new SistemaBinario($"{valor}");
        }
    }
}

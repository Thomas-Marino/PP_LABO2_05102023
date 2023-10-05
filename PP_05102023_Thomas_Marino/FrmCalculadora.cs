using Entidades;
using System.Drawing.Text;
using System.Text;

namespace Windows_form
{
    public partial class FrmCalculadora : Form
    {
        public FrmCalculadora()
        {
            InitializeComponent();
            radioButton1.Select();
        }
        // ---------------- Botones Inferiores ----------------
        // ---------------- Botones de cierre.
        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cerrar el programa?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ---------------- Boton de limpiar.
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            // Reseteo y vuelvo a activar todo en el form.
            TxbOperando1.ResetText();
            TxbOperando2.ResetText();
            TxbResultado.ResetText();
            CbSeleccionOperador.ResetText();
            CbSeleccionOperador.Enabled = true;
            TxbOperando1.Enabled = true;
            TxbOperando2.Enabled = true;
            BtnOperar.Enabled = true;
        }
        // ---------------- Boton de operar.
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxbOperando1.Text))
            {
                TxbOperando1.Text = "0";
            }
            if (string.IsNullOrEmpty(TxbOperando2.Text))
            {
                TxbOperando2.Text = "0";
            }
            setResultado();
            CbSeleccionOperador.Enabled = false;
            TxbOperando1.Enabled = false;
            TxbOperando2.Enabled = false;
            BtnOperar.Enabled = false;
        }
        // ---------------- Radio Buttons ----------------.
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) // Si está checkeada la opción de pasar a decimal.
            {
                if (TxbResultado.Text != "") // Paso de binario a decimal si el usuario ya ingreso una operacion.
                {

                }
            }
            else
            {
                if (TxbResultado.Text != "") // Paso de decimal a binario si el usuario ya ingreso una operacion.
                {

                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Método encargado de inicializar el objeto resultado de tipo Numeracion y settear la operacion matematica entre el primer operando y el segundo operando dependiendo del operador seleccionado.
        /// </summary>

        // ---------------- Lógica ----------------
        private void setResultado()
        {
            LstBoxHistorial.Items.Add(4); // Añado al historial.
        }
        private void FrmCalculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
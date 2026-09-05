namespace GestionTiendaDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido/a " + txtNombre.Text +
                ". Forma de pago: " + cmbFormaPago.SelectedItem +
                ". Cliente frecuente: " + chkClienteFrecuente.Checked +
                ". Sexo: " + (rbMasculino.Checked ? "Masculino" : "Femenino"));
        }

    }
}

using Microsoft.Data.SqlClient;
using System.Data;

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
            if (!ValidarCampos())
            {
                return;
            }


            string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Cliente (Nombre, Telefono, FormaPago, ClienteFrecuente, Sexo) " +
                         "VALUES (@Nombre, @Telefono, @FormaPago, @ClienteFrecuente, @Sexo)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            comando.Parameters.AddWithValue("@FormaPago", cmbFormaPago.SelectedItem);
            comando.Parameters.AddWithValue("@ClienteFrecuente", chkClienteFrecuente.Checked);
            comando.Parameters.AddWithValue("@Sexo", rbMasculino.Checked ? "Masculino" : "Femenino");
            comando.ExecuteNonQuery();
            conexion.Close();


            MessageBox.Show("Bienvenido/a " + txtNombre.Text +
                ". Forma de pago: " + cmbFormaPago.SelectedItem +
                ". Cliente frecuente: " + chkClienteFrecuente.Checked +
                ". Sexo: " + (rbMasculino.Checked ? "Masculino" : "Femenino"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Cliente", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvClientes.DataSource = tabla;

            cmbFormaPago.Items.Add("Contado");
            cmbFormaPago.Items.Add("Crédito");
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Por favor completa todos los campos antes de continuar.");
                return false;
            }
            return true;
        }
    }
}

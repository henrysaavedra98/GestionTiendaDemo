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
        }
    }
}

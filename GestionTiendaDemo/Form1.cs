using Microsoft.Data.SqlClient;
using System.Data;

namespace GestionTiendaDemo
{
    public partial class Form1 : Form
    {
        // Campos
        private string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";
        
        // Constructor
        public Form1()
        {
            InitializeComponent();
        }

        // Arranque del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
            cmbFormaPago.Items.Add("Contado");
            cmbFormaPago.Items.Add("Crédito");
        }

        // Métodos de apoyo
        private void CargarClientes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Cliente", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvClientes.DataSource = tabla;


            txtNombreSeleccionado.DataBindings.Clear();
            txtNombreSeleccionado.DataBindings.Add("Text", tabla, "Nombre");
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

        // CRUD de Cliente (en orden: Crear, Leer, Actualizar, Eliminar)
        private void btRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

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
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "UPDATE Cliente SET Nombre = @Nombre, Telefono = @Telefono " +
                         "WHERE ClienteID = @ClienteID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            comando.Parameters.AddWithValue("@ClienteID", clienteId);
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarClientes();
            txtNombre.Clear();
            txtTelefono.Clear();
            MessageBox.Show("Cliente actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este cliente?", "Confirmar",
                MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "DELETE FROM Cliente WHERE ClienteID = @ClienteID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@ClienteID", clienteId);
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarClientes();
            txtNombre.Clear();
            txtTelefono.Clear();
            MessageBox.Show("Cliente eliminado correctamente.");
        }

        // Validación de entrada
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Funcionalidad de Venta
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Venta (ClienteID, ProductoID, Cantidad) " +
                         "VALUES (@ClienteID, @ProductoID, @Cantidad)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteId;
            comando.Parameters.Add("@ProductoID", SqlDbType.Int).Value = Convert.ToInt32(txtProductoID.Text);
            comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Convert.ToInt32(txtCantidad.Text);
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarClientes();
            txtNombre.Clear();
            txtTelefono.Clear();
            MessageBox.Show("Venta registrada correctamente.");
        }

        
        
        
    }
}

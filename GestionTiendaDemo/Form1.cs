using Microsoft.Data.SqlClient;
using System.Data;

namespace GestionTiendaDemo
{
    public partial class Form1 : Form
    {
        // Campos
        private string cadenaConexion = "Server=.\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";

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
            if (cmbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Elige la forma de pago.");
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

            // 1. Crear el objeto y llenarlo desde los controles
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Nombre = txtNombre.Text.Trim();
            nuevoCliente.Telefono = txtTelefono.Text.Trim();
            nuevoCliente.FormaPago = cmbFormaPago.Text;
            nuevoCliente.ClienteFrecuente = chkClienteFrecuente.Checked;
            nuevoCliente.Sexo = rbMasculino.Checked ? "Masculino" : "Femenino";

            // 2. INSERT con parámetros tipados, leyendo del objeto
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Cliente (Nombre, Telefono, FormaPago, ClienteFrecuente, Sexo) " +
                         "VALUES (@Nombre, @Telefono, @FormaPago, @ClienteFrecuente, @Sexo)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nuevoCliente.Nombre;
            comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = nuevoCliente.Telefono;
            comando.Parameters.Add("@FormaPago", SqlDbType.VarChar, 20).Value = nuevoCliente.FormaPago;
            comando.Parameters.Add("@ClienteFrecuente", SqlDbType.Bit).Value = nuevoCliente.ClienteFrecuente;
            comando.Parameters.Add("@Sexo", SqlDbType.VarChar, 10).Value = nuevoCliente.Sexo;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarClientes();

            // 3. Resultado con los métodos del objeto
            MessageBox.Show(nuevoCliente.Saludar() +
                "\nDescuento: " + nuevoCliente.CalcularDescuento() + "%");
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            cmbFormaPago.Text = dgvClientes.CurrentRow.Cells["FormaPago"].Value.ToString();
            chkClienteFrecuente.Checked = Convert.ToBoolean(dgvClientes.CurrentRow.Cells["ClienteFrecuente"].Value);

            string sexo = dgvClientes.CurrentRow.Cells["Sexo"].Value.ToString();
            rbMasculino.Checked = (sexo == "Masculino");
            rbFemenino.Checked = (sexo == "Femenino");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente de la lista.");
                return;
            }
            if (!ValidarCampos())
            {
                return;
            }

            Cliente cliente = new Cliente();
            cliente.ClienteID = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);
            cliente.Nombre = txtNombre.Text.Trim();
            cliente.Telefono = txtTelefono.Text.Trim();
            cliente.FormaPago = cmbFormaPago.Text;
            cliente.ClienteFrecuente = chkClienteFrecuente.Checked;
            cliente.Sexo = rbMasculino.Checked ? "Masculino" : "Femenino";

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "UPDATE Cliente SET Nombre = @Nombre, Telefono = @Telefono, " +
                         "FormaPago = @FormaPago, ClienteFrecuente = @ClienteFrecuente, " +
                         "Sexo = @Sexo WHERE ClienteID = @ClienteID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = cliente.Nombre;
            comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = cliente.Telefono;
            comando.Parameters.Add("@FormaPago", SqlDbType.VarChar, 20).Value = cliente.FormaPago;
            comando.Parameters.Add("@ClienteFrecuente", SqlDbType.Bit).Value = cliente.ClienteFrecuente;
            comando.Parameters.Add("@Sexo", SqlDbType.VarChar, 10).Value = cliente.Sexo;
            comando.Parameters.Add("@ClienteID", SqlDbType.Int).Value = cliente.ClienteID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarClientes();
            txtNombre.Clear();
            txtTelefono.Clear();
            MessageBox.Show("Cliente actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente de la lista.");
                return;
            }

            Cliente cliente = new Cliente();
            cliente.ClienteID = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteID"].Value);
            cliente.Nombre = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar a " + cliente.Nombre + "?", "Confirmar",
                MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                string sql = "DELETE FROM Cliente WHERE ClienteID = @ClienteID";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@ClienteID", SqlDbType.Int).Value = cliente.ClienteID;
                comando.ExecuteNonQuery();

                CargarClientes();
                txtNombre.Clear();
                txtTelefono.Clear();
                MessageBox.Show("Cliente eliminado correctamente.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar: el cliente tiene ventas registradas.");
            }
            finally
            {
                conexion.Close();
            }
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

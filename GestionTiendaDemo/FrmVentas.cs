using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionTiendaDemo
{
    public partial class FrmVentas : Form
    {
        private string cadenaConexion = "Server=.\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            CargarVentas();
        }
        private void CargarClientes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(
                "SELECT ClienteID, Nombre FROM Cliente", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            cmbCliente.DataSource = tabla;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteID";
        }

        private void CargarProductos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(
                "SELECT ProductoID, Nombre, Precio FROM Producto WHERE Disponible = 1", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            cmbProducto.DataSource = tabla;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ProductoID";
        }

        private void CargarVentas()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "SELECT v.VentaID, v.ClienteID, v.ProductoID, " +
                         "c.Nombre AS Cliente, p.Nombre AS Producto, v.Cantidad, " +
                         "p.Precio, v.Cantidad * p.Precio AS Total, v.FechaVenta " +
                         "FROM Venta v " +
                         "INNER JOIN Cliente c ON v.ClienteID = c.ClienteID " +
                         "INNER JOIN Producto p ON v.ProductoID = p.ProductoID " +
                         "ORDER BY v.VentaID DESC";
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvVentas.DataSource = tabla;
            dgvVentas.Columns["ClienteID"].Visible = false;
            dgvVentas.Columns["ProductoID"].Visible = false;
        }

        private decimal ObtenerPrecio()
        {
            if (cmbProducto.SelectedItem is DataRowView fila)
            {
                return Convert.ToDecimal(fila["Precio"]);
            }
            return 0;
        }

        private void ActualizarTotal()
        {
            Venta venta = new Venta();
            int.TryParse(txtCantidad.Text, out int cantidad);
            venta.Cantidad = cantidad;
            lblTotal.Text = "Total: C$ " + venta.CalcularTotal(ObtenerPrecio());
        }

        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un cliente.");
                return false;
            }
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un producto disponible.");
                return false;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Escribe una cantidad mayor que cero.");
                return false;
            }
            return true;
        }

        private Venta LeerVenta()
        {
            Venta venta = new Venta();
            venta.ClienteID = Convert.ToInt32(cmbCliente.SelectedValue);
            venta.ProductoID = Convert.ToInt32(cmbProducto.SelectedValue);
            venta.Cantidad = int.Parse(txtCantidad.Text);
            return venta;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) { return; }

            Venta venta = LeerVenta();

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Venta (ClienteID, ProductoID, Cantidad) " +
                         "VALUES (@ClienteID, @ProductoID, @Cantidad)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@ClienteID", SqlDbType.Int).Value = venta.ClienteID;
            comando.Parameters.Add("@ProductoID", SqlDbType.Int).Value = venta.ProductoID;
            comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = venta.Cantidad;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarVentas();
            MessageBox.Show("Venta registrada. Total: C$ " + venta.CalcularTotal(ObtenerPrecio()));
            txtCantidad.Clear();
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;

            cmbCliente.SelectedValue = Convert.ToInt32(dgvVentas.CurrentRow.Cells["ClienteID"].Value);
            cmbProducto.SelectedValue = Convert.ToInt32(dgvVentas.CurrentRow.Cells["ProductoID"].Value);
            txtCantidad.Text = dgvVentas.CurrentRow.Cells["Cantidad"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una venta de la lista.");
                return;
            }
            if (!ValidarCampos()) { return; }

            Venta venta = LeerVenta();
            venta.VentaID = Convert.ToInt32(dgvVentas.CurrentRow.Cells["VentaID"].Value);

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "UPDATE Venta SET ClienteID = @ClienteID, ProductoID = @ProductoID, " +
                         "Cantidad = @Cantidad WHERE VentaID = @VentaID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@ClienteID", SqlDbType.Int).Value = venta.ClienteID;
            comando.Parameters.Add("@ProductoID", SqlDbType.Int).Value = venta.ProductoID;
            comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = venta.Cantidad;
            comando.Parameters.Add("@VentaID", SqlDbType.Int).Value = venta.VentaID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarVentas();
            txtCantidad.Clear();
            MessageBox.Show("Venta actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una venta de la lista.");
                return;
            }

            Venta venta = new Venta();
            venta.VentaID = Convert.ToInt32(dgvVentas.CurrentRow.Cells["VentaID"].Value);

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar la venta " + venta.VentaID + "?", "Confirmar",
                MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "DELETE FROM Venta WHERE VentaID = @VentaID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@VentaID", SqlDbType.Int).Value = venta.VentaID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarVentas();
            txtCantidad.Clear();
            MessageBox.Show("Venta eliminada correctamente.");
        }
    }
}

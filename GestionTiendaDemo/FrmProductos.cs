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
    public partial class FrmProductos : Form
    {
        private string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProductos();
        }

        private void CargarCategorias()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(
                "SELECT CategoriaID, Nombre FROM Categoria", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            cmbCategoria.DataSource = tabla;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
        }

        private void CargarProductos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            string sql = "SELECT p.ProductoID, p.Nombre, p.Precio, p.Disponible, " +
                         "p.CategoriaID, c.Nombre AS Categoria, p.FechaRegistro " +
                         "FROM Producto p INNER JOIN Categoria c " +
                         "ON p.CategoriaID = c.CategoriaID";
            SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvProductos.DataSource = tabla;
            dgvProductos.Columns["ProductoID"].Visible = false;
            dgvProductos.Columns["CategoriaID"].Visible = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Escribe un precio válido mayor que cero.");
                return false;
            }
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una categoría.");
                return false;
            }
            return true;
        }

        private Producto LeerProducto()
        {
            Producto producto = new Producto();
            producto.Nombre = txtNombre.Text.Trim();
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Disponible = chkDisponible.Checked;
            producto.CategoriaID = Convert.ToInt32(cmbCategoria.SelectedValue);
            return producto;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            chkDisponible.Checked = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) { return; }

            Producto producto = LeerProducto();

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Producto (Nombre, Precio, Disponible, CategoriaID) " +
                         "VALUES (@Nombre, @Precio, @Disponible, @CategoriaID)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = producto.Nombre;
            SqlParameter pPrecio = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            pPrecio.Precision = 10;
            pPrecio.Scale = 2;
            pPrecio.Value = producto.Precio;
            comando.Parameters.Add("@Disponible", SqlDbType.Bit).Value = producto.Disponible;
            comando.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = producto.CategoriaID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarProductos();
            LimpiarCampos();
            MessageBox.Show("Producto registrado: " + producto.Descripcion());
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            chkDisponible.Checked = Convert.ToBoolean(dgvProductos.CurrentRow.Cells["Disponible"].Value);
            cmbCategoria.SelectedValue = Convert.ToInt32(dgvProductos.CurrentRow.Cells["CategoriaID"].Value);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto de la lista.");
                return;
            }
            if (!ValidarCampos()) { return; }

            Producto producto = LeerProducto();
            producto.ProductoID = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoID"].Value);

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "UPDATE Producto SET Nombre = @Nombre, Precio = @Precio, " +
                         "Disponible = @Disponible, CategoriaID = @CategoriaID " +
                         "WHERE ProductoID = @ProductoID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = producto.Nombre;
            SqlParameter pPrecio = comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            pPrecio.Precision = 10;
            pPrecio.Scale = 2;
            pPrecio.Value = producto.Precio;
            comando.Parameters.Add("@Disponible", SqlDbType.Bit).Value = producto.Disponible;
            comando.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = producto.CategoriaID;
            comando.Parameters.Add("@ProductoID", SqlDbType.Int).Value = producto.ProductoID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarProductos();
            LimpiarCampos();
            MessageBox.Show("Producto actualizado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto de la lista.");
                return;
            }

            Producto producto = new Producto();
            producto.ProductoID = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoID"].Value);
            producto.Nombre = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar " + producto.Nombre + "?", "Confirmar",
                MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                string sql = "DELETE FROM Producto WHERE ProductoID = @ProductoID";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@ProductoID", SqlDbType.Int).Value = producto.ProductoID;
                comando.ExecuteNonQuery();

                CargarProductos();
                LimpiarCampos();
                MessageBox.Show("Producto eliminado correctamente.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar: el producto tiene ventas registradas.");
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

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
    public partial class FrmCategorias : Form
    {
        private string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";

        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(
                "SELECT CategoriaID, Nombre, Descripcion FROM Categoria", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvCategorias.DataSource = tabla;
            dgvCategorias.Columns["CategoriaID"].Visible = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            return true;
        }

        private Categoria LeerCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = txtNombre.Text.Trim();
            categoria.Descripcion = txtDescripcion.Text.Trim();
            return categoria;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) { return; }

            Categoria categoria = LeerCategoria();

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "INSERT INTO Categoria (Nombre, Descripcion) " +
                         "VALUES (@Nombre, @Descripcion)";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = categoria.Nombre;
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = categoria.Descripcion;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarCategorias();
            LimpiarCampos();
            MessageBox.Show("Categoría registrada: " + categoria.Resumen());
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.CurrentRow == null) return;

            txtNombre.Text = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dgvCategorias.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una categoría de la lista.");
                return;
            }
            if (!ValidarCampos()) { return; }

            Categoria categoria = LeerCategoria();
            categoria.CategoriaID = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["CategoriaID"].Value);

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sql = "UPDATE Categoria SET Nombre = @Nombre, Descripcion = @Descripcion " +
                         "WHERE CategoriaID = @CategoriaID";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = categoria.Nombre;
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = categoria.Descripcion;
            comando.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = categoria.CategoriaID;
            comando.ExecuteNonQuery();

            conexion.Close();
            CargarCategorias();
            LimpiarCampos();
            MessageBox.Show("Categoría actualizada correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una categoría de la lista.");
                return;
            }

            Categoria categoria = new Categoria();
            categoria.CategoriaID = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["CategoriaID"].Value);
            categoria.Nombre = dgvCategorias.CurrentRow.Cells["Nombre"].Value.ToString();

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar la categoría " + categoria.Nombre + "?", "Confirmar",
                MessageBoxButtons.YesNo);
            if (confirmacion != DialogResult.Yes) return;

            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                string sql = "DELETE FROM Categoria WHERE CategoriaID = @CategoriaID";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add("@CategoriaID", SqlDbType.Int).Value = categoria.CategoriaID;
                comando.ExecuteNonQuery();

                CargarCategorias();
                LimpiarCampos();
                MessageBox.Show("Categoría eliminada correctamente.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar: la categoría tiene productos registrados.");
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionTiendaDemo
{
    public partial class FrmInforme : Form
    {
        private string cadenaConexion = "Server=WIN-5BE5AK9SIQ7\\SQLEXPRESS;Database=TiendaDemo;Trusted_Connection=True;TrustServerCertificate=True;";
        private ReportViewer visor = new ReportViewer();
        public FrmInforme()
        {
            InitializeComponent();
            visor.Dock = DockStyle.Fill;
            Controls.Add(visor);
        }

        private void FrmInforme_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(
                "SELECT * FROM vw_VentasPorCategoria", conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            string ruta = Path.Combine(Application.StartupPath, "InformeVentas.rdlc");
            using (FileStream archivo = new FileStream(ruta, FileMode.Open))
            {
                visor.LocalReport.LoadReportDefinition(archivo);
            }

            string nombreConjunto = visor.LocalReport.GetDataSourceNames()[0];
            visor.LocalReport.DataSources.Clear();
            visor.LocalReport.DataSources.Add(new ReportDataSource(nombreConjunto, tabla));
            visor.RefreshReport();
        }
    }
}

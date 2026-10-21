using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionTiendaDemo
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarHijos();
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            CerrarHijos();
            FrmProductos frm = new FrmProductos();
            frm.MdiParent = this;
            frm.Show();
        }


        private void mnuCategorias_Click(object sender, EventArgs e)
        {

            CerrarHijos();
            FrmCategorias frm = new FrmCategorias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuVentas_Click(object sender, EventArgs e)
        {
            CerrarHijos();
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuInformeVentas_Click(object sender, EventArgs e)
        {
            CerrarHijos();
            FrmInforme frm = new FrmInforme();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistema de Gestión de Tienda", "Acerca de");

        }


        private void CerrarHijos()
        {
            foreach (Form hijo in MdiChildren)
            {
                hijo.Close();
            }
        }
    }
}

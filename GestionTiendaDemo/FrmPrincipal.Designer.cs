namespace GestionTiendaDemo
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuSalir = new ToolStripMenuItem();
            mnuRegistros = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            mnuProductos = new ToolStripMenuItem();
            mnuCategorias = new ToolStripMenuItem();
            mnuVentas = new ToolStripMenuItem();
            mnuInformes = new ToolStripMenuItem();
            mnuInformeVentas = new ToolStripMenuItem();
            mnuAyuda = new ToolStripMenuItem();
            mnuAcercaDe = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuArchivo, mnuRegistros, mnuInformes, mnuAyuda });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(878, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, mnuSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Size = new Size(88, 29);
            mnuArchivo.Text = "&Archivo";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(209, 6);
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.ShortcutKeys = Keys.Control | Keys.Q;
            mnuSalir.Size = new Size(212, 34);
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // mnuRegistros
            // 
            mnuRegistros.DropDownItems.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, mnuProductos, mnuCategorias, mnuVentas });
            mnuRegistros.Name = "mnuRegistros";
            mnuRegistros.Size = new Size(101, 29);
            mnuRegistros.Text = "&Registros";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(270, 34);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // mnuProductos
            // 
            mnuProductos.Name = "mnuProductos";
            mnuProductos.Size = new Size(270, 34);
            mnuProductos.Text = "Productos";
            mnuProductos.Click += mnuProductos_Click;
            // 
            // mnuCategorias
            // 
            mnuCategorias.Name = "mnuCategorias";
            mnuCategorias.Size = new Size(270, 34);
            mnuCategorias.Text = "Categorías";
            mnuCategorias.Click += mnuCategorias_Click;
            // 
            // mnuVentas
            // 
            mnuVentas.Name = "mnuVentas";
            mnuVentas.Size = new Size(270, 34);
            mnuVentas.Text = "Ventas";
            mnuVentas.Click += mnuVentas_Click;
            // 
            // mnuInformes
            // 
            mnuInformes.DropDownItems.AddRange(new ToolStripItem[] { mnuInformeVentas });
            mnuInformes.Name = "mnuInformes";
            mnuInformes.Size = new Size(99, 29);
            mnuInformes.Text = "&Informes";
            // 
            // mnuInformeVentas
            // 
            mnuInformeVentas.Name = "mnuInformeVentas";
            mnuInformeVentas.Size = new Size(277, 34);
            mnuInformeVentas.Text = "Ventas por categoría";
            mnuInformeVentas.Click += mnuInformeVentas_Click;
            // 
            // mnuAyuda
            // 
            mnuAyuda.DropDownItems.AddRange(new ToolStripItem[] { mnuAcercaDe });
            mnuAyuda.Name = "mnuAyuda";
            mnuAyuda.Size = new Size(79, 29);
            mnuAyuda.Text = "A&yuda";
            // 
            // mnuAcercaDe
            // 
            mnuAcercaDe.Name = "mnuAcercaDe";
            mnuAcercaDe.Size = new Size(191, 34);
            mnuAcercaDe.Text = "Acerca de";
            mnuAcercaDe.Click += mnuAcercaDe_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 658);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem mnuRegistros;
        private ToolStripMenuItem mnuProductos;
        private ToolStripMenuItem mnuCategorias;
        private ToolStripMenuItem mnuVentas;
        private ToolStripMenuItem mnuInformes;
        private ToolStripMenuItem mnuInformeVentas;
        private ToolStripMenuItem mnuAyuda;
        private ToolStripMenuItem mnuAcercaDe;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem clientesToolStripMenuItem;
    }
}
namespace GestionTiendaDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            btRegistrar = new Button();
            cmbFormaPago = new ComboBox();
            chkClienteFrecuente = new CheckBox();
            rbMasculino = new RadioButton();
            rbFemenino = new RadioButton();
            dgvClientes = new DataGridView();
            txtNombreSeleccionado = new TextBox();
            txtProductoID = new TextBox();
            txtCantidad = new TextBox();
            btnRegistrarVenta = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnActualizar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(118, 35);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(118, 94);
            label2.Name = "label2";
            label2.Size = new Size(112, 32);
            label2.TabIndex = 1;
            label2.Text = "Telefono:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(258, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(307, 39);
            txtNombre.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(258, 91);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(307, 39);
            txtTelefono.TabIndex = 3;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // btRegistrar
            // 
            btRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRegistrar.Location = new Point(80, 209);
            btRegistrar.Name = "btRegistrar";
            btRegistrar.Size = new Size(228, 77);
            btRegistrar.TabIndex = 4;
            btRegistrar.Text = "Registrar";
            btRegistrar.UseVisualStyleBackColor = true;
            btRegistrar.Click += btRegistrar_Click;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(630, 27);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(182, 40);
            cmbFormaPago.TabIndex = 5;
            // 
            // chkClienteFrecuente
            // 
            chkClienteFrecuente.AutoSize = true;
            chkClienteFrecuente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkClienteFrecuente.Location = new Point(611, 94);
            chkClienteFrecuente.Name = "chkClienteFrecuente";
            chkClienteFrecuente.Size = new Size(224, 36);
            chkClienteFrecuente.TabIndex = 6;
            chkClienteFrecuente.Text = "Cliente frecuente";
            chkClienteFrecuente.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            rbMasculino.AutoSize = true;
            rbMasculino.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbMasculino.Location = new Point(153, 151);
            rbMasculino.Name = "rbMasculino";
            rbMasculino.Size = new Size(148, 36);
            rbMasculino.TabIndex = 7;
            rbMasculino.TabStop = true;
            rbMasculino.Text = "Masculino";
            rbMasculino.UseVisualStyleBackColor = true;
            // 
            // rbFemenino
            // 
            rbFemenino.AutoSize = true;
            rbFemenino.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbFemenino.Location = new Point(373, 151);
            rbFemenino.Name = "rbFemenino";
            rbFemenino.Size = new Size(146, 36);
            rbFemenino.TabIndex = 8;
            rbFemenino.TabStop = true;
            rbFemenino.Text = "Femenino";
            rbFemenino.UseVisualStyleBackColor = true;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(80, 307);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 62;
            dgvClientes.Size = new Size(768, 225);
            dgvClientes.TabIndex = 9;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // txtNombreSeleccionado
            // 
            txtNombreSeleccionado.Location = new Point(291, 618);
            txtNombreSeleccionado.Name = "txtNombreSeleccionado";
            txtNombreSeleccionado.Size = new Size(150, 31);
            txtNombreSeleccionado.TabIndex = 10;
            // 
            // txtProductoID
            // 
            txtProductoID.Location = new Point(291, 569);
            txtProductoID.Name = "txtProductoID";
            txtProductoID.Size = new Size(150, 31);
            txtProductoID.TabIndex = 11;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(634, 569);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(150, 31);
            txtCantidad.TabIndex = 12;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(491, 616);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(186, 34);
            btnRegistrarVenta.TabIndex = 13;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 621);
            label3.Name = "label3";
            label3.Size = new Size(176, 25);
            label3.TabIndex = 14;
            label3.Text = "Cliente seleccionado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 572);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 15;
            label4.Text = "Producto ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(516, 572);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(516, 569);
            label6.Name = "label6";
            label6.Size = new Size(92, 25);
            label6.TabIndex = 17;
            label6.Text = "Cantidad: ";
            // 
            // btnActualizar
            // 
            btnActualizar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(352, 209);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(226, 77);
            btnActualizar.TabIndex = 18;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(611, 209);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(201, 77);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(878, 658);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(txtCantidad);
            Controls.Add(txtProductoID);
            Controls.Add(txtNombreSeleccionado);
            Controls.Add(dgvClientes);
            Controls.Add(rbFemenino);
            Controls.Add(rbMasculino);
            Controls.Add(chkClienteFrecuente);
            Controls.Add(cmbFormaPago);
            Controls.Add(btRegistrar);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Cliente";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private Button btRegistrar;
        private ComboBox cmbFormaPago;
        private CheckBox chkClienteFrecuente;
        private RadioButton rbMasculino;
        private RadioButton rbFemenino;
        private DataGridView dgvClientes;
        private TextBox txtNombreSeleccionado;
        private TextBox txtProductoID;
        private TextBox txtCantidad;
        private Button btnRegistrarVenta;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnActualizar;
        private Button btnEliminar;
    }
}

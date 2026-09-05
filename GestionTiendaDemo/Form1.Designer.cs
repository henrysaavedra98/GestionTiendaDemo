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
            // 
            // btRegistrar
            // 
            btRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRegistrar.Location = new Point(187, 355);
            btRegistrar.Name = "btRegistrar";
            btRegistrar.Size = new Size(290, 77);
            btRegistrar.TabIndex = 4;
            btRegistrar.Text = "Registrar";
            btRegistrar.UseVisualStyleBackColor = true;
            btRegistrar.Click += btRegistrar_Click;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Items.AddRange(new object[] { "Contado", "Credito" });
            cmbFormaPago.Location = new Point(118, 164);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(182, 40);
            cmbFormaPago.TabIndex = 5;
            // 
            // chkClienteFrecuente
            // 
            chkClienteFrecuente.AutoSize = true;
            chkClienteFrecuente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkClienteFrecuente.Location = new Point(356, 165);
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
            rbMasculino.Location = new Point(145, 244);
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
            rbFemenino.Location = new Point(365, 244);
            rbFemenino.Name = "rbFemenino";
            rbFemenino.Size = new Size(146, 36);
            rbFemenino.TabIndex = 8;
            rbFemenino.TabStop = true;
            rbFemenino.Text = "Femenino";
            rbFemenino.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(878, 444);
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
    }
}

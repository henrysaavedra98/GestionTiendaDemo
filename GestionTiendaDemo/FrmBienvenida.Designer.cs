namespace GestionTiendaDemo
{
    partial class FrmBienvenida
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
            label1 = new Label();
            label2 = new Label();
            btEntrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 86);
            label1.Name = "label1";
            label1.Size = new Size(579, 54);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Gestión de Tienda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 178);
            label2.Name = "label2";
            label2.Size = new Size(259, 25);
            label2.TabIndex = 1;
            label2.Text = "Elaborado por: Henry Saavedra";
            // 
            // btEntrar
            // 
            btEntrar.Location = new Point(336, 260);
            btEntrar.Name = "btEntrar";
            btEntrar.Size = new Size(112, 34);
            btEntrar.TabIndex = 2;
            btEntrar.Text = "Entrar";
            btEntrar.UseVisualStyleBackColor = true;
            btEntrar.Click += btEntrar_Click;
            // 
            // FrmBienvenida
            // 
            AcceptButton = btEntrar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btEntrar);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmBienvenida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bienvenido";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btEntrar;
    }
}
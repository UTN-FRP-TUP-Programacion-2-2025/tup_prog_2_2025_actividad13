namespace Ejercicio4_ClientApiWebApp
{
    partial class FormPrincipal
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
            groupBox2 = new GroupBox();
            cBoxCamiones = new ComboBox();
            tBkg = new TextBox();
            btnEnviar = new Button();
            btnIniciar = new Button();
            btnRetirar = new Button();
            btnAgregar = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            listBcarga = new ListBox();
            groupBox1 = new GroupBox();
            btnImportarPaquetes = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cBoxCamiones);
            groupBox2.Controls.Add(tBkg);
            groupBox2.Controls.Add(btnEnviar);
            groupBox2.Controls.Add(btnIniciar);
            groupBox2.Controls.Add(btnRetirar);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(listBcarga);
            groupBox2.Location = new Point(4, 226);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(624, 193);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preparar reparto:";
            // 
            // cBoxCamiones
            // 
            cBoxCamiones.FormattingEnabled = true;
            cBoxCamiones.Location = new Point(28, 52);
            cBoxCamiones.Margin = new Padding(4);
            cBoxCamiones.Name = "cBoxCamiones";
            cBoxCamiones.Size = new Size(205, 29);
            cBoxCamiones.TabIndex = 9;
            // 
            // tBkg
            // 
            tBkg.Location = new Point(146, 151);
            tBkg.Margin = new Padding(4);
            tBkg.Name = "tBkg";
            tBkg.Size = new Size(95, 29);
            tBkg.TabIndex = 8;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(137, 94);
            btnEnviar.Margin = new Padding(4);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(96, 32);
            btnEnviar.TabIndex = 7;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(28, 94);
            btnIniciar.Margin = new Padding(4);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(91, 32);
            btnIniciar.TabIndex = 6;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            // 
            // btnRetirar
            // 
            btnRetirar.Location = new Point(517, 116);
            btnRetirar.Margin = new Padding(4);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(96, 32);
            btnRetirar.TabIndex = 5;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(517, 76);
            btnAgregar.Margin = new Padding(4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(96, 32);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 155);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(126, 21);
            label6.TabIndex = 3;
            label6.Text = "Peso acumulado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 28);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 2;
            label5.Text = "Lista de Camiones";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(266, 28);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 1;
            label4.Text = "label4";
            // 
            // listBcarga
            // 
            listBcarga.FormattingEnabled = true;
            listBcarga.ItemHeight = 21;
            listBcarga.Location = new Point(265, 52);
            listBcarga.Margin = new Padding(4);
            listBcarga.Name = "listBcarga";
            listBcarga.Size = new Size(243, 130);
            listBcarga.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnImportarPaquetes);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(listBox3);
            groupBox1.Controls.Add(listBox2);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Location = new Point(4, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(624, 204);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Depósito";
            // 
            // btnImportarPaquetes
            // 
            btnImportarPaquetes.Location = new Point(495, 62);
            btnImportarPaquetes.Margin = new Padding(4);
            btnImportarPaquetes.Name = "btnImportarPaquetes";
            btnImportarPaquetes.Size = new Size(118, 132);
            btnImportarPaquetes.TabIndex = 6;
            btnImportarPaquetes.Text = "Importar Paquetes Pedidos";
            btnImportarPaquetes.UseVisualStyleBackColor = true;
            btnImportarPaquetes.Click += btnImportarPaquetes_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 37);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 21);
            label3.TabIndex = 5;
            label3.Text = "Zona 3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 37);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 21);
            label2.TabIndex = 4;
            label2.Text = "Zonal 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 21);
            label1.TabIndex = 3;
            label1.Text = "Zonal 1";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 21;
            listBox3.Location = new Point(333, 62);
            listBox3.Margin = new Padding(4);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(153, 130);
            listBox3.TabIndex = 2;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 21;
            listBox2.Location = new Point(171, 62);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(153, 130);
            listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(8, 62);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(153, 130);
            listBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 421);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormPrincipal";
            Text = "Form1";
            Load += FormPrincipal_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnMostrarCamiones;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private ComboBox cBoxCamiones;
        private TextBox tBkg;
        private Button btnEnviar;
        private Button btnIniciar;
        private Button btnRetirar;
        private Button btnAgregar;
        private Label label6;
        private Label label5;
        private Label label4;
        private ListBox listBcarga;
        private GroupBox groupBox1;
        private Button btnImportarPaquetes;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListBox listBox3;
        private ListBox listBox2;
        private OpenFileDialog openFileDialog1;
    }
}

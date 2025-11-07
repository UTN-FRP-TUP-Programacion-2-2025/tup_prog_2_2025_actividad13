namespace Ejercicio2_DesktopApp
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
            groupBox1 = new GroupBox();
            btnImportarPaquetes = new Button();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            tBkg = new TextBox();
            btnRetirar = new Button();
            listBcarga = new ListBox();
            btnAgregar = new Button();
            btnEnviar = new Button();
            btnIniciar = new Button();
            cBoxCamiones = new ComboBox();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnImportarPaquetes);
            groupBox1.Controls.Add(listBox3);
            groupBox1.Controls.Add(listBox2);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(620, 170);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Depósito";
            // 
            // btnImportarPaquetes
            // 
            btnImportarPaquetes.Location = new Point(503, 32);
            btnImportarPaquetes.Margin = new Padding(4);
            btnImportarPaquetes.Name = "btnImportarPaquetes";
            btnImportarPaquetes.Size = new Size(107, 79);
            btnImportarPaquetes.TabIndex = 3;
            btnImportarPaquetes.Text = "Importar paquetes pedidos";
            btnImportarPaquetes.UseVisualStyleBackColor = true;
            btnImportarPaquetes.Click += btnImportarPaquetes_Click;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 21;
            listBox3.Location = new Point(342, 30);
            listBox3.Margin = new Padding(4);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(153, 130);
            listBox3.TabIndex = 2;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 21;
            listBox2.Location = new Point(181, 30);
            listBox2.Margin = new Padding(4);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(153, 130);
            listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(20, 32);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(153, 130);
            listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tBkg);
            groupBox2.Controls.Add(btnRetirar);
            groupBox2.Controls.Add(listBcarga);
            groupBox2.Controls.Add(btnAgregar);
            groupBox2.Controls.Add(btnEnviar);
            groupBox2.Controls.Add(btnIniciar);
            groupBox2.Controls.Add(cBoxCamiones);
            groupBox2.Location = new Point(13, 191);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(620, 175);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preparar reparto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 132);
            label1.Name = "label1";
            label1.Size = new Size(126, 21);
            label1.TabIndex = 7;
            label1.Text = "Peso acumulado:";
            // 
            // tBkg
            // 
            tBkg.Location = new Point(157, 129);
            tBkg.Name = "tBkg";
            tBkg.Size = new Size(71, 29);
            tBkg.TabIndex = 6;
            // 
            // btnRetirar
            // 
            btnRetirar.Location = new Point(503, 87);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(107, 32);
            btnRetirar.TabIndex = 5;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += btnRetirar_Click;
            // 
            // listBcarga
            // 
            listBcarga.FormattingEnabled = true;
            listBcarga.ItemHeight = 21;
            listBcarga.Location = new Point(251, 30);
            listBcarga.Margin = new Padding(4);
            listBcarga.Name = "listBcarga";
            listBcarga.Size = new Size(244, 130);
            listBcarga.TabIndex = 4;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(502, 49);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(108, 32);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(128, 87);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(97, 32);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(20, 87);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(102, 32);
            btnIniciar.TabIndex = 1;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // cBoxCamiones
            // 
            cBoxCamiones.FormattingEnabled = true;
            cBoxCamiones.Location = new Point(20, 49);
            cBoxCamiones.Name = "cBoxCamiones";
            cBoxCamiones.Size = new Size(205, 29);
            cBoxCamiones.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 378);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FormPrincipal_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnImportarPaquetes;
        private ListBox listBox3;
        private ListBox listBox2;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private OpenFileDialog openFileDialog1;
        private Button btnRetirar;
        private ListBox listBcarga;
        private Button btnAgregar;
        private Button btnEnviar;
        private Button btnIniciar;
        private ComboBox cBoxCamiones;
        private TextBox tBkg;
        private Label label1;
    }
}

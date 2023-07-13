namespace ConvertidoresFormato
{
    partial class FormatSwitcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatSwitcher));
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            txtNombreArchivo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            txtForzarSeparadorSalida = new TextBox();
            label8 = new Label();
            txtRutaDestino = new TextBox();
            cmbSelecconArchivo = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            groupBox2 = new GroupBox();
            txtForzarSeparadorEntrada = new TextBox();
            label7 = new Label();
            txtArchivoSeleccionado = new TextBox();
            button4 = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            groupBox3 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(27, 43);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(192, 39);
            button1.TabIndex = 0;
            button1.Text = "Seleccionar archivo";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // txtNombreArchivo
            // 
            txtNombreArchivo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombreArchivo.BackColor = SystemColors.HighlightText;
            txtNombreArchivo.ForeColor = Color.Black;
            txtNombreArchivo.Location = new Point(226, 41);
            txtNombreArchivo.Margin = new Padding(3, 4, 3, 4);
            txtNombreArchivo.Name = "txtNombreArchivo";
            txtNombreArchivo.Size = new Size(684, 27);
            txtNombreArchivo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 44);
            label1.Name = "label1";
            label1.Size = new Size(181, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre de archivo nuevo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 114);
            label2.Name = "label2";
            label2.Size = new Size(195, 20);
            label2.TabIndex = 3;
            label2.Text = "Seleccion de formato nuevo";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtForzarSeparadorSalida);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtRutaDestino);
            groupBox1.Controls.Add(cmbSelecconArchivo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombreArchivo);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(22, 363);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(929, 309);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Archivo nuevo";
            // 
            // txtForzarSeparadorSalida
            // 
            txtForzarSeparadorSalida.Location = new Point(288, 179);
            txtForzarSeparadorSalida.Name = "txtForzarSeparadorSalida";
            txtForzarSeparadorSalida.Size = new Size(159, 27);
            txtForzarSeparadorSalida.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 181);
            label8.Name = "label8";
            label8.Size = new Size(259, 20);
            label8.TabIndex = 10;
            label8.Text = "Forzar caracter separador (Opcional): ";
            // 
            // txtRutaDestino
            // 
            txtRutaDestino.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRutaDestino.BackColor = SystemColors.ControlLightLight;
            txtRutaDestino.ForeColor = Color.Black;
            txtRutaDestino.Location = new Point(221, 248);
            txtRutaDestino.Margin = new Padding(3, 4, 3, 4);
            txtRutaDestino.Name = "txtRutaDestino";
            txtRutaDestino.ReadOnly = true;
            txtRutaDestino.Size = new Size(683, 27);
            txtRutaDestino.TabIndex = 7;
            // 
            // cmbSelecconArchivo
            // 
            cmbSelecconArchivo.BackColor = SystemColors.HighlightText;
            cmbSelecconArchivo.ForeColor = Color.Black;
            cmbSelecconArchivo.FormattingEnabled = true;
            cmbSelecconArchivo.Items.AddRange(new object[] { "JSON", "CSV", "EXCEL (XLSX)", "TSV", "JSON OPTIMIZADO " });
            cmbSelecconArchivo.Location = new Point(226, 108);
            cmbSelecconArchivo.Margin = new Padding(3, 4, 3, 4);
            cmbSelecconArchivo.Name = "cmbSelecconArchivo";
            cmbSelecconArchivo.Size = new Size(258, 28);
            cmbSelecconArchivo.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(23, 240);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(182, 41);
            button2.TabIndex = 6;
            button2.Text = "Carpeta destino";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.LimeGreen;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(772, 712);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(169, 49);
            button3.TabIndex = 8;
            button3.Text = "Convertir";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtForzarSeparadorEntrada);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(txtArchivoSeleccionado);
            groupBox2.ForeColor = SystemColors.MenuText;
            groupBox2.Location = new Point(23, 180);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(929, 161);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Archivo a convertir";
            // 
            // txtForzarSeparadorEntrada
            // 
            txtForzarSeparadorEntrada.Location = new Point(288, 110);
            txtForzarSeparadorEntrada.Name = "txtForzarSeparadorEntrada";
            txtForzarSeparadorEntrada.Size = new Size(159, 27);
            txtForzarSeparadorEntrada.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 112);
            label7.Name = "label7";
            label7.Size = new Size(259, 20);
            label7.TabIndex = 8;
            label7.Text = "Forzar caracter separador (Opcional): ";
            // 
            // txtArchivoSeleccionado
            // 
            txtArchivoSeleccionado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtArchivoSeleccionado.BackColor = SystemColors.ButtonHighlight;
            txtArchivoSeleccionado.ForeColor = Color.Black;
            txtArchivoSeleccionado.Location = new Point(237, 50);
            txtArchivoSeleccionado.Margin = new Padding(3, 4, 3, 4);
            txtArchivoSeleccionado.Name = "txtArchivoSeleccionado";
            txtArchivoSeleccionado.ReadOnly = true;
            txtArchivoSeleccionado.Size = new Size(666, 27);
            txtArchivoSeleccionado.TabIndex = 1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.BackColor = Color.Crimson;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(598, 712);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(142, 49);
            button4.TabIndex = 9;
            button4.Text = "Salir";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkVisited = true;
            linkLabel1.Location = new Point(23, 703);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(247, 20);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Desarrollado por Nahuel Maquieyra";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel3.AutoSize = true;
            linkLabel3.LinkVisited = true;
            linkLabel3.Location = new Point(23, 746);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(413, 20);
            linkLabel3.TabIndex = 11;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Eres desarrollador y quieres colaborar? Accede al repositorio";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(23, 21);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(928, 139);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Consejos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 102);
            label6.Name = "label6";
            label6.Size = new Size(413, 20);
            label6.TabIndex = 3;
            label6.Text = "3- Los formatos admitidos son:  JSON, CSV, TSV, XLSX (Excel).";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 65);
            label5.Name = "label5";
            label5.Size = new Size(836, 20);
            label5.TabIndex = 2;
            label5.Text = "2- Si vas a transformar un excel asegurate de que solo contenga una tabla con los datos. Quita toda la informacion adicional.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 65);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 29);
            label3.Name = "label3";
            label3.Size = new Size(868, 20);
            label3.TabIndex = 0;
            label3.Text = "1- Si vas a transformar un archivo csv o excel asegurate de que la primer fila (nombre de las columnas) no tenga espacios o tildes.";
            // 
            // FormatSwitcher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(970, 795);
            Controls.Add(groupBox3);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormatSwitcher";
            Text = "Format Switcher ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button button1;
        private TextBox txtNombreArchivo;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox cmbSelecconArchivo;
        private GroupBox groupBox2;
        private TextBox txtArchivoSeleccionado;
        private TextBox txtRutaDestino;
        private Button button2;
        private Button button3;
        private Button button4;
        private LinkLabel linkLabel1;
        private System.CodeDom.CodeTypeReference linkLabel2;
        private LinkLabel linkLabel3;
        private GroupBox groupBox3;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label7;
        private TextBox txtForzarSeparadorEntrada;
        private TextBox txtForzarSeparadorSalida;
        private Label label8;
    }
}
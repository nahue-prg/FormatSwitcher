namespace ConvertidoresFormato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openFileDialog1=new OpenFileDialog();
            button1=new Button();
            txtNombreArchivo=new TextBox();
            label1=new Label();
            label2=new Label();
            groupBox1=new GroupBox();
            cmbSelecconArchivo=new ComboBox();
            button3=new Button();
            groupBox2=new GroupBox();
            textBox2=new TextBox();
            button2=new Button();
            textBox1=new TextBox();
            button4=new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName="openFileDialog1";
            // 
            // button1
            // 
            button1.BackColor=Color.ForestGreen;
            button1.FlatStyle=FlatStyle.Popup;
            button1.Font=new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor=SystemColors.ButtonHighlight;
            button1.Location=new Point(24, 32);
            button1.Name="button1";
            button1.Size=new Size(159, 41);
            button1.TabIndex=0;
            button1.Text="Seleccionar archivo";
            button1.UseVisualStyleBackColor=false;
            button1.Click+=button1_Click_1;
            // 
            // txtNombreArchivo
            // 
            txtNombreArchivo.BackColor=SystemColors.Control;
            txtNombreArchivo.ForeColor=Color.DimGray;
            txtNombreArchivo.Location=new Point(186, 30);
            txtNombreArchivo.Name="txtNombreArchivo";
            txtNombreArchivo.Size=new Size(556, 23);
            txtNombreArchivo.TabIndex=1;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(20, 33);
            label1.Name="label1";
            label1.Size=new Size(145, 15);
            label1.TabIndex=2;
            label1.Text="Nombre de archivo nuevo";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(22, 87);
            label2.Name="label2";
            label2.Size=new Size(155, 15);
            label2.TabIndex=3;
            label2.Text="Seleccion de formato nuevo";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbSelecconArchivo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombreArchivo);
            groupBox1.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor=SystemColors.ButtonFace;
            groupBox1.Location=new Point(19, 190);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(764, 129);
            groupBox1.TabIndex=5;
            groupBox1.TabStop=false;
            groupBox1.Text="Archivo nuevo";
            // 
            // cmbSelecconArchivo
            // 
            cmbSelecconArchivo.BackColor=SystemColors.Control;
            cmbSelecconArchivo.ForeColor=Color.DimGray;
            cmbSelecconArchivo.FormattingEnabled=true;
            cmbSelecconArchivo.Items.AddRange(new object[] { "JSON", "CSV", "EXCEL(XLS)" });
            cmbSelecconArchivo.Location=new Point(187, 82);
            cmbSelecconArchivo.Name="cmbSelecconArchivo";
            cmbSelecconArchivo.Size=new Size(226, 23);
            cmbSelecconArchivo.TabIndex=5;
            // 
            // button3
            // 
            button3.BackColor=Color.ForestGreen;
            button3.FlatStyle=FlatStyle.Popup;
            button3.Font=new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor=SystemColors.ButtonHighlight;
            button3.Location=new Point(591, 351);
            button3.Name="button3";
            button3.Size=new Size(192, 47);
            button3.TabIndex=8;
            button3.Text="Convertir!";
            button3.UseVisualStyleBackColor=false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.ForeColor=SystemColors.Window;
            groupBox2.Location=new Point(19, 21);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new Size(764, 157);
            groupBox2.TabIndex=6;
            groupBox2.TabStop=false;
            groupBox2.Text="Archivo a transformar";
            // 
            // textBox2
            // 
            textBox2.BackColor=SystemColors.ControlLightLight;
            textBox2.ForeColor=Color.DimGray;
            textBox2.Location=new Point(207, 107);
            textBox2.Name="textBox2";
            textBox2.ReadOnly=true;
            textBox2.Size=new Size(534, 23);
            textBox2.TabIndex=7;
            // 
            // button2
            // 
            button2.BackColor=Color.ForestGreen;
            button2.FlatStyle=FlatStyle.Popup;
            button2.Font=new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor=SystemColors.ButtonHighlight;
            button2.Location=new Point(24, 96);
            button2.Name="button2";
            button2.Size=new Size(159, 41);
            button2.TabIndex=6;
            button2.Text="Ruta destino";
            button2.UseVisualStyleBackColor=false;
            // 
            // textBox1
            // 
            textBox1.BackColor=SystemColors.ButtonHighlight;
            textBox1.ForeColor=Color.DimGray;
            textBox1.Location=new Point(207, 42);
            textBox1.Name="textBox1";
            textBox1.ReadOnly=true;
            textBox1.Size=new Size(534, 23);
            textBox1.TabIndex=1;
            // 
            // button4
            // 
            button4.BackColor=Color.Crimson;
            button4.FlatStyle=FlatStyle.Popup;
            button4.Font=new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor=SystemColors.ButtonHighlight;
            button4.Location=new Point(449, 351);
            button4.Name="button4";
            button4.Size=new Size(124, 48);
            button4.TabIndex=9;
            button4.Text="Salir";
            button4.UseVisualStyleBackColor=false;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.DimGray;
            ClientSize=new Size(800, 428);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor=SystemColors.ControlLightLight;
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="Form1";
            Text="Conversor de archivos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
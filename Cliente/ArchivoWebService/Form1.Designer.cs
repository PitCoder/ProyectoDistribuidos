namespace ArchivoWebService
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnCifrar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnDescifrar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtNombreArchivo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// btnCifrar
			// 
			this.btnCifrar.BackColor = System.Drawing.Color.Khaki;
			this.btnCifrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCifrar.Location = new System.Drawing.Point(180, 105);
			this.btnCifrar.Name = "btnCifrar";
			this.btnCifrar.Size = new System.Drawing.Size(67, 46);
			this.btnCifrar.TabIndex = 0;
			this.btnCifrar.Text = "Cifrar (subir)";
			this.btnCifrar.UseVisualStyleBackColor = false;
			this.btnCifrar.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(177, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Contraseña:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.BackColor = System.Drawing.Color.DarkOrchid;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.ForeColor = System.Drawing.SystemColors.Info;
			this.txtPassword.Location = new System.Drawing.Point(247, 17);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(181, 26);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(445, 20);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Generar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(237, 206);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(201, 23);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 4;
			// 
			// btnDescifrar
			// 
			this.btnDescifrar.BackColor = System.Drawing.Color.LightGreen;
			this.btnDescifrar.Location = new System.Drawing.Point(445, 105);
			this.btnDescifrar.Name = "btnDescifrar";
			this.btnDescifrar.Size = new System.Drawing.Size(67, 46);
			this.btnDescifrar.TabIndex = 5;
			this.btnDescifrar.Text = "Descifrar (bajar)";
			this.btnDescifrar.UseVisualStyleBackColor = false;
			this.btnDescifrar.Click += new System.EventHandler(this.Button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(309, 117);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// txtNombreArchivo
			// 
			this.txtNombreArchivo.Location = new System.Drawing.Point(247, 56);
			this.txtNombreArchivo.Name = "txtNombreArchivo";
			this.txtNombreArchivo.Size = new System.Drawing.Size(181, 20);
			this.txtNombreArchivo.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(91, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Nombre del archivo a guardar:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(526, 26);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(60, 17);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Ocultar";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lavender;
			this.ClientSize = new System.Drawing.Size(709, 260);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNombreArchivo);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnDescifrar);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCifrar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Archivos";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnCifrar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnDescifrar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtNombreArchivo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}


using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace ArchivoWebService
{
	public partial class Form1 : Form
	{
		Aes cipher_aes = Aes.Create();
		
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Console.WriteLine("22");
			DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

			/*if (txtNombreArchivo.Text==null || txtNombreArchivo.Equals(""))
			{
				MessageBox.Show("Falta el nombre del archivo a guardar.");
			}
			else
			{
				return;
			}

			if (txtPassword.Text == null || txtPassword.Equals(""))
			{
				MessageBox.Show("¡Falta la contraseña!");
			}
			else
			{
				return;
			}*/


			String archivo_a_guardar=txtNombreArchivo.Text;
			String archivo_a_cifrar=openFileDialog1.FileName;
			String password = txtPassword.Text;

			String url_archivo_guardar = Path.GetDirectoryName(openFileDialog1.FileName); //se obtiene el path dponde se guardará el archivo

		    url_archivo_guardar+= "\\"+archivo_a_guardar;
			Console.WriteLine(url_archivo_guardar);

			if (result == DialogResult.OK) // Test result.
			{
				//string file = openFileDialog1.FileName;
				Console.WriteLine("33");
				try
				{

					ServerUtils.CifraConWS(url_archivo_guardar, archivo_a_cifrar, password);
					
					//ServerUtils.recibeArchivoSeguro2("salida.mp4", "C:\\Users\\jonat\\OneDrive\\Escritorio\\mio.mp4", "iso.txt");
					//CryptoUtils.Decrypt("C:\\Users\\jonat\\OneDrive\\Escritorio\\iso2.txt", "C:\\Users\\jonat\\OneDrive\\Escritorio\\iso24.txt", "iso.txt");
					
					MessageBox.Show("Se cifró y recibió el archivo en: "+url_archivo_guardar);
				}
				catch (IOException)
				{
					Console.WriteLine("pasó un error");
				}
				progressBar1.Value = 100;

			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			string randomPass = System.Web.Security.Membership.GeneratePassword(10, 2);
			txtPassword.Text = randomPass;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			Console.WriteLine("22");
			DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

			/*if (txtNombreArchivo.Text==null || txtNombreArchivo.Equals(""))
			{
				MessageBox.Show("Falta el nombre del archivo a guardar.");
			}
			else
			{
				return;
			}

			if (txtPassword.Text == null || txtPassword.Equals(""))
			{
				MessageBox.Show("¡Falta la contraseña!");
			}
			else
			{
				return;
			}*/

			String archivo_a_guardar = txtNombreArchivo.Text;
			String archivo_a_cifrar = openFileDialog1.FileName;
			String password = txtPassword.Text;

			String url_archivo_guardar = Path.GetDirectoryName(openFileDialog1.FileName); //se obtiene el path dponde se guardará el archivo

			url_archivo_guardar += "\\" + archivo_a_guardar;
			Console.WriteLine(url_archivo_guardar);

			if (result == DialogResult.OK) // Test result.
			{
				//string file = openFileDialog1.FileName;
				Console.WriteLine("33");
				try
				{

					ServerUtils.DescifraConWS(url_archivo_guardar, archivo_a_cifrar, password);

					//ServerUtils.recibeArchivoSeguro2("salida.mp4", url_archivo_guardar, password);
					
					//ServerUtils.recibeArchivoSeguro2("salida.mp4", "C:\\Users\\jonat\\OneDrive\\Escritorio\\mio.mp4", "iso.txt");
					//CryptoUtils.Decrypt("C:\\Users\\jonat\\OneDrive\\Escritorio\\iso2.txt", "C:\\Users\\jonat\\OneDrive\\Escritorio\\iso24.txt", "iso.txt");
					//progressBar1.Value = 50;
					MessageBox.Show("Se recibió (y descifró) el archivo en: " + url_archivo_guardar);
				}
				catch (IOException)
				{
					Console.WriteLine("paso un error");
				}
				progressBar1.Value = 100;
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			string infile = "C:\\Users\\jonat\\OneDrive\\Escritorio\\Oracle.mp4";
			string outfile = "C:\\Users\\jonat\\OneDrive\\Escritorio\\salida.txt";
			string outfileDEC = "C:\\Users\\jonat\\OneDrive\\Escritorio\\salida2.mp4";
			//File.Create(outfile);

			//string keyfile = args[2];
			//var key = File.ReadAllBytes(keyfile);
			CryptoUtils uts = new CryptoUtils();
			CryptoUtils.Encrypt(infile, outfile, "test");
			CryptoUtils.Decrypt(outfile, outfileDEC, "test");
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
				txtPassword.PasswordChar = '*';
			else txtPassword.PasswordChar = '\0';
		}
	}
}

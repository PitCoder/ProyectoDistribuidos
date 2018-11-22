using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ArchivoWebService
{
	static class Constants
	{
		public const int SIZE_OF_CHUNKS = 5;//en mb

	}
	class ServerUtils
	{
		public static void recibeArchivo(String remotePath, String localPath)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			int numeroDePedazos = serv.getNumberOfChunks(remotePath);
			int i = 0;
			byte[] bin = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			var stream = new FileStream(localPath, FileMode.Append);

			for (i = 0; i < numeroDePedazos; i++)
			{
				bin = serv.getNChunk(remotePath, i);
				stream.Write(bin, 0, bin.Length);


			}
			Console.WriteLine("Recibido en: " + stopwatch.Elapsed);
			serv.Close();
			stream.Close();


			//Console.Read();

		}

		public static void enviaArchivo(String remotePath, String localPath)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			long length = new System.IO.FileInfo(localPath).Length;
			long numberOfChunks = (long)Math.Ceiling((double)(length / Constants.SIZE_OF_CHUNKS) / 1000000);
			int i = 0;

			//serv.createFile(remotePath);
			for (i = 0; i < numberOfChunks; i++)
			{
				using (FileStream fs = File.OpenRead(localPath))
				{
					byte[] bytesRead = new byte[1000000 * Constants.SIZE_OF_CHUNKS];

					fs.Seek((long)i * 1000000 * Constants.SIZE_OF_CHUNKS, SeekOrigin.Begin);

					fs.Read(bytesRead, 0, bytesRead.Length);
					serv.sendBytes(bytesRead, remotePath);
					//Console.WriteLine("f");
				}
			}
			Console.WriteLine("Enviado en: " + stopwatch.Elapsed);

		}

		public static void enviaArchivoSeguro(String remotePath, String localPath, String password)
		{
			if (File.Exists("auxiliar.aux"))
				File.Delete("auxiliar.aux");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			CryptoUtils.Encrypt(localPath, "auxiliar.aux", password);
			//Console.WriteLine("fido");
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			long length = new System.IO.FileInfo("auxiliar.aux").Length;
			long numberOfChunks = (long)Math.Ceiling((double)(length / Constants.SIZE_OF_CHUNKS) / 1000000);
			int i = 0;
			byte[] bytesRead = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			serv.createFile(remotePath);
			for (i = 0; i < numberOfChunks; i++)
			{
				using (FileStream fs = File.OpenRead("auxiliar.aux"))
				{					
					fs.Seek((long)i * 1000000 * Constants.SIZE_OF_CHUNKS, SeekOrigin.Begin);

					fs.Read(bytesRead, 0, bytesRead.Length);
					serv.sendBytes(bytesRead, remotePath);
					if(i%5==1) Console.WriteLine("-");
					if (i % 4 == 2) Console.WriteLine("/");
					if (i % 4 == 3) Console.WriteLine("|");
					if (i % 4 == 0) Console.Clear();
				}
			}
			Console.WriteLine("Enviado en: " + stopwatch.Elapsed);

		}

		public static void recibeArchivoSeguro(String remotePath, String localPath, String password)
		{
			if (File.Exists(localPath))
				File.Delete(localPath);

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			int numeroDePedazos = serv.getNumberOfChunks(remotePath);
			int i = 0;
			byte[] bin = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			var stream = new FileStream(localPath, FileMode.Append);

			for (i = 0; i < numeroDePedazos; i++)
			{
				bin = serv.getNChunk(remotePath, i);
				stream.Write(bin, 0, bin.Length);


			}
			Console.WriteLine("Recibido en: " + stopwatch.Elapsed);
			serv.Close();
			stream.Close();
			CryptoUtils.Decrypt(localPath, localPath+"DEC", password);

			//Console.Read();

		}

		public static void enviaArchivoSeguro2(String remotePath, String localPath, String password)
		{
		//	if (File.Exists("auxiliar.aux"))
			//	File.Delete("auxiliar.aux");

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			//CryptoUtils.Encrypt(localPath, "auxiliar.aux", password);
			Console.WriteLine("fido");
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			long length = new System.IO.FileInfo(localPath).Length;
			long numberOfChunks = (long)Math.Ceiling((double)(length / Constants.SIZE_OF_CHUNKS) / 1000000);
			long i = 0;
			byte[] bytesRead = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			//serv.createFile(remotePath);
			for (i = 0; i < numberOfChunks; i++)
			{
				using (FileStream fs = File.OpenRead(localPath))
				{
					fs.Seek((long)i * 1000000 * Constants.SIZE_OF_CHUNKS, SeekOrigin.Begin);

					fs.Read(bytesRead, 0, bytesRead.Length);
					serv.sendBytes(CryptoUtils.Encrypt(bytesRead, password), remotePath);
					/*if (i % 4 == 0) Console.Write("-");
					if (i % 4 == 1) Console.Write("\\");
					if (i % 4 == 2) Console.Write("|");
					if (i % 4 == 3) Console.Write("/");*/

				}
			}
			Console.WriteLine("Enviado en: " + stopwatch.Elapsed);

		}

		public static void recibeArchivoSeguro2(String remotePath, String localPath, String password)
		{
			if (File.Exists(localPath))
				File.Delete(localPath);

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			int numeroDePedazos = serv.getNumberOfChunks(remotePath);
			long i = 0;
			byte[] bin = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			var stream = new FileStream(localPath, FileMode.Append);

			for (i = 0; i < numeroDePedazos; i++)
			{
				bin = serv.getNChunk(remotePath, i);
				stream.Write(CryptoUtils.Decrypt(bin,password), 0, bin.Length);

				if (i % 4 == 0) Console.Write("-");
				if (i % 4 == 1) Console.Write("\\");
				if (i % 4 == 2) Console.Write("|");
				if (i % 4 == 3) Console.Write("/");

			}
			Console.WriteLine("Recibido en: " + stopwatch.Elapsed);
			serv.Close();
			stream.Close();
			//CryptoUtils.Decrypt(localPath, localPath + "DEC", password);

			//Console.Read();

		}
	}
}

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
		
		public static void CifraConWS(String pathNewFile, String pathOriginalFile, String password)
		{

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			//CryptoUtils.Encrypt(localPath, "auxiliar.aux", password);

			Console.WriteLine("fido");
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			long length = new System.IO.FileInfo(pathOriginalFile).Length;
			long numberOfChunks = (long)Math.Ceiling((double)(length / Constants.SIZE_OF_CHUNKS) / 1000000);
			long i = 0;

			byte[] bytesRead = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			byte[] bytesToWrite = new byte[1000000 * Constants.SIZE_OF_CHUNKS];

			var stream = new FileStream(pathNewFile, FileMode.Append);

			//serv.createFile(remotePath);
			for (i = 0; i < numberOfChunks; i++)
			{
				using (FileStream fs = File.OpenRead(pathOriginalFile))
				{
					fs.Seek((long)i * 1000000 * Constants.SIZE_OF_CHUNKS, SeekOrigin.Begin);

					fs.Read(bytesRead, 0, bytesRead.Length);
					bytesToWrite=serv.cifrar(CryptoUtils.Encrypt(bytesRead, password));
					stream.Write(bytesToWrite, 0, bytesToWrite.Length);

				}
			}
			Console.WriteLine("Enviado en: " + stopwatch.Elapsed);

		}


		public static void DescifraConWS(String pathNewFile, String pathOriginalFile, String password)
		{

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			//CryptoUtils.Encrypt(localPath, "auxiliar.aux", password);

			Console.WriteLine("fido");
			ServicioArchivo.ServicioDeArchivoClient serv = new ServicioArchivo.ServicioDeArchivoClient();

			long length = new System.IO.FileInfo(pathOriginalFile).Length;
			long numberOfChunks = (long)Math.Ceiling((double)(length / Constants.SIZE_OF_CHUNKS) / 1000000);
			long i = 0;

			byte[] bytesRead = new byte[1000000 * Constants.SIZE_OF_CHUNKS];
			byte[] bytesToWrite = new byte[1000000 * Constants.SIZE_OF_CHUNKS];

			var stream = new FileStream(pathNewFile, FileMode.Append);

			//serv.createFile(remotePath);
			for (i = 0; i < numberOfChunks; i++)
			{
				using (FileStream fs = File.OpenRead(pathOriginalFile))
				{
					fs.Seek((long)i * 1000000 * Constants.SIZE_OF_CHUNKS, SeekOrigin.Begin);

					fs.Read(bytesRead, 0, bytesRead.Length);
					bytesToWrite = serv.descifrar(CryptoUtils.Decrypt(bytesRead, password));
					stream.Write(bytesToWrite, 0, bytesToWrite.Length);

				}
			}
			Console.WriteLine("Enviado en: " + stopwatch.Elapsed);

		}


	}
}

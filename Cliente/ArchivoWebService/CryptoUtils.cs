using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
/*
 *                  String ax=CryptoUtils.Decrypt(CryptoUtils.Encrypt("Jonathan", "jonathan"), "jonathan");
					byte[] cv = { 0x65, 0x66, 0x67, 0x68, 0x69, 0x70, 0x71 };
				    byte[] af = CryptoUtils.Decrypt(CryptoUtils.Encrypt(cv, "jonathan"), "jonathan");
					Console.WriteLine(ax);
					Console.WriteLine(Encoding.UTF8.GetString(af));
 */

public class CryptoUtils
{
	//Función que cifra un byte[] dado un byte[]
	public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
	{
		MemoryStream ms = new MemoryStream(); //Flujo de memoria por el que se comunican los datos

		Aes alg = Aes.Create();
		
		alg.Key = Key;
		alg.IV = IV;
		alg.Padding = PaddingMode.Zeros;
		//Console.WriteLine(Encoding.UTF8.GetString(alg.Key));

		CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write); //Flujo de datos cifrados
		
		cs.Write(clearData, 0, clearData.Length); //Se escriben los bytes en claro

		//cs.FlushFinalBlock();
		cs.Close();			//Se cierra el flujo

		byte[] encryptedData = ms.ToArray();	//los bytes de
		return encryptedData;
	}

	// Cifra un string dado un password
	public static string Encrypt(string clearText, string Password)
	{
		byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText); //Se pasa a byte[] el texto en claro
		
		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
			0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});	//se usa salt para "derivar" los bytes
		
		byte[] encryptedData = Encrypt(clearBytes,
				 pdb.GetBytes(32), pdb.GetBytes(16)); //Se cifran el byte[]

		return Convert.ToBase64String(encryptedData); //se regresa los datos cifrados como un string
	}

	// Se cifra un byte[] usando un password
	public static byte[] Encrypt(byte[] clearData, string Password)
	{
		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
			0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});	//se usa salt para "derivar" los bytes de la cadena
		
		return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
	}

	// Se cifra un archivo en otro usando una cadena
	public static void Encrypt(string fileIn, string fileOut, string Password)
	{
		// Flujos de bytes para los archivos
		FileStream fsIn  = new FileStream(fileIn,  FileMode.Open, FileAccess.Read);
		FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

		//Se derivan una llave y un IV dado el string 'password'
		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
		Aes alg = Aes.Create();
		alg.Key = pdb.GetBytes(32);
		//Console.WriteLine(Encoding.UTF8.GetString(alg.Key));
		alg.IV = pdb.GetBytes(16);
		alg.Padding = PaddingMode.Zeros;

		//Se crea un flujo de cifrado sobre el cual se enviarán los bytes del cifrador
		CryptoStream cs = new CryptoStream(fsOut,
			alg.CreateEncryptor(), CryptoStreamMode.Write);

		//Buffer para ir leyendo el archivo por bloques
		int bufferLen = 4096;
		byte[] buffer = new byte[bufferLen];
		int bytesRead;
		do
		{		
			//se lee el bloque del archivo
			bytesRead = fsIn.Read(buffer, 0, bufferLen);
			// es cifrado
			cs.Write(buffer, 0, bytesRead);

			//cs.FlushFinalBlock();
		} while (bytesRead != 0);

		
		cs.Close();
		fsIn.Close();
	}

	public static byte[] Decrypt(byte[] cipherData,	byte[] Key, byte[] IV)
	{		
		MemoryStream ms = new MemoryStream();
		
		Aes alg = Aes.Create();
		
		alg.Key = Key;
		alg.IV = IV;
		alg.Padding = PaddingMode.Zeros;

		//Console.WriteLine(Encoding.UTF8.GetString(alg.Key));

		CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
		cs.Write(cipherData, 0, cipherData.Length);
		//cs.FlushFinalBlock();
		cs.Close();
		byte[] decryptedData = ms.ToArray();
		return decryptedData;
	}

	public static string Decrypt(string cipherText, string Password)
	{
		byte[] cipherBytes = Convert.FromBase64String(cipherText);
		
		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65,
			0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

		byte[] decryptedData = Decrypt(cipherBytes,
		   pdb.GetBytes(32), pdb.GetBytes(16));

		return System.Text.Encoding.Unicode.GetString(decryptedData);
	}

	public static byte[] Decrypt(byte[] cipherData, string Password)
	{
		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
			0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

		return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
	}

	public static void Decrypt(string fileIn, string fileOut, string Password)
	{
		FileStream fsIn = new FileStream(fileIn,
					FileMode.Open, FileAccess.Read);
		FileStream fsOut = new FileStream(fileOut,
					FileMode.OpenOrCreate, FileAccess.Write);

		PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
			new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
			0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
		Aes alg = Aes.Create();
		alg.Key = pdb.GetBytes(32);
		//Console.WriteLine(Encoding.UTF8.GetString(alg.Key));
		alg.IV = pdb.GetBytes(16);
		alg.Padding = PaddingMode.Zeros;
		CryptoStream cs = new CryptoStream(fsOut,
			alg.CreateDecryptor(), CryptoStreamMode.Write);
		int bufferLen = 4096;
		byte[] buffer = new byte[bufferLen];
		int bytesRead;
		do
		{
			bytesRead = fsIn.Read(buffer, 0, bufferLen);
			cs.Write(buffer, 0, bytesRead);
		} while (bytesRead != 0);
		//cs.FlushFinalBlock();
		cs.Close(); 
		fsIn.Close();
	}
}

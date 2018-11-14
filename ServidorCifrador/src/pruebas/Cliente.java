package pruebas;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;
import cifrado.Operaciones;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Arrays;
import java.util.Scanner;

/**
 *
 * @author cesar
 */
public class Cliente {

  public static void main(String[] args) {
    System.out.print("Dirección IP: ");
    String dirIP = new Scanner(System.in).nextLine();

    String archivo1 = "prueba.txt";
    String outputFile = "cifrado.txt";

    try {
      Operaciones ope = (Operaciones) Naming.lookup("//" + dirIP + "/cifrado");

      /* Lectura de archivo */
      FileInputStream inputStream = new FileInputStream(archivo1);      
      byte[] inputBytes = new byte[(int) new File(archivo1).length()];
      inputStream.read(inputBytes);
      
      System.out.println("->" + inputBytes.length);

      FileOutputStream outputStream = new FileOutputStream(outputFile);
      outputStream.write(ope.cifrar("AES", "1111111111111111", inputBytes));

      inputStream.close();
      outputStream.close();
    } catch (NotBoundException | MalformedURLException | RemoteException | FileNotFoundException ex) {
      Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
    } catch (IOException ex) {
      Logger.getLogger(Cliente.class.getName()).log(Level.SEVERE, null, ex);
    }
  }
}

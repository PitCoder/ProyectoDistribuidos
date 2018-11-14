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

        String archivoOriginal = "kodim23.png";
        String archivoCifrado = "cifrado.png";
        String archivoDescifrado = "descifrado.png";

        try {
            Operaciones ope = (Operaciones) Naming.lookup("//" + dirIP + "/cifrado");

            /* Lectura de archivo */
            FileInputStream inputStream = new FileInputStream(archivoOriginal);
            byte[] inputBytes = new byte[(int) new File(archivoOriginal).length()];
            inputStream.read(inputBytes);

            System.out.println("->" + inputBytes.length);

            FileOutputStream outputStream = new FileOutputStream(archivoCifrado);            
            outputStream.write(ope.cifrar("AES", "1111111111111111", inputBytes));
            
            

            inputStream.close();
            outputStream.close();
            
            /*Ahora desciframos*/
            
            inputStream = new FileInputStream(archivoCifrado);
            inputBytes = new byte[(int) new File(archivoCifrado).length()];
            inputStream.read(inputBytes);

            System.out.println("->" + inputBytes.length);
            
            FileOutputStream outputStream2 = new FileOutputStream(archivoDescifrado);
            outputStream2.write(ope.descifrar("AES", "1111111111111111", inputBytes));
            
            outputStream2.close();
            inputStream.close();
        } catch (NotBoundException | MalformedURLException | RemoteException | FileNotFoundException ex) {
            ex.printStackTrace();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}

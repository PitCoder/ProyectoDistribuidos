package servidor;

import java.net.MalformedURLException;
import java.rmi.AlreadyBoundException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.util.logging.Level;
import java.util.logging.Logger;
import cifrado.Implementacion;
import cifrado.Operaciones;
import java.util.Scanner;

/**
 *
 * @author cesar
 */
public class Servidor {

    public static void main(String[] args) {
        System.out.println("Dirección IP de este servidor: ");
        String myIP = new Scanner(System.in).nextLine();

        System.setProperty("java.rmi.server.hostname", myIP);

        try {
            Operaciones ope;

            /* Se crea un registro en el puerto establecido */
            LocateRegistry.createRegistry(1099);

            /* Registrar el elemento en el servicio de nombres */
 /* Debe de apuntar a la implementacion */
            ope = new Implementacion();

            /* bind("nombre", quien conoce las operaciones) */
            Naming.bind("cifrado", ope);

            System.out.println("Servidor funcionando!");
        } catch (RemoteException ex) {
            Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
        } catch (AlreadyBoundException ex) {
            Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}

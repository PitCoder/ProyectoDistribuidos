package cifrado;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author cesar
 */
public interface Operaciones extends Remote {

  public byte[] cifrar(String cifrador, String llave, byte[] parteArchivo) throws RemoteException;

  public String saluda() throws RemoteException;
}

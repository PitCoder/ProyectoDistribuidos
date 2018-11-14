package cifrado;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import javax.crypto.Cipher;

/**
 *
 * @author cesar
 */
public class Implementacion extends UnicastRemoteObject implements Operaciones {

  public Implementacion() throws RemoteException {
    super();
  }

  @Override
  public byte[] cifrar(String cifrador, String llave, byte[] parteArchivo) throws RemoteException {
    UtileriasCifrado uc = new UtileriasCifrado();
    uc.setCifrado(cifrador);
    uc.setModoCifrado(Cipher.ENCRYPT_MODE);
    
    return uc.cifrado(llave, parteArchivo);
  }

}

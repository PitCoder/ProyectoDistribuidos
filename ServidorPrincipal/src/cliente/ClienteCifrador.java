package cliente;

import cifrado.Operaciones;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author cesar
 */
public class ClienteCifrador {

  private String direccionIP;
  private String cifrador;
  private String llave;

  private Operaciones ope;

  public void setDireccionIP(String direccionIP) {
    this.direccionIP = direccionIP;
  }

  public void setCifrador(String cifrador) {
    this.cifrador = cifrador;
  }

  public void setLlave(String llave) {
    this.llave = llave;
  }

  public void conectar() {
    System.out.println("Conectando a " + this.direccionIP);
    try {
      ope = (Operaciones) Naming.lookup("//" + this.direccionIP + "/cifrado");
    } catch (NotBoundException | MalformedURLException | RemoteException ex) {
      Logger.getLogger(ClienteCifrador.class.getName()).log(Level.SEVERE, null, ex);
    }
  }

  public void cifrar(byte[] parteArchivo) {
    try {
      ope.cifrar(this.cifrador, this.llave, parteArchivo);
    } catch (RemoteException ex) {
      Logger.getLogger(ClienteCifrador.class.getName()).log(Level.SEVERE, null, ex);
    }
  }

  public String saludar() {
    try {
      return ope.saluda();
    } catch (RemoteException ex) {
      Logger.getLogger(ClienteCifrador.class.getName()).log(Level.SEVERE, null, ex);
    }
    return null;
  }

}

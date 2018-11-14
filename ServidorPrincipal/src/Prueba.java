
import cliente.ClienteCifrador;

/**
 *
 * @author cesar
 */
public class Prueba {
  public static void main(String[] args) {
    ClienteCifrador aes = new ClienteCifrador();
    aes.setDireccionIP("192.168.0.8");
    aes.conectar();
    
    System.out.println(aes.saludar());
  }
}

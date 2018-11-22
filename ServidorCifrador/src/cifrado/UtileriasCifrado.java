package cifrado;

import java.security.InvalidKeyException;
import java.security.Key;
import java.security.NoSuchAlgorithmException;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

/**
 *
 * @author cesar
 */
public class UtileriasCifrado {

  private String cifrado;
  private int modoCifrado;

  public byte[] cifrado(String llave, byte[] datos) {
    try {
      Key secretKey = new SecretKeySpec(llave.getBytes(), this.cifrado);
      Cipher cipher = Cipher.getInstance(this.cifrado);
      cipher.init(this.modoCifrado, secretKey);
      

      return cipher.doFinal(datos);
    } catch (NoSuchPaddingException | NoSuchAlgorithmException
            | InvalidKeyException | BadPaddingException
            | IllegalBlockSizeException e) {
      e.printStackTrace();
      return null;
    }
  }
  
  public String getCifrado() {
    return cifrado;
  }

  public void setCifrado(String cifrado) {
    this.cifrado = cifrado;
  }

  public int getModoCifrado() {
    return modoCifrado;
  }

  public void setModoCifrado(int modoCifrado) {
    this.modoCifrado = modoCifrado;
  }
}

package Services;

import java.io.File;
import java.io.IOException;
import java.security.PublicKey;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author jonat
 */
@WebService(serviceName = "ServicioDeArchivo")
public class ServicioDeArchivo {

    static final int SIZE_OF_CHUNKS = 5;//en mb
    File archivoActual;
    PublicKey llavePublica;

    /**
     * This is a sample web service operation
     *
     * @param txt
     * @return
     */
    @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }

    


    /*Metodo necesario para que el server cifre un arreglo de bytes*/


    @WebMethod(operationName = "cifrar")
    public byte[] cifrar(byte[] bytesToEncrypt) throws IOException {
        //TODO write your implementation code here:   
        byte[] bytesCifrados=bytesToEncrypt;
        

        

        //System.out.println("Written");
        return bytesCifrados;
    }
    
    /*Metodo necesario para que el server descifre un arreglo de bytes*/


    @WebMethod(operationName = "descifrar")
    public byte[] descifrar(byte[] bytesToDecrypt) throws IOException {
        //TODO write your implementation code here:   
        byte[] bytesCifrados=bytesToDecrypt;
        
        

        

        //System.out.println("Written");
        return bytesCifrados;
    }

    

}

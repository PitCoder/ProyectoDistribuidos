package Services;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.file.Files;
import java.util.Arrays;
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

    /*Metodos necesarios para que el cliente reciba un archivo*/
    /**
     * Web service operation
     */
    @WebMethod(operationName = "getFileAsJFile")
    public File getFileAsJFile() {
        //TODO write your implementation code here:
        File f = new File("C:\\Users\\jonat\\Videos\\Captures\\untitled - GNS3 13_11_2018 12_51_28.mp4");
        return f;
    }

    /**
     * Web service operation
     *
     * @param url
     * @return
     * @throws java.io.IOException "C:\\Users\\jonat\\Videos\\Captures\\untitled
     * - GNS3 13_11_2018 12_51_28.mp4
     */
    @WebMethod(operationName = "getFileAsBytes")
    public byte[] getFileAsBytes(String url) throws IOException {
        //TODO write your implementation code here:
        File f = new File(url);
        byte[] bytesDelFile = Files.readAllBytes(f.toPath());
        return bytesDelFile;
    }

    @WebMethod(operationName = "getNameOfFile")
    public String getNameOfFile(String url) throws IOException {
        //TODO write your implementation code here:
        File f = new File(url);
        byte[] bytesDelFile = Files.readAllBytes(f.toPath());
        return f.getName();
    }

    @WebMethod(operationName = "getNumberOfChunks")
    public int getNumberOfChunks(String url) throws IOException {
        //TODO write your implementation code here:
        File f = new File(url);
        //System.out.println("g:" + f.length());
        //System.err.println((double) (f.length() / (SIZE_OF_CHUNKS)) / 1000000);
        int number = (int) Math.ceil((double) (f.length() / (SIZE_OF_CHUNKS)) / 1000000);
        return number;
    }

    @WebMethod(operationName = "getNChunk")
    public byte[] getNChunk(String url, long n) throws IOException {
        //TODO write your implementation code here:
        byte[] bytesToReturn;
        File f = new File(url);

        RandomAccessFile raf = new RandomAccessFile(f, "r");

        byte[] bytesDelFile = new byte[SIZE_OF_CHUNKS * 1000000];

        raf.seek(n * SIZE_OF_CHUNKS * 1000000);

        raf.read(bytesDelFile);

        int number = (int) Math.ceil((double) (f.length() / (SIZE_OF_CHUNKS)) / 1000000);
        if (number == (n - 1)) {
            bytesToReturn = Arrays.copyOfRange(bytesDelFile, 0, bytesDelFile.length - 1);
        } else {
            //bytesToReturn = Arrays.copyOfRange(bytesDelFile, n * (1000000 * SIZE_OF_CHUNKS), (n + 1) * (1000000 * SIZE_OF_CHUNKS));
            bytesToReturn = Arrays.copyOfRange(bytesDelFile, 0, SIZE_OF_CHUNKS * 1000000);
        }
        //System.out.println("BytesEnviados="+bytesToReturn.length);
        raf.close();

        return bytesToReturn;
    }

    /*Metodos necesarios para que el cliente envie un archivo*/
    @WebMethod(operationName = "createFile")
    public int createFile(String url) throws IOException {
        //TODO write your implementation code here:   

        archivoActual = new File(url);
        if (archivoActual.exists()) {
            archivoActual.delete();
        }
        archivoActual.createNewFile();
        System.out.println("Archivo creado as:" + url);
        return 1;
    }

    @WebMethod(operationName = "sendBytes")
    public int sendBytes(byte[] bytesToWrite, String url) throws IOException {
        //TODO write your implementation code here:   

        if (!archivoActual.exists()) {
            archivoActual = new File(url);
        }

        try (FileOutputStream output = new FileOutputStream(url, true)) {
            output.write(bytesToWrite);
            output.close();
        }

        //System.out.println("Written");
        return 1;
    }

}

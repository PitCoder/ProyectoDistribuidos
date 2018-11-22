/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Services;

import static java.nio.charset.StandardCharsets.UTF_8;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.SecureRandom;
import java.util.Base64;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.crypto.Cipher;

/**
 *
 * @author jonat
 */
public class PublicEncrypt {

    public static void main(String[] args) {
        try {
            //First generate a public/private key pair
            KeyPair pair = generateKeyPair();

//Our secret message
            String message = "the answer to life the universe and everything";

//Encrypt the message
            String cipherText = encrypt(message, pair.getPublic());

//Now decrypt it
            String decipheredMessage = decrypt(cipherText, pair.getPrivate());

            System.out.println(decipheredMessage);
        } catch (Exception ex) {
            Logger.getLogger(PublicEncrypt.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public static KeyPair generateKeyPair() throws Exception {
        KeyPairGenerator generator = KeyPairGenerator.getInstance("RSA");
        generator.initialize(2048, new SecureRandom());
        KeyPair pair = generator.generateKeyPair();

        return pair;
    }

    public static String encrypt(String plainText, PublicKey publicKey) throws Exception {
        Cipher encryptCipher = Cipher.getInstance("RSA");
        encryptCipher.init(Cipher.ENCRYPT_MODE, publicKey);

        byte[] cipherText = encryptCipher.doFinal(plainText.getBytes(UTF_8));

        return Base64.getEncoder().encodeToString(cipherText);
    }

    public static String decrypt(String cipherText, PrivateKey privateKey) throws Exception {
        byte[] bytes = Base64.getDecoder().decode(cipherText);

        Cipher decriptCipher = Cipher.getInstance("RSA");
        decriptCipher.init(Cipher.DECRYPT_MODE, privateKey);

        return new String(decriptCipher.doFinal(bytes), UTF_8);
    }

}

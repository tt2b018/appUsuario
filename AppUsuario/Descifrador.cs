using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace mecanismoTT
{

    class Descifrador
    {
        private byte[] llaveAES;
        public Descifrador(String pathPublicKey)
        {
            byte[] llavePrivada;
            byte[] llavePublicaUsuario;
            String pathLlaveAdmin = "" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\privateKeyAdmin.bin";
            llavePrivada = File.ReadAllBytes(pathLlaveAdmin);
            //llavePrivada = File.ReadAllBytes(@"C:\opt\privateKeyAdmin.bin");
            //llavePrivada = File.ReadAllBytes(@"C:\Users\Angelica\Documents\ESCOM\TT\Código\LlavesLuis\privateKeyAdmin.bin");
            ECDiffieHellmanCng ECD = new ECDiffieHellmanCng(CngKey.Import(llavePrivada, CngKeyBlobFormat.EccPrivateBlob));
            ECD.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
            ECD.HashAlgorithm = CngAlgorithm.Sha256;
            llavePublicaUsuario = File.ReadAllBytes(pathPublicKey);
            CngKey llaveUsuario = CngKey.Import(llavePublicaUsuario, CngKeyBlobFormat.EccPublicBlob);
            llaveAES = ECD.DeriveKeyMaterial(llaveUsuario);
        }

        public String descifrar(byte[] texto)
        {
            Aes aes = new AesCryptoServiceProvider();
            byte[] iv = new byte[16];
            Array.Copy(texto, texto.Length - 16, iv, 0, 16);
            aes.Key = llaveAES;
            aes.IV = iv;
            MemoryStream plainText = new MemoryStream();
            CryptoStream cs = new CryptoStream(plainText, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(texto, 0, texto.Length - 16);
            cs.Dispose();
            cs.Close();
            String textoDescifrado = Encoding.UTF8.GetString(plainText.ToArray());
            plainText.Dispose();
            plainText.Close();
            aes.Dispose();
            aes.Clear();
            return textoDescifrado;
        }

    }
}

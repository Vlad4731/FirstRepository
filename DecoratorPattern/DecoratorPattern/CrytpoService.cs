using System;
using System.IO;
using System.Security.Cryptography;

namespace DecoratorPattern
{
    internal static class CrytpoService
    {
        public static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] initVect)
        {
            // Check arguments.
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (key == null || key.Length == 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (initVect == null || initVect.Length == 0)
            {
                throw new ArgumentNullException(nameof(initVect));
            }

            byte[] encrypted;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = initVect;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream memoryEncrypt = new MemoryStream())
                {
                    using (CryptoStream cryptoEncrypt = new CryptoStream(memoryEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoEncrypt))
                        {
                            // Write all data to the stream.
                            streamWriter.Write(plainText);
                        }

                        encrypted = memoryEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptString(byte[] cipherText, byte[] key, byte[] initVect)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length == 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (key == null || key.Length == 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (initVect == null || initVect.Length == 0)
            {
                throw new ArgumentNullException(nameof(initVect));
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = initVect;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream memoryDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream cryptoDecrypt = new CryptoStream(memoryDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
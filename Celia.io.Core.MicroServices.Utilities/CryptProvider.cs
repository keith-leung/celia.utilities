using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class CryptProvider
    {
        #region AES
        public static CryptAESKey GenerateAESKey()
        {
            var aesKey = EncryptProvider.CreateAesKey();

            return new CryptAESKey()
            {
                IV = aesKey.IV,
                Key = aesKey.Key,
            };
        }

        public static string AESEncrypt(string source, CryptAESKey key)
        {
            if (!string.IsNullOrEmpty(source) && key != null && string.IsNullOrEmpty(key.IV))
            {
                //不带加密向量
                var encrypted = EncryptProvider.AESEncrypt(source, key.Key);
                return encrypted;
            }
            else if (!string.IsNullOrEmpty(source) && key != null)
            {
                //带加密向量
                var encrypted = EncryptProvider.AESEncrypt(source, key.Key, key.IV);
                return encrypted;
            }

            return source;
        }

        public static string AESDecrypt(string encryptedSource, CryptAESKey key)
        {
            if (!string.IsNullOrEmpty(encryptedSource) && key != null && string.IsNullOrEmpty(key.IV))
            {
                //不带加密向量
                var encrypted = EncryptProvider.AESDecrypt(encryptedSource, key.Key);
                return encrypted;
            }
            else if (!string.IsNullOrEmpty(encryptedSource) && key != null)
            {
                //带加密向量
                var encrypted = EncryptProvider.AESDecrypt(encryptedSource, key.Key, key.IV);
                return encrypted;
            }

            return encryptedSource;
        }
        #endregion

        #region RSA

        public static CryptRSAKey GenerateRSAKey()
        {
            return GenerateRSAKey(RsaKeySize.R2048);
        }

        public static CryptRSAKey GenerateRSAKey(RsaKeySize keySize)
        {
            var rsaKey = EncryptProvider.CreateRsaKey(
                (RsaSize)(Enum.Parse(typeof(RsaSize), $"{(int)keySize}")));    //default is 2048

            // var rsaKey = EncryptProvider.CreateRsaKey(RsaSize.R3072); 

            return new CryptRSAKey()
            {
                Exponent = rsaKey.Exponent,
                Modulus = rsaKey.Modulus,
                PublicKey = rsaKey.PublicKey,
                PrivateKey = rsaKey.PrivateKey,
            };
        }

        public static string RSAEncrypt(string source, string publicKey)
        {
            if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(publicKey))
            {
                var encrypted = EncryptProvider.RSAEncrypt(publicKey, source, RSAEncryptionPadding.Pkcs1);
                return encrypted;
            }

            return source;
        }

        public static string RSADecrypt(string encryptedSource, string privateKey)
        {
            if (!string.IsNullOrEmpty(encryptedSource) && !string.IsNullOrEmpty(privateKey))
            {
                var encrypted = EncryptProvider.RSAEncrypt(
                    privateKey, encryptedSource, RSAEncryptionPadding.Pkcs1);
                return encrypted;
            }

            return encryptedSource;
        }
        #endregion
    }
}

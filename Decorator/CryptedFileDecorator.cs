using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Decorator
{
    public class CryptedFileDecorator : Decorator
    {
        #region Private fields

        private byte[] _scrambleKey;
        private byte[] _iv;

        #endregion

        #region Constructor

        public CryptedFileDecorator(FileComponent fileComponent, string key, string iv)
            :base(fileComponent)
        {
            var textConverter = new UTF8Encoding();
            _scrambleKey = textConverter.GetBytes(key);
            _iv = textConverter.GetBytes(iv);
        }

        #endregion

        #region FileComponent

        public override void Save(string fileName, string content)
        {
            base.Save(fileName, Encrypt(content));
        }

        public override string Load(string fileName)
        {
            return Decrypt(base.Load(fileName));
        }

        #endregion

        #region Encrypt/Decrypt methods

        private string Encrypt(string toProcess)
        {
            var textConverter = new UTF8Encoding();
            var toEncrypt = textConverter.GetBytes(toProcess);

            var rc2CSP = new RC2CryptoServiceProvider();
            var encryptor = rc2CSP.CreateEncryptor(this._scrambleKey, this._iv);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            //Write all data to the crypto stream and flush it.
            // Encode length as first 4 bytes
            var length = new byte[4];
            length[0] = (byte)(toEncrypt.Length & 0xFF);
            length[1] = (byte)((toEncrypt.Length >> 8) & 0xFF);
            length[2] = (byte)((toEncrypt.Length >> 16) & 0xFF);
            length[3] = (byte)((toEncrypt.Length >> 24) & 0xFF);
            csEncrypt.Write(length, 0, 4);
            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            //Return results
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        private string Decrypt(string toProcess)
        {
            var textConverter = new UTF8Encoding();
            var toDecrypt = Convert.FromBase64String(toProcess);

            var rc2CSP = new RC2CryptoServiceProvider();
            var decryptor = rc2CSP.CreateDecryptor(this._scrambleKey, this._iv);

            var msDecrypt = new MemoryStream(toDecrypt);
            var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

            var fromEncrypt = new byte[toDecrypt.Length - 4];

            //Read the data out of the crypto stream.
            var length = new byte[4];
            csDecrypt.Read(length, 0, 4);
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
            var len = (int)length[0] | (length[1] << 8) | (length[2] << 16) | (length[3] << 24);

            return textConverter.GetString(fromEncrypt).Substring(0, len);
        }

        #endregion
    }


}

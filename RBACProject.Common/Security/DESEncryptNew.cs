using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Common
{
    public class DESEncryptNew
    {
        private static byte[] _key = Encoding.UTF8.GetBytes("12345678"); // 设置密钥，可以自定义
        private static byte[] _iv = Encoding.UTF8.GetBytes("87654321"); // 设置向量，可以自定义

        public static string Encrypt(string data)
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(data);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string data)
        {
            byte[] inputByteArray = Convert.FromBase64String(data);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(_key, _iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }


    }
}

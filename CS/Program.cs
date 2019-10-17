using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string to encrypt:");
            string stringToEncrypt = Console.ReadLine();
            Console.WriteLine("Encrypted string: " + GetEncryptedStringDES(stringToEncrypt));
            Console.WriteLine("Encrypted string AES: " + GetEncryptedStringAES(stringToEncrypt));
            Console.Read();
        }
        public static string GetEncryptedStringDES(string textToEncrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using ( StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write("dfklghsdljfgh;sdljfsdfdfgfdgdfgdfg");
                        sw.Flush();
                        cs.FlushFinalBlock();
                        sw.Flush();
                        return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    }
                }
            }
        }
        public static string GetEncryptedStringAES(string textToEncrypt)
        {
            AesManaged aes = new AesManaged();
            ICryptoTransform encryptor = aes.CreateEncryptor();
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(textToEncrypt);
                        sw.Flush();
                        cs.FlushFinalBlock();
                        sw.Flush();
                        return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
                    }
                }
            }
        }
    }
}

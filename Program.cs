using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;

namespace CalcBin
{
    class Program
    {
        public static String GetHash<T>(Stream stream) where T : HashAlgorithm
        {
            StringBuilder sb = new StringBuilder();

            MethodInfo create = typeof(T).GetMethod("Create", new Type[] { });
            using (T crypt = (T)create.Invoke(null, null))
            {
                byte[] hashBytes = crypt.ComputeHash(stream);
                foreach (byte bt in hashBytes)
                {
                    sb.Append(bt.ToString("x2"));
                }
            }
            return sb.ToString();
        }


        public static byte[] ToByteArray(string value)
        {
            char[] charArr = value.ToCharArray();
            byte[] bytes = new byte[charArr.Length];
            for (int i = 0; i < charArr.Length; i++)
            {
                byte current = Convert.ToByte(charArr[i]);
                bytes[i] = current;
            }

            return bytes;
        }

        static void Main(string[] args)
        {
            string Hash = "";
            string[] filePaths = Directory.GetFiles(@"Folder", "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < filePaths.Length; i++)
            {
                using (FileStream fStream = File.OpenRead(filePaths[i]))
                {
                    Console.Write(Hash[j]);
                    fStream.Close();
                }
                Console.WriteLine("");
            }
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.HelperClass
{
    public static class PassHashing
    {
        private static string MD5(this string password)
        {
            MD5CryptoServiceProvider md5pass = new MD5CryptoServiceProvider();

            byte[] arr = md5pass.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private static string SHA_1(this string password)
        {
            SHA1 sha1Hasher = SHA1.Create();
            byte[] shaArr = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < shaArr.Length; i++)
            {
                sb.Append(shaArr[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string Encrypt(this string pass)
        {
            pass = pass.SHA_1();
            pass = pass.MD5();
            pass = pass.SHA_1();
            pass = pass.MD5();
            return pass; 
        }

        public static string CreateNewPass(int characterNumber)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, characterNumber)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
            return result;
        }
    }
}

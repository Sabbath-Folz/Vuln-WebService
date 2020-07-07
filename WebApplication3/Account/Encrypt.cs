using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebApplication3.Account
{
	//class for creating md5 hashes
	public class Encrypt
    {
        public static string GetMD5Hash(string input)
        {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
				try
				{
					byte[] b = System.Text.Encoding.UTF8.GetBytes(input);
					b = md5.ComputeHash(b);
					return System.Convert.ToBase64String(b);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Source);
						return null;
				}
				}
        }
    }
}

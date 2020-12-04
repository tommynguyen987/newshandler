using System;

namespace MyUtility
{
    public class Utility
    {
        public static void AddScriptElement(System.Windows.Forms.WebBrowser wbr, string scriptCode)
        {
            dynamic document = wbr.Document;
            dynamic head = document.GetElementsByTagName("head")[0];
            dynamic scriptEl = document.CreateElement("script");
            scriptEl.SetAttribute("text", scriptCode.ToString());
            head.AppendChild(scriptEl);
        }

        private static string Get8CharacterRandomString()
        {
            return System.IO.Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            //return Guid.NewGuid().ToString().Substring(0, 8);
        }

        public static string GetRandomAlphaNumeric()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (System.Security.Cryptography.RNGCryptoServiceProvider crypto = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            System.Text.StringBuilder result = new System.Text.StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string RandomEmail()
        {
            //return GetUniqueKey(8) + "@gmail.com";
            return Get8CharacterRandomString() + "@gmail.com";
            //return GetRandomAlphaNumeric() + "@gmail.com";
        }
    }
}

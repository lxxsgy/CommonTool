using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace WebApplication2
{
    public partial class Encode_Decode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         
        }

        protected void btnEncode_Click(object sender, EventArgs e)
        {

            #region 散列加密 MD5

            //txtDecode.Text = EncryptHelper.GetMD5(this.txtSource.Text.Trim());//将加密后的字节数组转换为加密字符串

            #endregion

            #region  sha1加密
            // txtDecode.Text= EncryptHelper.Sha1(this.txtSource.Text);


            #endregion
            //  txtDecode.Text= EncryptHelper.StringTo3Des(this.txtSource.Text);

            txtDecode.Text = EncryptHelper.DesEncryptor(this.txtSource.Text);
        }

        protected void btnDecode_Click(object sender, EventArgs e)
        {
           // txtSource.Text = EncryptHelper.StringFrom3Des(this.txtDecode.Text);
            txtSource.Text = EncryptHelper.DesDecryptor(this.txtDecode.Text);


        }

  
    }

    public static class EncryptHelper
    {
     
        public static string GetMD5(string  code)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] palindata = Encoding.Default.GetBytes(code);//将要加密的字符串转换为字节数组
            byte[] encryptdata = md5.ComputeHash(palindata);//将字符串加密后也转换为字符数组
            string str = BitConverter.ToString(encryptdata).Replace("-", "");
            return str;
        }

        public static string Sha1(this string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            //var sb = new StringBuilder();
            //foreach (var t in data)
            //{
            //    sb.Append(t.ToString("X2"));
            //}

            //return sb.ToString();

            string result = BitConverter.ToString(data).Replace("-","");
            return result;
        }

        public static string DesEncryptor(string src)
        {
            string s = "qJzGEh6h";
            string s2 = "qcDY6X+a";
         var desProvider=  new  DESCryptoServiceProvider();
           
            desProvider.Key = Encoding.Default.GetBytes(s);
            desProvider.IV = Encoding.Default.GetBytes(s2);
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = desProvider.CreateEncryptor(desProvider.Key,desProvider.IV);

            byte[] bytes = Encoding.UTF8.GetBytes(src);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,transform,CryptoStreamMode.Write);
            cryptoStream.Write(bytes,0,bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string DesDecryptor(string src)
        {
            string s = "qJzGEh6h";
            string s2 = "qcDY6X+a";
            var desProvider = new DESCryptoServiceProvider();

            desProvider.Key = Encoding.Default.GetBytes(s);
            desProvider.IV = Encoding.Default.GetBytes(s2);
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = desProvider.CreateDecryptor(desProvider.Key, desProvider.IV);

            byte[] bytes = Convert.FromBase64String(src);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }



        public static string StringTo3Des(string src)
        {
            string s = "qJzGEh6hESZDVJeCnFPGuxzaiB7NLQM3";
            string s2 = "qcDY6X+aPLw=";
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = Convert.FromBase64String(s);
            tripleDESCryptoServiceProvider.IV = Convert.FromBase64String(s2);
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateEncryptor(tripleDESCryptoServiceProvider.Key, tripleDESCryptoServiceProvider.IV);
            byte[] bytes = Encoding.UTF8.GetBytes(src);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string StringFrom3Des(string src)
        {
            string s = "qJzGEh6hESZDVJeCnFPGuxzaiB7NLQM3";
            string s2 = "qcDY6X+aPLw=";
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = Convert.FromBase64String(s);
            tripleDESCryptoServiceProvider.IV = Convert.FromBase64String(s2);
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor(tripleDESCryptoServiceProvider.Key, tripleDESCryptoServiceProvider.IV);
            byte[] array = Convert.FromBase64String(src);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(array, 0, array.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }







    }
}
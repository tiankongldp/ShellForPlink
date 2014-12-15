using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ShellForPlink
{
    /// <summary>
    /// Summary description for Encryption
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// Default Key
        /// </summary>
        protected const string Key = "bmc.1001";
        /// <summary>
        /// Default IV
        /// </summary>
        protected const string IV = "bmc.1001";

        /// <summary>
        /// Initial
        /// </summary>
        public Encryption() { }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt, string sKey = Key, string sIV = IV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中
            //原来使用的UTF8编码，我改成Unicode编码了，不行
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt); 

            //建立加密对象的密钥和偏移量
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            //使得输入密码必须输入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
            //创建其支持存储区为内存的流
            MemoryStream ms = new MemoryStream();
            //将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream 
            //(It  will  end  up  in  the  memory  stream) 
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            //用缓冲区的当前状态更新基础数据源或储存库，随后清除缓冲区
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string 
            byte[] EncryptData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String(EncryptData, 0, EncryptData.Length);
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns> 
        public static string Decrypt(string pToDecrypt, string sKey = Key, string sIV = IV)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //Put  the  input  string  into  the  byte  array 
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);

            //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream 
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace His6.Base
{
    /// <summary>
    /// 数据加解密处理
    /// </summary>
    public static class DataCryptoHelper
    {
        #region DES/RijndaelManaged
        private static RijndaelManaged CryptoService = new RijndaelManaged();

        /// <summary>
        /// 取得机密密钥(不符合长度的用空格填充)
        /// </summary>
        /// <param name="key">密钥串</param>
        /// <returns>填充后的密钥</returns>
        private static byte[] GetLegalKey(string key)
        {
            byte[] byte_key = UnicodeEncoding.UTF8.GetBytes(key);
            CryptoService.GenerateKey();
            byte[] byte_temp = CryptoService.Key;
            int key_length = byte_temp.Length;

            for (int i = 0; i < key_length; i++)
            {
                if (i >= byte_key.Length)
                {
                    byte_temp[i] = 32;
                }
                else
                {
                    byte_temp[i] = byte_key[i];
                }
            }

            return byte_temp;
        }

        /// <summary>
        /// 取得初始化向量(不符合长度的用空格填充)
        /// </summary>
        /// <param name="key">密钥串</param>
        /// <returns>密钥向量</returns>
        private static byte[] GetLegalIV(string key)
        {
            byte[] byte_key = UnicodeEncoding.UTF8.GetBytes(key);
            CryptoService.GenerateIV();
            byte[] byte_temp = CryptoService.IV;
            int key_length = byte_temp.Length;

            for (int i = 0; i < key_length; i++)
            {
                if (i >= byte_key.Length)
                {
                    byte_temp[i] = 32;
                }
                else
                {
                    byte_temp[i] = byte_key[i];
                }
            }

            return byte_temp;
        }

        /// <summary>
        /// 加密过程
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="key">加密串</param>
        /// <returns>加密后的数据</returns>
        public static string Encrypting(string source, string key)
        {
            byte[] bytIn = UnicodeEncoding.Default.GetBytes(source);
            byte[] bytOut = Encrypting(bytIn, key);
            return Convert.ToBase64String(bytOut, 0, bytOut.Length);
        }

        /// <summary>
        /// 加密过程
        /// </summary>
        /// <param name="bytIn">待加密的字节数组</param>
        /// <param name="key">加密串</param>
        /// <returns>加密后的字节数组</returns>
        public static byte[] Encrypting(byte[] bytIn, string key)
        {
            if (bytIn == null || bytIn.Length == 0)
            {
                return new byte[0];
            }
            // create a MemoryStream so that the process can be done without I/O files
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            // set the private key
            CryptoService.Key = GetLegalKey(key);
            CryptoService.IV = GetLegalIV(key);

            // create an Encryptor from the Provider Service instance
            ICryptoTransform encrypto = CryptoService.CreateEncryptor();

            // create Crypto Stream that transforms a stream using the encryption
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

            // write out encrypted content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            // get the output
            byte[] bytOut = ms.ToArray();

            return bytOut;
        }

        /// <summary>
        /// 解密过程
        /// </summary>
        /// <param name="source">被加密的数据</param>
        /// <param name="key">解密串</param>
        /// <returns>解密后的数据</returns>
        public static string Decrypting(string source, string key)
        {
            byte[] bytIn = Convert.FromBase64String(source);
            byte[] bytOut = Decrypting(bytIn, key);
            return UnicodeEncoding.Default.GetString(bytOut);
        }

        /// <summary>
        /// 解密过程
        /// </summary>
        /// <param name="bytIn">待解密的字节数组</param>
        /// <param name="key">解密串</param>
        /// <returns>解密后的字节数组</returns>
        public static byte[] Decrypting(byte[] bytIn, string key)
        {
            if (bytIn == null || bytIn.Length == 0)
            {
                return new byte[0];
            }
            // create a MemoryStream with the input
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);

            // set the private key
            CryptoService.Key = GetLegalKey(key);
            CryptoService.IV = GetLegalIV(key);

            // create a Decryptor from the Provider Service instance
            ICryptoTransform encrypto = CryptoService.CreateDecryptor();

            // create Crypto Stream that transforms a stream using the decryption
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

            //System.IO.StreamReader sr = new System.IO.StreamReader(cs);

            using (MemoryStream source = new MemoryStream())
            {
                //从压缩流中读出所有数据
                byte[] bytes = new byte[4096];
                int n;
                while ((n = cs.Read(bytes, 0, bytes.Length)) != 0)
                {
                    source.Write(bytes, 0, n);
                }

                return source.ToArray();
            }
        }
        #endregion

        #region MD5

        /// <summary>
        /// MD5加密，16位，不可逆，
        /// 无间隔符号
        /// </summary>
        /// <param name="decryptStr">待加密字符串</param>
        /// <returns>返回散列串</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public static string MD5_16(string decryptStr)
        {
            return MD5_16(decryptStr, "");
        }

        /// <summary>
        /// MD5加密，16位，不可逆
        /// </summary>
        /// <param name="decryptStr">待加密字符串</param>
        /// <param name="splitStr">散列串间隔符</param>
        /// <returns>返回散列串</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public static string MD5_16(string decryptStr, string splitStr)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(UTF8Encoding.Default.GetBytes(decryptStr));
            string str = BitConverter.ToString(hash, 4, 8);
            if (splitStr != "-")
            {
                str = str.Replace("-", splitStr);
            }
            return str;
        }

        /// <summary>
        /// MD5加密，32位，不可逆，
        /// 无间隔符号
        /// </summary>
        /// <param name="decryptStr">待加密字符串</param>
        /// <returns>返回散列串</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public static string MD5_32(string decryptStr)
        {
            return MD5_32(decryptStr, "");
        }

        /// <summary>
        /// MD5加密，32位，不可逆
        /// </summary>
        /// <param name="decryptStr">待加密字符串</param>
        /// <param name="splitStr">散列串间隔符</param>
        /// <returns>返回散列串</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        public static string MD5_32(string decryptStr, string splitStr)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(UTF8Encoding.Default.GetBytes(decryptStr));
            string str = BitConverter.ToString(hash);
            if (splitStr != "-")
            {
                str = str.Replace("-", splitStr);
            }
            return str;
        }

        /// <summary>
        /// 对给定文件路径的文件加上标签
        /// </summary>
        /// <param name="path">要加密的文件的路径</param>
        /// <returns>标签的值</returns>
        public static bool AddMD5(string path)
        {
            bool IsNeed = true;

            if (CheckMD5(path))  //已进行MD5处理
            {
                IsNeed = false;
            }

            try
            {
                FileStream fsread = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] md5File = new byte[fsread.Length];
                fsread.Read(md5File, 0, (int)fsread.Length);   // 将文件流读取到Buffer中
                fsread.Close();

                if (IsNeed)
                {
                    // 对Buffer中的字节内容算MD5
                    string result = GetMD5(md5File, 0, md5File.Length);

                    // 将字符串转换成字节数组以便写人到文件中
                    byte[] md5 = Encoding.ASCII.GetBytes(result);
                    FileStream fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

                    // 将文件，MD5值 重新写入到文件中
                    fsWrite.Write(md5File, 0, md5File.Length);
                    fsWrite.Write(md5, 0, md5.Length);
                    fsWrite.Close();
                }
                else
                {
                    FileStream fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    fsWrite.Write(md5File, 0, md5File.Length);
                    fsWrite.Close();
                }                
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }            
            catch(ApplicationException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 对给定路径的文件进行验证
        /// </summary>
        /// <param name="path">待验证的文件路径</param>
        /// <returns>是否加了标签或是否标签值与内容值一致</returns>
        public static bool CheckMD5(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open,
                                                        FileAccess.Read, FileShare.Read);

                // 读入文件
                byte[] md5File = new byte[get_file.Length];
                get_file.Read(md5File, 0, (int)get_file.Length);
                get_file.Close();

                // 对文件除最后32位以外的字节计算MD5，这个32是因为标签位为32位。
                string result = GetMD5(md5File, 0, md5File.Length - 32);

                //读取文件最后32位，其中保存的就是MD5值
                string md5 = Encoding.ASCII.GetString(md5File, md5File.Length - 32, 32);
                return result == md5;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (ApplicationException)
            {
                return false;
            }
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="md5File">MD5签名文件字符数组</param>
        /// <returns>计算结果</returns>
        public static string GetMD5(byte[] md5File)
        {
            if (md5File == null || md5File.Length == 0)
            {
                return null;
            }
            return GetMD5(md5File, 0, md5File.Length);
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="md5File">MD5签名文件字符数组</param>
        /// <param name="index">计算起始位置</param>
        /// <param name="count">计算终止位置</param>
        /// <returns>计算结果</returns>
        public static string GetMD5(byte[] md5File, int index, int count)
        {
            MD5CryptoServiceProvider md5Service = new MD5CryptoServiceProvider();
            byte[] hash_byte = md5Service.ComputeHash(md5File, index, count);
            string result = BitConverter.ToString(hash_byte);

            result = result.Replace("-", "");
            return result;
        }

        public static string MD5EncryptString(this string str)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            str = s.Aggregate("", (current, t) => current + t.ToString("X2")).ToLower();
            return str;
        }


        #endregion
    }

}

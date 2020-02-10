using System;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace His6.Base
{
    /// <summary>
    /// 字符串对象扩展方法
    /// </summary>
    public static class StringHelper
    {
        #region 数据类型、格式等判别

        /// <summary>
        /// 判断字符串是否为null或空
        /// </summary>
        /// <param name="str">待判断字符串</param>
        /// <returns>如果字符串为null或空，返回true，否则为false</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断字符串是否为null或空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 是否数字型，含"."
        /// </summary>
        /// <param name="str">待判定字符串</param>
        /// <returns>是否数值返回true，否则返回false</returns>
        public static bool IsNumber(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return Regex.IsMatch(str, @"^[+-]?\d+(\.\d+)?$");
        }

        /// <summary>
        /// 是否整型，含"+-"符号
        /// </summary>
        /// <param name="str">待判定字符串</param>
        /// <returns>是整数返回true，否则返回false</returns>
        public static bool IsInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return Regex.IsMatch(str, @"^[+-]?(0|[1-9][0-9]*)$");
        }


        #endregion

        #region 相关转换处理

        /// <summary>
        /// 将单词串转换为Camel命名法，即首字符小写，其他单词首字符大写
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="separator">存在的单词分隔符</param>
        /// <param name="lower">是否需要对单词的其他字符作小写处理</param>
        /// <returns>符合Camel命名规则的单词串</returns>
        public static string ToCamel(this string str, string separator, bool lower)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            string result = "";
            if (separator.IsNullOrEmpty())
            {
                result = str[0].ToString().ToLower();
                if (lower)
                {
                    result += str.Substring(1).ToLower();
                }
                else
                {
                    result += str.Substring(1);
                }

            }
            else
            {
                string[] words = str.Split(new string[] { separator },
                                                StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words.Length == 0)
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        result += words[i][0].ToString().ToLower();
                    }
                    else
                    {
                        result += words[i][0].ToString().ToUpper();
                    }

                    if (lower)
                    {
                        result += words[i].Substring(1).ToLower();
                    }
                    else
                    {
                        result += words[i].Substring(1);
                    }
                }

            }

            return result;
        }

        /// <summary>
        /// 将单词串转换为Camel命名法，即首字符小写，其他单词首字符大写,
        /// 默认单词的其他部分不作小写转换
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="separator">存在的单词分隔符</param>
        /// <returns>符合Camel命名规则的单词串</returns>
        public static string ToCamel(this string str, string separator)
        {
            return ToCamel(str, separator, false);
        }

        /// <summary>
        /// 将单词串转换为Camel命名法，即首字符小写，其他单词首字符大写,
        /// 默认无单词分隔符
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="lower">是否需要对单词的其他字符作小写处理</param>
        /// <returns>符合Camel命名规则的单词串</returns>
        public static string ToCamel(this string str, bool lower)
        {
            return ToCamel(str, "", lower);
        }

        /// <summary>
        /// 将单词串转换为Pascal命名法，即每个单词首字符大写
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="separator">存在的单词分隔符</param>
        /// <param name="lower">是否需要对单词的其他字符作小写处理</param>
        /// <returns>符合Pascal命名规则的单词串</returns>
        public static string ToPascal(this string str, string separator, bool lower)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            string result = "";
            if (separator.IsNullOrEmpty())
            {
                result = str[0].ToString().ToUpper();
                if (lower)
                {
                    result += str.Substring(1).ToLower();
                }
                else
                {
                    result += str.Substring(1);
                }

            }
            else
            {
                string[] words = str.Split(new string[] { separator },
                                                StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (words.Length == 0)
                    {
                        continue;
                    }

                    result += words[i][0].ToString().ToUpper();

                    if (lower)
                    {
                        result += words[i].Substring(1).ToLower();
                    }
                    else
                    {
                        result += words[i].Substring(1);
                    }
                }

            }

            return result;
        }

        /// <summary>
        /// 将单词串转换为Pascal命名法，即每个单词首字符大写,
        /// 默认单词的其他部分不作小写转换
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="separator">存在的单词分隔符</param>
        /// <returns>符合Pascal命名规则的单词串</returns>
        public static string ToPascal(this string str, string separator)
        {
            return ToPascal(str, separator, false);
        }

        /// <summary>
        /// 将单词串转换为Pascal命名法，即每个单词首字符大写,
        /// 默认无单词分隔符
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="lower">是否需要对单词的其他字符作小写处理</param>
        /// <returns>符合Pascal命名规则的单词串</returns>
        public static string ToPascal(this string str, bool lower)
        {
            return ToPascal(str, "", lower);
        }

        /// <summary>
        ///  Pascal转成大写间隔
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <returns></returns>
        public static string PascalToUpper(this string str)
        {
            return PascalToUpper(str, "_");
        }

        /// <summary>
        ///  Pascal转成大写间隔
        /// </summary>
        /// <param name="str">待转换的单词串</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string PascalToUpper(this string str, string separator)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (i > 0 && str[i] >= 'A' && str[i] <= 'Z')
                {
                    result.Append(separator + str[i]);
                }
                else
                {
                    result.Append(str[i].ToString().ToUpper());
                }
            }

            return result.ToString();
        }


        /// <summary>
        ///  字符串反转
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string Reversal(this string str)
        {
            string result = "";
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                char[] arr = str.ToCharArray();
                Array.Reverse(arr);
                result = new string(arr);

                return result;
            }
        }

        #endregion

        #region JSON序列化与反序列化

        /// <summary>
        ///  对象序列化为字符串
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string SerializeObject<T>(T t)
        {
            JsonSerializerSettings js = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,//忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                DateFormatString = "yyyy-MM-dd HH:mm:ss",//日期格式化，默认的格式也不好看
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()//json中属性开头字母小写的驼峰命名
            };

            return JsonConvert.SerializeObject(t, js);
        }


        /// <summary>
        ///  字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="data">字符串数据</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }


        #endregion
        /*
        #region 替换与删除
        /// <summary>
        ///  将源字符串中()内的字符替换为新内容
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="replaceStr">替换的内容</param>
        /// <returns>替换后字符串</returns>
        public static string ReplaceInBracket(this string str, string replaceStr)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return ReplaceInRange(str, replaceStr, '(', ')');
        }

        /// <summary>
        ///  将源字符串中某段字符替换为新内容
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="replaceStr">替换的内容</param>
        /// <param name="startCharacter">起始字符</param>
        /// <param name="endCharacter">结束字符</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceInRange(this string str, string replaceStr, char startCharacter, char endCharacter)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(replaceStr))
            {
                return null;
            }

            // 应该可以用正则表达式，不是很熟悉，先列遍处理了，有谁可以改一下
            int sIndex = -1;
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                char curChar = str[i];
                if (curChar == startCharacter)
                {
                    sIndex = i;
                    continue;
                }
                else if (curChar == endCharacter && sIndex >= 0)
                {
                    result += string.Format("{0}{1}{2}", startCharacter, replaceStr, endCharacter);
                    sIndex = -1;
                    continue;
                }

                if (sIndex == -1)
                {
                    result += curChar.ToString();
                }
            }

            if (sIndex >= 0)
            {
                result += str.Substring(sIndex + 1);
            }

            return result;
        }

        /// <summary>
        /// 将字符串中特定的字符串替换为另外的字符串，允许指定是否忽略大小写
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="oldValue">待替换字符串</param>
        /// <param name="newValue">要替换的新字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>替换后新字符串</returns>
        public static string Replace(this string str, string oldValue, string newValue, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            if (ignoreCase)
            {
                return Regex.Replace(str, oldValue, newValue, RegexOptions.IgnoreCase);
            }
            else
            {
                return str.Replace(oldValue, newValue);
            }
        }

        /// <summary>
        /// 去除最后一个","后的字符
        /// </summary>
        /// <param name="str">带","的字符串</param>
        /// <returns>去除后的字符串</returns>
        public static string WipeLastSeparator(this string str)
        {
            return WipeLastSeparator(str, ',');
        }

        /// <summary>
        /// 去除最后一个某字符后的字符
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="wipeCharacter">要去除的字符</param>
        /// <returns>去除后的字符串</returns>
        public static string WipeLastSeparator(this string str, char wipeCharacter)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            int last_pos = str.LastIndexOf(wipeCharacter);
            if (last_pos > 0)
            {
                str = str.Substring(0, last_pos);
            }
            return str;
        }

        /// <summary>
        /// 清除字符串中所有的空格
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <returns>清除空格后的字符串</returns>
        public static string ClearSpace(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return str.Replace(" ", "");
        }

        /// <summary>
        /// 格式化串处理
        /// </summary>
        /// <param name="format">格式化串</param>
        /// <param name="args">参数</param>
        /// <returns>填充后的字符串</returns>
        /// <example>
        /// 使用：
        /// string s = "{0}-{1}"
        /// s.FormatWith("010", 88888888)
        /// </example>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        #endregion
        */

        #region 按字节方式操作字符串

        /// <summary>
        /// 按字节数左边填充
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="totalWidth">总长度</param>
        /// <param name="paddingCharacter">待填充字符</param>
        /// <returns>填充后字符串</returns>
        public static string PadLeftB(this string str, int totalWidth, char paddingCharacter)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            int paddingLength = totalWidth - str.LengthB();
            if (paddingLength >= 0)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(paddingCharacter.ToString());
                if (bytes[1] == 0)
                {
                    return string.Empty.PadLeft(paddingLength, paddingCharacter) + str;
                }
                else
                {
                    int l = paddingLength / 2;
                    return string.Empty.PadLeft(l, paddingCharacter) + str;
                }
            }
            else
            {
                return str.SubstringB(totalWidth);
            }
        }

        /// <summary>
        /// 按字节数左边填充
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="totalWidth">总长度</param>
        /// <returns>填充后字符串</returns>
        public static string PadLeftB(this string str, int totalWidth)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.PadLeftB(totalWidth, ' ');
        }

        /// <summary>
        /// 按字节数右边填充
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="totalWidth">总长度</param>
        /// <param name="paddingCharacter">待填充字符</param>
        /// <returns>填充后字符串</returns>
        public static string PadRightB(this string str, int totalWidth, char paddingCharacter)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            int paddingLength = totalWidth - str.LengthB();
            if (paddingLength >= 0)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(paddingCharacter.ToString());
                if (bytes[1] == 0)
                {
                    return str + string.Empty.PadLeft(paddingLength, paddingCharacter);
                }
                else
                {
                    int l = paddingLength / 2;
                    return str + string.Empty.PadLeft(l, paddingCharacter);
                }
            }
            else
            {
                return str.SubstringB(totalWidth);
            }
        }

        /// <summary>
        /// 按字节数右边填充
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="totalWidth">总长度</param>
        /// <returns>填充后字符串</returns>
        public static string PadRightB(this string str, int totalWidth)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.PadRightB(totalWidth, ' ');
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="length">截取长度</param>
        /// <returns>截取后字符串</returns>
        public static string SubstringB(this string str, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            byte[] bytes = Encoding.Unicode.GetBytes(str);

            // 找到起始位置
            int i = 0;
            int sumlen = 0;
            for (; i < bytes.GetLength(0); i++)
            {
                if (sumlen >= startIndex)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    sumlen++;　　　//　在UCS2第一个字节时n加1
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        sumlen++;
                    }
                }
            }


            // 找到截取的终止位置
            int j;
            int n = 0;　//　表示当前的字节数
            for (j = i; j < bytes.GetLength(0) && n < length; j++)
            {
                //　偶数位置，如0、2、4等，为UCS2编码中两个字节的第一个字节
                if (j % 2 == 0)
                {
                    n++;　　　//　在UCS2第一个字节时n加1
                }
                else
                {
                    //　当UCS2编码的第二个字节大于0时，该UCS2字符为汉字，一个汉字算两个字节
                    if (bytes[j] > 0)
                    {
                        n++;
                    }
                }
            }
            //　如果i为奇数时，处理成偶数
            if (j % 2 == 1)
            {
                //　该UCS2字符是汉字时，去掉这个截一半的汉字
                if (bytes[j] > 0)
                {
                    j = j - 1;
                }
                //　该UCS2字符是字母或数字，则保留该字符
                else
                {
                    j = j + 1;
                }
            }

            if (j >= bytes.Length)
            {
                j = bytes.Length;
            }

            // 低位就加一，这样保证不会有半个汉字，d但会导致起始字节不正确
            if (i % 2 == 1)
            {
                i++;
            }

            return Encoding.Unicode.GetString(bytes, i, j - i);
        }

        /// <summary>
        /// 截取字符串(按字节)
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <param name="length">截取长度</param>
        /// <returns>截取后字符串</returns>
        public static string SubstringB(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return SubstringB(str, 0, length);
        }

        /// <summary>
        /// 获取字符串长度(按字节)
        /// </summary>
        /// <param name="str">待处理字符串</param>
        /// <returns>字节长度</returns>
        public static int LengthB(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            byte[] bytes = Encoding.Unicode.GetBytes(str);

            // 找到起始位置
            int i = 0;
            int sumlen = 0;
            for (; i < bytes.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    sumlen++;　　　//　在UCS2第一个字节时n加1
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        sumlen++;
                    }
                }
            }
            return sumlen;
        }

        #endregion

        #region 获取中文对应输入码  --  ToDo

        /// <summary>
        /// 获取字符串输入码
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <returns>字符串的输入码</returns>
        public static string InputCode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            //  ToDo: 通过数据库查询获取  ??  是否需要区分输入码类型？

            return "";
        }

        /// <summary>
        /// 获取字符串输入码
        /// </summary>
        /// <param name="str">待转换字符串</param>
        /// <param name="length">截取的长度</param>
        /// <returns>字符串的输入码</returns>
        public static string InputCode(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.InputCode().Substring(0, length);
        }

        #endregion


        /*
        #region string 扩展


        /// <summary>
        /// Split扩展
        /// </summary>
        /// <param name="s"></param>
        /// <param name="splitStr"></param>
        /// <returns></returns>
        public static IEnumerable<string> Split(this string s, string splitStr)
        {
            return s.Split(new[] { splitStr }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Split扩展, 变成Int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEnumerable<int> SplitToInt(this string s, string separator = ",")
        {
            var itemList = new List<int>();
            if (String.IsNullOrEmpty(s))
            {
                return itemList;
            }
            var itemIds = s.Split(separator);
            itemList.AddRange(itemIds.Select(item => Convert.ToInt32(item)));
            return itemList;
        }

        /// <summary>
        /// 去除组合字符串中重复字符串
        /// </summary>
        /// <param name="strSource">由，分割组成的字符串</param>
        /// <param name="strTarget">由，组成的不含重复字符串的组合字符串</param>
        /// <returns></returns>
        /// <example>
        /// "1,3,2,4,7,6".RemoveRepeatStr("1,2,3") = "4,7,6";
        /// </example>
        public static string RemoveRepeatStr(this string strSource, string strTarget)
        {
            if (strSource.Contains(",") == false) return strSource;
            var al = new ArrayList();
            var strArray = strSource.Split(',');
            var sbTarget = new StringBuilder(strTarget);
            if (strArray.Length > 0)
            {
                var tmp = strArray.Where(t => !String.IsNullOrEmpty(t)).Where(t => !al.Contains(t));
                foreach (var t in tmp)
                {
                    al.Add(t);//不存在则添加进ArrayList
                    sbTarget.Append(",").Append(t);
                }
            }
            //if (sbTarget.Length > 0)
            //{
            //    sbTarget.Remove(0, 1);
            //}
            return sbTarget.ToString();
        }

        /// <summary>
        /// string 转为 byteArray
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string s, Encoding encoding)
        {
            return s.IsNullOrEmpty() ? new byte[0] : encoding.GetBytes(s);
        }

        /// <summary>
        /// 获取枚举类子项描述信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <example>
        /// "AddNew".GetDescription EditFormMode () = "新增";
        /// </example>
        public static string GetDescription<T>(this string name)
        {
            T type;
            try
            {
                type = (T)Enum.Parse(typeof(T), name);
            }
            catch (Exception)
            {
                return String.Empty;
            }

            return GenericUtil.GetDescription(type);
        }


        /// <summary>
        /// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
        /// as VB's "Like" Operator.
        /// </summary>
        /// <param name="s">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public static bool IsLike(this string s, string wildcardPattern)
        {
            if (s == null || String.IsNullOrEmpty(wildcardPattern)) return false;
            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            bool result;
            try
            {
                result = Regex.IsMatch(s, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid pattern: {0}".FormatWith(wildcardPattern), ex);
            }
            return result;
        }

        /// <summary>
        /// 转成Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <example>
        /// "AddNew".ToEnum EditFormMode () = EditFormMode.AddNew;
        /// </example>
        public static T ToEnum<T>(this string str) where T : struct
        {
            return (T)Enum.Parse(typeof(T), str);
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static int GetByteCount(this string s, Encoding encoding = default (Encoding))
        {
            encoding = encoding ?? Encoding.Default;
            return encoding.GetByteCount(s);
        }

        private static string SubStrLenth(this string str, int startIndex, int length)
        {
            var strlen = str.GetByteCount();

            if (startIndex + 1 > strlen)
            {
                return string.Empty;
            }

            var j = 0; //记录遍历的字节数
            var l = 0; //记录每次截取开始，遍历到开始的字节位，才开始记字节数
            var b = false; //当每次截取时，遍历到开始截取的位置才为true
            var restr = string.Empty;

            foreach (var c in str)
            {
                var strW = Convert.ToString(c).GetByteCount(); //字符宽度
                if ((l == length - 1) && (l + strW > length))
                {
                    break;
                }

                if (j >= startIndex)
                {
                    restr += c;
                    b = true;
                }
                j += strW;
                if (!b) continue;
                l += strW;
                if (((l + 1) > length))
                {
                    break;
                }
            }
            return restr;
        }

        #endregion string 扩展
        */
    }

}

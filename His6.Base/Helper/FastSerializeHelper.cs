using System.Collections.Generic;

namespace His6.Base
{
    /// <summary>
    /// 文 件 名：自定义快速序列化处理类
    /// 功能描述：适用于简单实体类列表，要求每个字段可转成字符串
    ///       格式： 列数据1 + 列数据2 + ... + 列数据n 
    ///     列数据： 列长度 + 列值
    ///       长度： < 255: 1位,  >=255: 255 + 2位长度
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>

    public static class FastSerializeHelper
    {
        /// <summary>
        ///   序列化
        /// </summary>
        /// <typeparam name="T">泛型实体，实现</typeparam>
        /// <param name="list">实体列表</param>
        /// <returns></returns>
        public static List<byte> Serialize<T>(List<T> list) where T : IFastSerialize
        {
            List<byte> listbyte = new List<byte>();
            foreach (T t in list)
            {
                for (int i = 0; i < t.FieldCount; i++)
                {
                    byte[] byt = System.Text.Encoding.Default.GetBytes(t.Serialize(i));
                    int len = byt.Length;
                    if ( len >= 255)
                    {
                        listbyte.Add((byte)(255));
                        listbyte.Add((byte)(len % 256));
                        listbyte.Add((byte)(len / 256));
                    }
                    else
                    {
                        listbyte.Add((byte)(len));
                    }

                    if (len > 0)
                    {
                        listbyte.AddRange(byt);
                    }
                }
            }
            return listbyte;
        }

        /// <summary>
        ///  反序列化
        /// </summary>
        /// <typeparam name="T">泛型实体，实现</typeparam>
        /// <param name="bytes">反序列化字节数据</param>
        /// <returns></returns>
        public static List<T> DeSerialize<T>(byte[] bytes) where T : IFastSerialize, new()
        {
            List<T> list = new List<T>();
            int index = 0;
            T t = new T();
            int fieldCount = t.FieldCount;
            int fidx = 0;

            while (index < bytes.Length)
            {
                //  获取字段值字节数
                int flen = bytes[index];
                index++;
                if (flen == 255)
                {
                    flen = bytes[index] + bytes[index + 1] * 256;
                    index += 2;
                }

                if (flen > 0)
                {
                    t.DeSerialize(fidx, System.Text.Encoding.Default.GetString(bytes, index, flen));
                    index += flen;
                }
                fidx++;
                if (fidx >= fieldCount)
                {
                    //  一行字段取完加入列表，加入下一行
                    list.Add(t);
                    t = new T();
                    fidx = 0;
                }
            }
            return list;
        }

    }
}

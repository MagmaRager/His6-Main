using System;
using System.Drawing;
using DevExpress.Utils.Svg;

namespace His6.Base
{
    public class BmpHelper
    {

        /// <summary>
        ///  获取资源图信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static Image GetBmp(string name)
        {
            return GetFile(EnvInfo.RunPath + "Image\\" + name);
        }

        /// <summary>
        ///  获取图标信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static Image GetIco(string name)
        {
            return GetFile(EnvInfo.RunPath + "Ico\\" + name);
        }

        public static SvgImage GetSvg(string name)
        {
            return GetSvgFile(EnvInfo.RunPath + "Ico\\" + name);
        }

        /// <summary>
        ///  从文件中获取资源图信息
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static Image GetFile(string filePathName)
        {
            try
            {
                if (string.IsNullOrEmpty(filePathName))
                {
                    return null;
                }

                Image img = null;
                if (System.IO.File.Exists(filePathName))
                {
                    img = Image.FromFile(filePathName);
                }

                return img;
            }
            catch
            {
                return null;
            }
        }

        public static SvgImage GetSvgFile(string filePathName)
        {
            try
            {
                if (string.IsNullOrEmpty(filePathName))
                {
                    return null;
                }

                SvgImage img = null;
                if (System.IO.File.Exists(filePathName))
                {
                    img = SvgImage.FromFile(filePathName);
                }

                return img;
            }
            catch
            {
                return null;
            }
        }
    }
}

using System;
using System.Drawing;

namespace His6.Resource
{
    public class ResourceHelper
    {

        /// <summary>
        ///  获取资源图信息  其中，name是文件名
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static Image GetFromResource(string name)
        {
            return (Image)(His6.Resource.Resource.ResourceManager.GetObject(name));
        }
        
    }
}

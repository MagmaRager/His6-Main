namespace His6.Base
{
    /// <summary>
    /// 文 件 名：快速序列化的接口
    /// 功能描述：用于实现可快速序列化的实体对象
    /// 创建标识：han
    ///
    /// 修改标识：
    /// 修改描述：
    /// </summary>
    public interface IFastSerialize
    {
        /// <summary>
        ///  实体的序列化字段数量
        /// </summary>
        int FieldCount { get; }

        /// <summary>
        ///  字段序列化实现
        /// </summary>
        /// <param name="index">字段序号</param>
        /// <returns></returns>
        string Serialize(int index);

        /// <summary>
        ///  字段反序列化赋值
        /// </summary>
        /// <param name="index">字段序号</param>
        /// <param name="value">数据值</param>
        void DeSerialize(int index, string value);

    }
}

using System;

namespace Yas.Core.Serialization
{
    /// <summary>
    /// JSON序列化器接口
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="useCameCase">使用驼峰式命名</param>
        /// <param name="indented">使用缩进</param>
        /// <returns>序列化后的字符串</returns>
        string Serialize(object obj, bool useCameCase = true, bool useIndent = false);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <param name="camelCase"></param>
        /// <returns></returns>
        T Deserialize<T>(string jsonString, bool camelCase = true);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="jsonString"></param>
        /// <param name="camelCase"></param>
        /// <returns></returns>
        object Deserialize(Type type, string jsonString, bool camelCase = true);
    }
}

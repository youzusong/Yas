namespace Yas.Core.Excepting
{
    /// <summary>
    /// 拥有错误详情接口
    /// </summary>
    public interface IHasErrorDetails
    {
        /// <summary>
        /// 错误详情
        /// </summary>
        string ErrorDetails { get; }
    }
}

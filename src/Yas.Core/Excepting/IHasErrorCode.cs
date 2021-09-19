namespace Yas.Core.Excepting
{
    /// <summary>
    /// 拥有错误代号接口
    /// </summary>
    public interface IHasErrorCode
    {
        /// <summary>
        /// 错误代号
        /// </summary>
        string ErrorCode { get; set; }
    }
}

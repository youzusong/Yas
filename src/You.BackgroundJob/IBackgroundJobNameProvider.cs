namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务名称提供者接口
    /// </summary>
    public interface IBackgroundJobNameProvider
    {
        /// <summary>
        /// 后台任务名称
        /// </summary>
        string Name { get; }
    }
}

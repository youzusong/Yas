namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务接口
    /// </summary>
    /// <typeparam name="TArgs">任务参数类型</typeparam>
    public interface IBackgroundJob<in TArgs>
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="args">任务参数</param>
        void Execute(TArgs args);
    }
}

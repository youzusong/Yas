namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务基类
    /// </summary>
    /// <typeparam name="TArgs">任务参数类型</typeparam>
    public abstract class BackgroundJobBase<TArgs> : IBackgroundJob<TArgs>
    {
        public BackgroundJobBase()
        { }

        public abstract void Execute(TArgs args);
    }
}

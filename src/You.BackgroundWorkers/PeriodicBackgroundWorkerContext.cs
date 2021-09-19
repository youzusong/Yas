using System;

namespace You.BackgroundWorkers
{
    /// <summary>
    /// 周期性后台工作者之上下文
    /// </summary>
    public class PeriodicBackgroundWorkerContext
    {
        public IServiceProvider ServiceProvider { get; }

        public PeriodicBackgroundWorkerContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}

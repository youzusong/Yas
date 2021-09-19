using System.Linq;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务工具类
    /// </summary>
    public static class BackgrounJobUtility
    {
        public static string GetJobName<TArgs>()
        {
            var argsType = typeof(TArgs);
            var jobName = argsType
                           .GetCustomAttributes(true)
                           .OfType<IBackgroundJobNameProvider>()
                           .FirstOrDefault()
                           ?.Name
                       ?? argsType.FullName;

            return jobName;
        }
    }
}


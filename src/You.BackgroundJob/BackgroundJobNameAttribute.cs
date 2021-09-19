using System;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务名称特性
    /// </summary>
    public class BackgroundJobNameAttribute : Attribute, IBackgroundJobNameProvider
    {
        public string Name { get; }

        public BackgroundJobNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}

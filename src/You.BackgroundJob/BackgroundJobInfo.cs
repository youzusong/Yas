using System;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务信息
    /// </summary>
    public class BackgroundJobInfo
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 任务参数（已序列化）
        /// </summary>
        public string Args { get; set; }

        /// <summary>
        /// 尝试次数
        /// </summary>
        public short TryCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 下次尝试时间
        /// </summary>
        public DateTime NextTryTime { get; set; }

        /// <summary>
        /// 上次尝试时间
        /// </summary>
        public DateTime? LastTryTime { get; set; }

        /// <summary>
        /// 是否已放弃
        /// </summary>
        public bool IsAbandoned { get; set; }

        /// <summary>
        /// 任务优先级
        /// </summary>
        public BackgroundJobPriority Priority { get; set; }
    }
}

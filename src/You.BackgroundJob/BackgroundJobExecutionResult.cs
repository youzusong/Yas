namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务执行结果
    /// </summary>
    public class BackgroundJobExecutionResult
    {
        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 错误讯息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}

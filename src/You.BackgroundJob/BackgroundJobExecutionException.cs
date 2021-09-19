using System;

namespace You.BackgroundJob
{
    public class BackgroundJobExecutionException : YasException
    {
        public Type JobType { get; set; }

        public object JobArgs { get; set; }

        public BackgroundJobExecutionException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

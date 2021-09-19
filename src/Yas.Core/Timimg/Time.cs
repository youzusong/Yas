using Microsoft.Extensions.Options;
using System;
using Yas.Core.DependencyInjection;

namespace Yas.Core.Timimg
{
    public class Time : ITime, ITransientDependency
    {
        protected TimeOptions Options { get; }

        public Time(IOptions<TimeOptions> options)
        {
            Options = options.Value;
        }

        public virtual DateTime Now => Options.Kind == DateTimeKind.Utc ? DateTime.UtcNow : DateTime.Now;

        public virtual DateTimeKind Kind => Options.Kind;

        public DateTime Normalize(DateTime dateTime)
        {
            if (Kind == DateTimeKind.Unspecified || Kind == dateTime.Kind)
                return dateTime;

            if (Kind == DateTimeKind.Local && dateTime.Kind == DateTimeKind.Utc)
                return dateTime.ToLocalTime();

            if (Kind == DateTimeKind.Utc && dateTime.Kind == DateTimeKind.Local)
                return dateTime.ToUniversalTime();

            return DateTime.SpecifyKind(dateTime, Kind);
        }
    }
}

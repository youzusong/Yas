using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yas.Core.DependencyInjection;
using Yas.Core.Timimg;

namespace You.BackgroundJob
{
    public class InMemoryBackgroundJobStore : IBackgroundJobStore, ISingletonDependency
    {
        private readonly ConcurrentDictionary<Guid, BackgroundJobInfo> _jobs;

        protected ITime Time { get; }

        public InMemoryBackgroundJobStore(ITime time)
        {
            _jobs = new ConcurrentDictionary<Guid, BackgroundJobInfo>();
            Time = time;
        }

        public Task<BackgroundJobInfo> FindAsync(Guid jobId)
        {
            return Task.FromResult(_jobs.GetOrDefault(jobId));
        }

        public Task InsertAsync(BackgroundJobInfo jobInfo)
        {
            _jobs[jobInfo.Id] = jobInfo;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(BackgroundJobInfo jobInfo)
        {
            if (jobInfo.IsAbandoned)
            {
                return DeleteAsync(jobInfo.Id);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid jobId)
        {
            _jobs.TryRemove(jobId, out _);
            return Task.CompletedTask;
        }
    }
}

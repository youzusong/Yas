using System;
using System.Threading.Tasks;
using Yas.Core.DependencyInjection;
using Yas.Core.Serialization;
using Yas.Core.Timimg;
using Yas.Core.Uid;

namespace You.BackgroundJob
{
    [Dependency(ReplaceServices = true)]
    public class DefaultBackgroundJobManager : IBackgroundJobManager, ITransientDependency
    {
        protected readonly ITime Time;
        protected readonly IGuidGenerator GuidGenerator;
        protected readonly IJsonSerializer JsonSerializer;
        protected readonly IBackgroundJobStore Store;

        public DefaultBackgroundJobManager(
            ITime time,
            IGuidGenerator guidGenerator,
            IJsonSerializer jsonSerializer,
            IBackgroundJobStore store)
        {
            Time = time;
            GuidGenerator = guidGenerator;
            JsonSerializer = jsonSerializer;
            Store = store;
        }

        protected virtual async Task<Guid> EnqueueAsync(string name, object args, BackgroundJobPriority priority = BackgroundJobPriority.Normal, TimeSpan? delayTime = null)
        {
            var jobInfo = new BackgroundJobInfo
            {
                Id = GuidGenerator.Create(),
                Name = name,
                Args = JsonSerializer.Serialize(args),
                Priority = priority,
                CreationTime = Time.Now,
                NextTryTime = Time.Now
            };

            if (delayTime.HasValue)
                jobInfo.NextTryTime = Time.Now.Add(delayTime.Value);

            await Store.InsertAsync(jobInfo);

            return jobInfo.Id;
        }

        public async Task<string> EnqueueAsync<TArgs>(TArgs args, BackgroundJobPriority priority = BackgroundJobPriority.Normal, TimeSpan? delayTime = null)
        {
            var jobName = BackgrounJobUtility.GetJobName<TArgs>();
            var jobId = await EnqueueAsync(jobName, args, priority, delayTime);
            return jobId.ToString();
        }
    }
}

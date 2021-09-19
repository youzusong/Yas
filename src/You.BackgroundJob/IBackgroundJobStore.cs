using System;
using System.Threading.Tasks;

namespace You.BackgroundJob
{
    /// <summary>
    /// 后台任务仓库接口
    /// </summary>
    public interface IBackgroundJobStore
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<BackgroundJobInfo> FindAsync(Guid jobId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        Task InsertAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        Task UpdateAsync(BackgroundJobInfo jobInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid jobId);
    }
}

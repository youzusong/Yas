using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace You.BackgroundWorkers
{
    /// <summary>
    /// 周期性后台工作者基类
    /// </summary>
    public abstract class PeriodicBackgroundWorkerBase : BackgroundWorkerBase
    {

        protected abstract void DoWork(PeriodicBackgroundWorkerContext workerContext);
    }
}

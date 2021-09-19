using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yas.Core.DependencyInjection;

namespace You.BackgroundWorkers
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultBackgroundWorkerManager : IBackgroundWorkerManager, ISingletonDependency, IDisposable
    {
        private bool _isDisposed;
        private readonly List<IBackgroundWorker> _workers;

        protected bool IsRunning { get; private set; }

        public DefaultBackgroundWorkerManager()
        {
            _workers = new List<IBackgroundWorker>();
        }

        public void Add(IBackgroundWorker worker)
        {
            _workers.Add(worker);

            if (IsRunning)
            {
                // Nito.AsyncEx
                //AsyncContext.Run(() => worker.StartAsync());
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            IsRunning = true;

            foreach (var worker in _workers)
            {
                await worker.StartAsync(cancellationToken);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            IsRunning = false;

            foreach (var worker in _workers)
            {
                await worker.StopAsync(cancellationToken);
            }
        }

        public virtual void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
        }
    }
}

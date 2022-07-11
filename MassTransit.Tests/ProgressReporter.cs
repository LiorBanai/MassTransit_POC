using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Tests
{
    public class ProgressReporter<T> : Progress<T>, IProgress<T>
    {
        private DateTime _lastUpdate = DateTime.MinValue;
        private int Interval { get; }
        private Task LastRefresh { get; set; }
        private T LastValue { get; set; }
        private CancellationTokenSource tokenSource;

        public ProgressReporter(Action<T> action) : base(action)
        {
            Interval = 500;
            tokenSource = new CancellationTokenSource();

        }

        public ProgressReporter(Action<T> action, int interval) : this(action)
        {
            Interval = interval;
        }
        public async void Report(T value)
        {
            if (DateTime.Now.Subtract(_lastUpdate).TotalMilliseconds >= Interval)
            {
                tokenSource?.Cancel(false);
                base.OnReport(value);
                _lastUpdate = DateTime.Now;
            }
            else
            {
                LastValue = value;
                tokenSource.Cancel(false);
                tokenSource = new CancellationTokenSource();
                await RefreshData(tokenSource.Token);
            }
        }
        async Task RefreshData(CancellationToken token)
        {
            await Task.Delay(Interval);
            if (token.IsCancellationRequested)
            {
                return;
            }
            base.OnReport(LastValue);

        }
    }
}

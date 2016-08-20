using System;
using Timer = System.Timers.Timer;

namespace DelegatesAndEvents
{
    public class Worker : IWorker
    {
        private Timer Timer { get; set; }
        private int HourCount { get; set; }
        private bool WorkIsCompleted { get; set; }
        private bool Disposed { get; set; }

        #region Non-Interface Implementation

        public Worker()
        {
            WorkIsCompleted = false;
            Disposed = false;
        }

        private void TimerHandler(WorkType workType, int hours)
        {
            OnWorkPerformed(workType, ++HourCount);
            if (HourCount != hours)
            {
                return;
            }
            Timer.Stop();
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(WorkType workType, int hours)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(workType, hours));
        }

        protected virtual void OnWorkCompleted()
        {
            WorkIsCompleted = true;
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }
            if (disposing && Timer != null)
            {
                Timer.Close();
                Timer.Dispose();
                Timer = null;
            }
            Disposed = true;
        }

        #endregion

        #region Interface Implementation

        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void StartWork(WorkType workType, int hours)
        {
            HourCount = 0;
            Timer = new Timer(1000);
            Timer.Elapsed += (sender, e) => TimerHandler(workType, hours);
            Timer.Start();
        }

        public void StopWork()
        {
            Timer.Stop();
        }

        public bool IsWorkCompleted()
        {
            return WorkIsCompleted;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

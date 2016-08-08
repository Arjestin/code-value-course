using System;
using Timer = System.Timers.Timer;

namespace DelegatesAndEvents
{
    public class Worker : IWorker
    {
        public Worker()
        {
            WorkIsCompleted = false;
        }

        private Timer Timer { get; set; }
        private int HourCount { get; set; }
        private bool WorkIsCompleted { get; set; }
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        protected virtual void OnWorkPerformed(WorkType workType, int hours)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(workType, hours));
        }

        protected virtual void OnWorkCompleted()
        {
            WorkIsCompleted = true;
            WorkCompleted?.Invoke(this, EventArgs.Empty);
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
    }
}

using System;

namespace DelegatesAndEvents
{
    public interface IWorker
    {
        event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        event EventHandler WorkCompleted;
        void StartWork(WorkType workType, int hours);
        void StopWork();
        bool IsWorkCompleted();
    }
}

using System;

namespace DelegatesAndEvents
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public int Hours { get; }
        public WorkType WorkType { get; }

        public WorkPerformedEventArgs(WorkType workType, int hours)
        {
            WorkType = workType;
            Hours = hours;
        }
    }
}

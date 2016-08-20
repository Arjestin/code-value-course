using System;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    internal class Program
    {
        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"Working in {e.WorkType} for {e.Hours} hour(s).");
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine($"Work is completed!{Environment.NewLine}");
        }

        private static async Task WorkAsync(IWorker worker)
        {
            await Task.Run(() => worker.StartWork(WorkType.GenerateReports, 8));
            Console.WriteLine($"Press any key to stop.{Environment.NewLine}");
            Console.ReadKey();
            await Task.Run(() => worker.StopWork());
            if (!worker.IsWorkCompleted())
            {
                Console.WriteLine($"Work is stopped!{Environment.NewLine}");
            }
        }

        private static void Main()
        {
            Console.WriteLine($"Press any key to start.{Environment.NewLine}");
            Console.ReadKey();
            using (IWorker worker = new Worker())
            {
                worker.WorkPerformed += Worker_WorkPerformed;
                worker.WorkCompleted += Worker_WorkCompleted;
                WorkAsync(worker).Wait();
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

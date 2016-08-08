using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegatesAndEvents;

namespace TimerTest
{
    [TestClass]
    public class WorkerTest
    {
        public TestContext TestContext { get; set; }
        private static ManualResetEventSlim ResetEvent { get; set; }
        private static IWorker Worker { get; set; }
        private static WorkType WorkType { get; set; }
        private static int WorkHours { get; set; }
        private static int HourCount { get; set; }

        #region Test Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            ResetEvent = new ManualResetEventSlim();
            Worker = new Worker();
            Worker.WorkPerformed += Worker_WorkPerformed;
            Worker.WorkCompleted += Worker_WorkCompleted;
            HourCount = 0;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine($"Run Directory:\t{TestContext.TestRunDirectory}");
            TestContext.WriteLine($"Name:\t\t{TestContext.TestName}");
            TestContext.WriteLine($"Outcome:\t{TestContext.CurrentTestOutcome}");
        }

        #endregion

        #region Test Async Work

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            // Expected
            var expectedWorkType = WorkType;
            var expectedHourCount = ++HourCount;
            const bool expectedCompletionState = false;

            // Actual
            var actualWorkType = e.WorkType;
            var actualHourCount = e.Hours;
            var actualCompletionState = Worker.IsWorkCompleted();

            // Assert Work Type
            Debug.WriteLine($"Expected Work Type = {expectedWorkType}. Actual Work Type = {actualWorkType}.");
            Assert.AreEqual(expectedWorkType, actualWorkType, "Unexpected work type.");

            // Assert Hour Count
            Debug.WriteLine($"Expected Hour Count = {expectedHourCount}. Actual Hour Count = {actualHourCount}.");
            Assert.AreEqual(expectedHourCount, actualHourCount, "Unexpected hour count.");

            // Assert Completion State
            Debug.WriteLine($"Expected Completion State = {expectedCompletionState}. Actual Completion State = {actualCompletionState}.");
            Assert.AreEqual(expectedCompletionState, actualCompletionState, "Unexpected completion state.");
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            // Expected
            const bool expectedCompletionState = true;

            // Actual
            var actualCompletionState = Worker.IsWorkCompleted();

            // Assert Hour Count
            Debug.WriteLine($"Expected Hour Count = {WorkHours}. Actual Hour Count = {HourCount}.");
            Assert.AreEqual(WorkHours, HourCount, "Unexpected hour count.");

            // Assert Completion State
            Debug.WriteLine($"Expected Completion State = {expectedCompletionState}. Actual Completion State = {actualCompletionState}.");
            Assert.AreEqual(expectedCompletionState, actualCompletionState, "Unexpected completion state.");

            // Release Waiting Thread
            ResetEvent.Set();
        }

        [TestMethod, TestCategory("WorkPerformed"), TestCategory("WorkCompleted"), TestCategory("StartWork"), TestCategory("IsWorkCompleted")]
        public void DoWorkTest_WaitUntilCompleted()
        {
            // Arrange
            WorkType = WorkType.GenerateReports;
            WorkHours = 8;

            // Act
            Task.Run(() => Worker.StartWork(WorkType, WorkHours));

            // Block Current Thread
            ResetEvent.Wait();
        }

        [TestMethod, TestCategory("WorkPerformed"), TestCategory("StartWork"), TestCategory("StopWork"), TestCategory("IsWorkCompleted")]
        public void DoWorkTest_StopBeforeCompleted()
        {
            // Arrange
            WorkType = WorkType.Golf;
            WorkHours = 17;

            // Expected
            const int expectedHourCount = 5;
            const bool expectedCompletionState = false;

            // Act
            Task.Run(() => Worker.StartWork(WorkType, WorkHours));
            Thread.Sleep(expectedHourCount*1000);
            Task.Run(() => Worker.StopWork());

            // Actual
            var actualHourCount = ++HourCount;
            var actualCompletionState = Worker.IsWorkCompleted();

            // Assert Hour Count
            Debug.WriteLine($"Expected Hour Count = {expectedHourCount}. Actual Hour Count = {actualHourCount}.");
            Assert.AreEqual(expectedHourCount, actualHourCount, "Unexpected hour count.");

            // Assert Completion State
            Debug.WriteLine($"Expected Completion State = {expectedCompletionState}. Actual Completion State = {actualCompletionState}.");
            Assert.AreEqual(expectedCompletionState, actualCompletionState, "Unexpected completion state.");
        }

        #endregion
    }
}

using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;


namespace Test
{
    public class FinishedPercentTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void NodeNotFinished()
        {
            Task task = new();
            task.Finished = false;

            FinishedHandlerLeaf taskF = new(task);

            Assert.AreEqual(0.00, taskF.GetFinishedPercent());
        }

        [Test]
        public void NodeFinished()
        {
            Task task = new();
            task.Finished = true;

            FinishedHandlerLeaf taskF = new(task);

            Assert.AreEqual(1.00, taskF.GetFinishedPercent());
        }

        [Test]
        public void CompositeWithLeafChildren()
        {
            Task task1 = new();
            task1.Finished = false;

            Task task2 = new();
            task2.Finished = true;

            TaskSet taskSet = new();
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);

            FinishedHandlerComposite taskSetF = new(taskSet);

            Assert.AreEqual(0.50, taskSetF.GetFinishedPercent());
        }
        
        [Test]
        public void CompositeWithLeafAndCompositeChildren()
        {
            Task task1 = new();
            task1.Finished = false;

            Task task2 = new();
            task2.Finished = true;

            TaskSet taskSet1 = new();
            taskSet1.Tasks.Add(task1);
            taskSet1.Tasks.Add(task2);

            Task task3 = new();
            task3.Finished = false;

            Task task4 = new();
            task4.Finished = false;

            TaskSet taskSet2 = new();
            taskSet2.Tasks.Add(task3);
            taskSet2.Tasks.Add(task4);

            Lecture lecture1 = new();
            lecture1.Finished = true;
            lecture1.TaskSet = taskSet1;

            Lecture lecture2 = new();
            lecture2.Finished = false;
            lecture2.TaskSet = taskSet2;

            Course course = new();
            course.Lectures.Add(lecture1);
            course.Lectures.Add(lecture2);

            FinishedHandlerComposite courseF = new(course);

            Assert.AreEqual(0.37, courseF.GetFinishedPercent());

        }
    }
}
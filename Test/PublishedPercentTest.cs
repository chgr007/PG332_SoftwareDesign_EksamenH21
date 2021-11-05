using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace Test
{
    public class PublishedPercentTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NodeNotPublished()
        {
            Task task = new();
            task.Published = false;

            PublishedHandlerLeaf taskP = new(task);

            Assert.AreEqual(0.00, taskP.GetPublishedPercent());
        }

        [Test]
        public void NodePublished()
        {
            Task task = new();
            task.Published = true;

            PublishedHandlerLeaf taskF = new(task);

            Assert.AreEqual(1.00, taskF.GetPublishedPercent());
        }

        [Test]
        public void CompositeWithLeafChildren()
        {
            Task task1 = new();
            task1.Published = false;

            Task task2 = new();
            task2.Published = true;

            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);

            PublishedHandlerComposite taskSetF = new(taskSet);

            Assert.AreEqual(0.50, taskSetF.GetPublishedPercent());
        }

        [Test]
        public void CompositeWithLeafAndCompositeChildren()
        {
            Task task1 = new();
            task1.Published = true;

            Task task2 = new();
            task2.Published = true;

            TaskSet taskSet1 = new();
            taskSet1.Published = true;
            taskSet1.Tasks.Add(task1);
            taskSet1.Tasks.Add(task2);

            Task task3 = new();
            task3.Published = false;

            Task task4 = new();
            task4.Published = false;

            TaskSet taskSet2 = new();
            taskSet2.Published = false;
            taskSet2.Tasks.Add(task3);
            taskSet2.Tasks.Add(task4);

            Lecture lecture1 = new();
            lecture1.Published = true;
            lecture1.TaskSet = taskSet1;

            Lecture lecture2 = new();
            lecture2.Published = false;
            lecture2.TaskSet = taskSet2;

            Course course = new();
            course.Published = true;
            course.Lectures.Add(lecture1);
            course.Lectures.Add(lecture2);

            PublishedHandlerComposite courseF = new(course);

            Assert.AreEqual(0.50, courseF.GetPublishedPercent());

        }
    }
}
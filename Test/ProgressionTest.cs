using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Handlers;


namespace Test
{
    public class ProgressionTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void NodeNotFinished()
        {
            Task task = new();
            task.Published = true;
            task.Finished = false;

            ProgressionHandlerLeaf taskP = new(task);

            Assert.AreEqual(0.00, taskP.GetProgression());
        }

        [Test]
        public void NodeFinished()
        {
            Task task = new();
            task.Published = true;
            task.Finished = true;

            ProgressionHandlerLeaf taskP = new(task);

            Assert.AreEqual(1.00, taskP.GetProgression());
        }

        [Test]
        public void CompositeWithLeafChildren()
        {
            Task task1 = new();
            task1.Published = true;
            task1.Finished = false;

            ProgressionHandlerLeaf task1P = new(task1);

            Task task2 = new();
            task2.Published = true;
            task2.Finished = true;

            ProgressionHandlerLeaf task2P = new(task2);

            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);

            ProgressionHandlerComposite taskSetP = new(taskSet);
            taskSetP.Children.Add(task1P);
            taskSetP.Children.Add(task2P);

            Assert.AreEqual(0.50, taskSetP.GetProgression());
        }
        
        [Test]
        public void CompositeWithLeafAndCompositeChildren()
        {
            Task task1 = new();
            task1.Published = true;
            task1.Finished = false;

            ProgressionHandlerLeaf task1P = new(task1);

            Task task2 = new();
            task2.Published = true;
            task2.Finished = true;

            ProgressionHandlerLeaf task2P = new(task2);

            TaskSet taskSet1 = new();
            taskSet1.Published = true;
            taskSet1.Tasks.Add(task1);
            taskSet1.Tasks.Add(task2);

            ProgressionHandlerComposite taskSet1P = new(taskSet1);
            taskSet1P.Children.Add(task1P);
            taskSet1P.Children.Add(task2P);

            Task task3 = new();
            task3.Published = true;
            task3.Finished = false;

            ProgressionHandlerLeaf task3P = new(task3);

            Task task4 = new();
            task4.Published = true;
            task4.Finished = false;

            ProgressionHandlerLeaf task4P = new(task4);

            TaskSet taskSet2 = new();
            taskSet2.Published = true;
            taskSet2.Tasks.Add(task3);
            taskSet2.Tasks.Add(task4);

            ProgressionHandlerComposite taskSet2P = new(taskSet2);
            taskSet2P.Children.Add(task3P);
            taskSet2P.Children.Add(task4P);

            Lecture lecture1 = new();
            lecture1.Published = true;
            lecture1.Finished = true;
            lecture1.TaskSet = taskSet1;

            Lecture lecture2 = new();
            lecture2.Published = true;
            lecture2.Finished = false;
            lecture2.TaskSet = taskSet2;

            ProgressionHandlerLeaf lecture1SeenP = new(lecture1);
            ProgressionHandlerComposite lecture1TotalP = new(lecture1);
            lecture1TotalP.Children.Add(lecture1SeenP);
            lecture1TotalP.Children.Add(taskSet1P);

            ProgressionHandlerLeaf lecture2SeenP = new(lecture2);
            ProgressionHandlerComposite lecture2TotalP = new(lecture2);
            lecture2TotalP.Children.Add(lecture2SeenP);
            lecture2TotalP.Children.Add(taskSet2P);

            Course course = new();
            course.Published = true;
            course.Lectures.Add(lecture1);
            course.Lectures.Add(lecture2);

            ProgressionHandlerComposite courseP = new(course);
            courseP.Children.Add(lecture1TotalP);
            courseP.Children.Add(lecture2TotalP);

            Assert.AreEqual(0.37, courseP.GetProgression());

        }
    }
}
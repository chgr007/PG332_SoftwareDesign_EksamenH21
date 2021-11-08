using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace Test
{
    class ProgressionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NodeNotPublishedAndNotFinished()
        {
            Task task = new();

            ProgressionHandlerLeaf taskF = new(task);

            Assert.AreEqual(new ProgressionWrapper(0.00,0.00), taskF.GetProgression());
        }

        [Test]
        public void NodeNotPublishedAndFinished()
        {
            Task task = new();
            task.Finished = true;

            ProgressionHandlerLeaf taskF = new(task);

            Assert.AreEqual(new ProgressionWrapper(0.00, 0.00), taskF.GetProgression());
        }

        [Test]
        public void NodePublishedAndNotFinished()
        {
            Task task = new();
            task.Published = true;

            ProgressionHandlerLeaf taskF = new(task);

            Assert.AreEqual(new ProgressionWrapper(1.00, 0.00), taskF.GetProgression());
        }

        [Test]
        public void NodePublishedAndFinished()
        {
            Task task = new();
            task.Published = true;
            task.Finished = true;

            ProgressionHandlerLeaf taskF = new(task);

            Assert.AreEqual(new ProgressionWrapper(1.00, 1.00), taskF.GetProgression());
        }
        
        [Test]
        public void NotPublishedCompositeWithPublishedLeafChildren()
        {
            Task task1 = new();
            task1.Published = true;

            Task task2 = new();
            task2.Published = true;
            task2.Finished = true;

            TaskSet taskSet = new();
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);

            ProgressionHandlerComposite taskSetF = new(taskSet);

            Assert.AreEqual(new ProgressionWrapper(0.00, 0.00), taskSetF.GetProgression());
        }

        [Test]
        public void PublishedCompositeWithAnyLeafChildren()
        {
            Task task1 = new();

            Task task2 = new();
            task2.Published = true;
            task2.Finished = true;

            Task task3 = new();
            task3.Published = true;

            Task task4 = new();
            task4.Finished = true;

            TaskSet taskSet = new();
            taskSet.Published = true;
            taskSet.Tasks.Add(task1);
            taskSet.Tasks.Add(task2);
            taskSet.Tasks.Add(task3);
            taskSet.Tasks.Add(task4);

            ProgressionHandlerComposite taskSetF = new(taskSet);

            Assert.AreEqual(new ProgressionWrapper(0.50, 0.25), taskSetF.GetProgression());
        }
        
        [Test]
        public void CompositeWithLeafAndCompositeChildren()
        {
            Task task1 = new();
            task1.Published = true;
            task1.Finished = true;

            Task task2 = new();
            task2.Published = true;

            TaskSet taskSet1 = new();
            taskSet1.Published = true;
            taskSet1.Tasks.Add(task1);
            taskSet1.Tasks.Add(task2);

            Task task3 = new();
            task3.Published = true;

            Task task4 = new();
            task4.Published = true;

            TaskSet taskSet2 = new();
            taskSet2.Published = true;
            taskSet2.Tasks.Add(task3);
            taskSet2.Tasks.Add(task4);

            Task task5 = new();

            Task task6 = new();

            TaskSet taskSet3 = new();
            taskSet3.Tasks.Add(task5);
            taskSet3.Tasks.Add(task6);

            Lecture lecture1 = new();
            lecture1.Published = true;
            lecture1.Finished = true;
            lecture1.TaskSet = taskSet1;

            Lecture lecture2 = new();
            lecture2.Published = true;
            lecture2.TaskSet = taskSet2;

            Lecture lecture3 = new();
            lecture3.TaskSet = taskSet3;

            Course course = new();
            course.Published = true;
            course.Lectures.Add(lecture1);
            course.Lectures.Add(lecture2);
            course.Lectures.Add(lecture3);

            ProgressionHandlerComposite courseF = new(course);

            Assert.AreEqual(new ProgressionWrapper(0.66, 0.25), courseF.GetProgression());
        }
        
    }
}

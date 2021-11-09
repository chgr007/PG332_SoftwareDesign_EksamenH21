﻿using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ConsoleUi : IConsoleUi
    {
        public User user { get; set; }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintPercentageDone(int percentage)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMainMenu()
        {
            string name = "Harry";
            string semester = "3";
            string progressionBar = "|####################==========----------|";
            string expected = $"Velkommen, {name}\r\n" +
                              $"Nåværende semester: {semester}\r\n" +
                              $"{progressionBar}\r\n" +
                              "\r\n" +
                              $"Velg emne:\r\n" +
                              $"1 - AdvJava\r\n" +
                              $"2 - SoftDes\r\n" +
                              $"3 - AlgDat\r\n" +
                              $"4 - SmiPro\r\n" +
                              "\r\n" +
                              $"0 - gå til spesialiseringsmeny\r\n" +
                              "\r\n" +
                              "E - avslutt\r\n";
            PrintMessage(expected);
        }

        public void ShowCourseMenu()
        {
            throw new NotImplementedException();
        }

        public void ShowCourseMenu(int courseIndex)
        {
            string courseName = "AdvJava";
            List<Lecture> lectures = new List<Lecture>() {new Lecture() {Title = "Lecture1"}};
            string lecturePresentation = "";

            for (int i = 0; i < lectures.Count; i++)
            {
                lecturePresentation += $"{lectures[i].Title} - {i}";
            }

            string progressBar = "|####################==========----------|";

            string result = $"-- {courseName}\r\n" +
                            $"{progressBar}\r\n" +
                            $"\r\n" +
                            $"{lecturePresentation}\r\n"
                ;

            PrintMessage(result);

            int selected = Int32.Parse(ConsoleRead());
            ShowTaskSetMenu(lectures[selected]);
        }

        public void ShowTaskSetMenu(Lecture lecture)
        {
            string lectureName = lecture.Title;
            TaskSet taskSet = lecture.TaskSet;
            taskSet.Tasks.Add(new Task() {Title = "Task 1"});
            string taskSetPresentation = "**** Task Set Menu ****\r\n" +
                                         $"Lecture seen: {(lecture.Finished ? "yes" : "no")}\r\n" +
                                         "Change done status? (y/n)\r\n";

            for (int i = 0; i < taskSet.Tasks.Count; i++)
            {
                taskSetPresentation += $"{taskSet.Tasks[i].Title} - {i}\r\n";
            }

            PrintMessage(taskSetPresentation);

            int taskIndex = Int32.Parse(ConsoleRead());
            TaskMenu(taskSet.Tasks[taskIndex]);
        }

        public void TaskMenu(Task task)
        {
            string taskPresentation = $"*** {task.Title} ***\r\n" +
                                      $"{task.Description}\r\n" +
                                      $"Published: {(task.Published ? "yes" : "no")}\r\n" +
                                      $"Done: {(task.Finished ? "yes" : "no")}\r\n";
            PrintMessage(taskPresentation);

            PrintMessage("Change done status? (y/n)");
            switch (ConsoleRead())
            {
                case "y":
                    // should change done status
                    break;
                case "n":
                    // should not change status
                    break;
                default:
                    // invalid option
                    break;
            }
        }

        public void ShowRegisterUserMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSelectSpecializationMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSelectOptionalCourseMenu()
        {
            throw new System.NotImplementedException();
        }


        public void start()
        {
            // Her skal loginUser returnere en User

            while (true)
            {
                ShowMainMenu();
                switch (ConsoleRead())
                {
                    case "1":
                        ShowCourseMenu(1);
                        break;
                    case "2":
                        ShowCourseMenu(2);
                        break;
                    case "3":
                        ShowCourseMenu(3);
                        break;
                    case "4":
                        ShowCourseMenu(4);
                        break;
                    case "0":
                        PrintMessage("gå til spesialiseringsmeny");
                        break;
                    case "E":
                        PrintMessage("Du har valgt avslutt");
                        ShowSelectSpecializationMenu();
                        break;
                    default:
                        PrintMessage("Ugyldig valg");
                        break;
                }
            }
        }

        public string ConsoleRead()
        {
            PrintMessage("Enter option: ");
            return Console.ReadLine();
        }

        public string[] GetLoginCredentials()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Task {
    public static class TaskManager {
        public static List<Task> Tasks = new List<Task>();

        public static void AddTask(Task task) {
            Tasks.Add(task);
        }

        public static void ShowAllTasks() {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                ConsoleTask(currentTask);
            }
        }

        public static void ShowTask(string taskName) {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                string currentTaskName = currentTask.TaskName;
                if (taskName == currentTaskName) {
                    ConsoleTask(currentTask);
                }
            }
        }

        public static void ChangeTaskStatus(string taskName, string taskStatus) {
            Task task = GetTask(taskName);
            task.Status = taskStatus;
        }

        public static void UpdateTask(string taskName, string newTaskName, string newTaskDescription, string newTaskStatus) {
            Task task = GetTask(taskName);
            task.TaskName = newTaskName;
            task.TaskDescription = newTaskDescription;
            task.Status = newTaskStatus;
        }

        public static void RemoveTask(string taskName) {
            Task task = GetTask(taskName);
            Tasks.Remove(task);
        }

        public static void RemoveAllTasks() {
            Tasks.Clear();
        }

        public static Task GetTask(string taskName) {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                string currentTaskName = currentTask.TaskName;
                if (taskName == currentTaskName) {
                    return currentTask;
                }
            }
            
            return null;
        }

        public static Task[] GetTasks(DateTime date) {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();
            List<Task> tasksToReturn = new List<Task>();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                if (currentTask.Date.ToShortDateString() == date.ToShortDateString()) {
                    tasksToReturn.Add(currentTask);
                }
            }

            return tasksToReturn.ToArray();
        }

        public static Task[] GetTasksFalse() {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();
            List<Task> tasksToReturn = new List<Task>();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                if (currentTask.Status == "false") {
                    tasksToReturn.Add(currentTask);
                }
            }

            return tasksToReturn.ToArray();
        }

        public static Task[] GetTasksTrue() {
            int tasksLength = Tasks.Count;
            Task[] tasksArray = Tasks.ToArray();
            List<Task> tasksToReturn = new List<Task>();

            Task currentTask = null;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                currentTask = tasksArray[taskIndex];
                if (currentTask.Status == "true") {
                    tasksToReturn.Add(currentTask);
                }
            }

            return tasksToReturn.ToArray();
        }

        public static bool IsEmpty() {
            return Tasks.Count <= 0;
        }

        private static void ConsoleTask(Task task) {
            ConsoleColor currentConsoleForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = task.TaskColor;

            Console.WriteLine($"Date: {task.Date.ToShortDateString()}");
            Console.WriteLine($"Task name: {task.TaskName}");
            Console.WriteLine($"Task description: {task.TaskDescription}");
            Console.WriteLine($"Task color: {task.TaskColor}");
            Console.WriteLine($"Status: {task.Status}");
            Console.WriteLine();

            Console.ForegroundColor = currentConsoleForegroundColor;
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ConsoleApp1.Task {
    public static class Command {
        const string COMMAND_CREATE_TASK = "createtask";
        const string COMMAND_REMOVE_TASK = "removetask";
        const string COMMAND_REMOVE_ALL_TASKS = "removealltasks";
        const string COMMAND_UPDATE_TASK = "updatetask";
        const string COMMAND_LIST_TASKS = "listtasks";
        const string COMMAND_SHOW_TASK = "showtask";
        const string COMMAND_SHOW_TASKS_DATE = "showtasksdate";
        const string COMMAND_SHOW_TASKS_TRUE = "showtaskstrue";
        const string COMMAND_SHOW_TASKS_FALSE = "showtasksfalse";
        const string COMMAND_CHANGE_TASK_STATUS = "changetaskstatus";
        const string COMMAND_FINALIZE_TASK = "finalizetask";
        const string COMMAND_CLEAR_CMD = "clearcmd";
        const string COMMAND_SAVE_TASKS = "savetasks";
        const string COMMAND_HELP = "help";
        const string COMMAND_EXIT = "exit";

        private static string _command;

        public static void ExecuteCommand() {
            Task task = null;

            Console.Write("Command: ");
            _command = Console.ReadLine();

            Console.WriteLine();

            switch (_command) {
                case COMMAND_CREATE_TASK:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    string taskName = _command;
                    Console.Write("Task description: ");
                    _command = Console.ReadLine();
                    string taskDescription = _command;

                    task = new Task(taskName, taskDescription);
                    TaskManager.AddTask(task);

                    Console.Clear();
                    TaskManager.ShowAllTasks();

                    ExecuteCommand();

                    break;
                case COMMAND_SHOW_TASK:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    taskName = _command;

                    Console.Clear();
                    TaskManager.ShowTask(taskName);

                    ExecuteCommand();

                    break;
                case COMMAND_SHOW_TASKS_DATE:
                    Console.WriteLine("Date: ");
                    _command = Console.ReadLine();
                    int year = int.Parse(_command.Split("/")[2]);
                    int month = int.Parse(_command.Split("/")[1]);
                    int day = int.Parse(_command.Split("/")[0]);
                    DateTime taskDate = new DateTime(year, month, day);
                    Task[] tasksDate = TaskManager.GetTasks(taskDate);
                    int tasksDateLength = tasksDate.Length;

                    Console.Clear();

                    if (tasksDate.Length <= 0) {
                        Console.WriteLine("Tasks not found!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        Console.Clear();

                        ExecuteCommand();
                    }

                    for (int taskIndex = 0; taskIndex < tasksDateLength; taskIndex++) {
                        task = tasksDate[taskIndex];
                        TaskManager.ShowTask(task.TaskName);
                    }

                    ExecuteCommand();

                    break;
                case COMMAND_SHOW_TASKS_FALSE:
                    Task[] tasksFalse = TaskManager.GetTasksFalse();
                    int tasksLength = tasksFalse.Length;

                    if (tasksFalse.Length <= 0) {
                        Console.WriteLine("Tasks not found!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        Console.Clear();

                        ExecuteCommand();
                    }

                    Console.Clear();

                    Task currentTask = null;
                    for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                        currentTask = tasksFalse[taskIndex];
                        TaskManager.ShowTask(currentTask.TaskName);
                    }

                    ExecuteCommand();

                    break;
                case COMMAND_SHOW_TASKS_TRUE:
                    Task[] tasksTrue = TaskManager.GetTasksTrue();
                    tasksLength = tasksTrue.Length;

                    if (tasksTrue.Length <= 0) {
                        Console.WriteLine("Tasks not found!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        Console.Clear();

                        ExecuteCommand();
                    }

                    Console.Clear();

                    currentTask = null;
                    for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                        currentTask = tasksTrue[taskIndex];
                        TaskManager.ShowTask(currentTask.TaskName);
                    }

                    ExecuteCommand();

                    break;
                case COMMAND_CHANGE_TASK_STATUS:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    taskName = _command;
                    task = TaskManager.GetTask(taskName);
                    TaskNotFound(task);
                    Console.Write("Status (true / false): ");
                    _command = Console.ReadLine();
                    string taskStatus = _command;

                    TaskManager.ChangeTaskStatus(taskName, taskStatus);
                    TaskManager.ChangeTaskStatus(taskName, taskStatus);
                    Console.Clear();
                    TaskManager.ShowTask(taskName);

                    ExecuteCommand();

                    break;
                case COMMAND_UPDATE_TASK:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    taskName = _command;
                    task = TaskManager.GetTask(taskName);
                    TaskNotFound(task);
                    Console.Clear();
                    Console.Write("New task name: ");
                    _command = Console.ReadLine();
                    string newTaskName = _command;
                    Console.Write("New task description: ");
                    _command = Console.ReadLine();
                    string newTaskDescription = _command;
                    Console.Write("New task status: ");
                    _command = Console.ReadLine();
                    string newTaskStatus = _command;

                    TaskManager.UpdateTask(taskName, newTaskName, newTaskDescription, newTaskStatus);
                    Console.Clear();
                    TaskManager.ShowTask(newTaskName);

                    ExecuteCommand();

                    break;
                case COMMAND_REMOVE_TASK:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    taskName = _command;
                    task = TaskManager.GetTask(taskName);
                    TaskNotFound(task);

                    TaskManager.RemoveTask(taskName);
                    Console.Clear();

                    ExecuteCommand();

                    break;
                case COMMAND_REMOVE_ALL_TASKS:
                    Console.Write("Sure remove all tasks? (Y(y) / N(n)");

                    char choice = Console.ReadKey().KeyChar;
                    switch (choice) {
                        case 'Y':
                        case 'y':
                            TaskManager.RemoveAllTasks();

                            Console.Clear();
                            Console.WriteLine("All tasks are removed.");

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();

                            Console.Clear();

                            ExecuteCommand();

                            break;
                        case 'N':
                        case 'n':
                            Console.Clear();
                            ExecuteCommand();

                            break;
                        default:
                            Console.WriteLine("Command not recognized!");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();

                            Console.Clear();
                            ExecuteCommand();

                            break;
                    }

                    break;
                case COMMAND_FINALIZE_TASK:
                    Console.Write("Task name: ");
                    _command = Console.ReadLine();
                    taskName = _command;
                    task = TaskManager.GetTask(taskName);
                    TaskNotFound(task);

                    TaskManager.ChangeTaskStatus(taskName, "true");
                    Console.Clear();

                    ExecuteCommand();

                    break;
                case COMMAND_CLEAR_CMD:
                    Console.Clear();

                    ExecuteCommand();

                    break;
                case COMMAND_LIST_TASKS:
                    if (TaskManager.IsEmpty()) {
                        Console.WriteLine("Task list is empty.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        ExecuteCommand();
                    }

                    TaskManager.ShowAllTasks();

                    ExecuteCommand();

                    break;
                case COMMAND_SAVE_TASKS:
                    Task[] tasks = TaskManager.Tasks.ToArray();

                    string jsonTasks = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
                    string fileName = "tasks.json";
                    File.WriteAllText(fileName, jsonTasks, Encoding.UTF8);

                    Console.WriteLine("Tasks was saved!");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    Console.Clear();
                    ExecuteCommand();

                    break;
                case COMMAND_HELP:
                    Console.WriteLine("createtasks: Create a new task");
                    Console.WriteLine("removetask: Remove an task");
                    Console.WriteLine("removealltasks: Remove all tasks");
                    Console.WriteLine("updatetask: Update an task");
                    Console.WriteLine("listtasks: List all tasks");
                    Console.WriteLine("showtask: Show one task");
                    Console.WriteLine("showtasksdate: Show tasks by date");
                    Console.WriteLine("showtaskstrue: Show tasks concluded");
                    Console.WriteLine("showtasksfalse: Show tasks not concluded");
                    Console.WriteLine("changetaskstatus: Change a status task");
                    Console.WriteLine("finalizetask: Change a status task to 'true'");
                    Console.WriteLine("clearcmd: Clear all command line");
                    Console.WriteLine("savetasks: Save all tasks to 'tasks.json' file");
                    Console.WriteLine("help: Show all command for help");
                    Console.WriteLine("exit: Exit program");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    Console.Clear();
                    ExecuteCommand();

                    break;
                case COMMAND_EXIT:
                    break;
                default:
                    Console.WriteLine("Command not recognized!");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();

                    Console.Clear();
                    ExecuteCommand();

                    break;
            }
        }

        private static void TaskNotFound(Task task) {
            if (task == null) {
                Console.WriteLine("Task not found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                task = null;
                _command = string.Empty;

                Console.Clear();
                ExecuteCommand();

                return;
            }
        }

        private static void Restart() {
            _command = Console.ReadLine();
        }
    }
}

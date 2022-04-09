using System.IO;
using System.Text.Json;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            string jsonFile = File.ReadAllText("tasks.json");
            Task.Task[] tasks = JsonSerializer.Deserialize<Task.Task[]>(jsonFile);

            int tasksLength = tasks.Length;
            for (int taskIndex = 0; taskIndex < tasksLength; taskIndex++) {
                Task.TaskManager.AddTask(tasks[taskIndex]);
            }

            Task.Command.ExecuteCommand();
        }
    }
}

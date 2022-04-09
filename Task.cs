using System;

namespace ConsoleApp1.Task {
    public class Task {
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public ConsoleColor TaskColor { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }

        public Task(string taskName, string taskDescription) {
            Date = DateTime.Now;
            TaskName = taskName;
            TaskDescription = taskDescription;
            TaskColor = ConsoleColor.White;
            Status = "false";
        }

        public void SetTaskColor(ConsoleColor taskColor) {
            TaskColor = taskColor;
        }

        public void FinalizeTask() {
            Status = "true";
        }
    }
}

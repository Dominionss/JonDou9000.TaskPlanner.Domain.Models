using System;
using JonDou9000.TaskPlanner.Domain.Models.Enums;
using JonDou9000.TaskPlanner.Domain.Models;

namespace JonDou9000.TaskPlanner
{
    public class WorkItem
    {
        // Властивість для дати створення
        public DateTime CreationDate { get; set; }

        // Властивість для дати завершення
        public DateTime DueDate { get; set; }

        // Властивість для пріоритету завдання (використовується перерахування Priority)
        public Priority Priority { get; set; }

        // Властивість для складності завдання (використовується перерахування Complexity)
        public Complexity Complexity { get; set; }

        // Властивість для назви завдання
        public string Title { get; set; }

        // Властивість для опису завдання
        public string Description { get; set; }

        // Властивість для позначення виконання завдання
        public bool IsCompleted { get; set; }

        // Перевизначення методу ToString()
        public override string ToString()
        {
            // Форматування дати та використання рядкової інтерполяції
            string dueDateFormatted = DueDate.ToString("dd.MM.yyyy");

            // Форматування пріоритету в нижньому регістрі
            string priorityFormatted = Priority.ToString().ToLower();

            // Повернення відформатованого рядка
            return $"{Title}: due {dueDateFormatted}, {priorityFormatted} priority";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо новий екземпляр WorkItem
            WorkItem task = new WorkItem
            {
                CreationDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(3),
                Priority = Priority.High,
                Complexity = Complexity.Hours,
                Title = "Complete project report",
                Description = "Finish the report for the TaskPlanner project.",
                IsCompleted = false
            };

            // Виводимо інформацію про завдання
            Console.WriteLine("Task Information:");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine($"Complexity: {task.Complexity}");
            Console.WriteLine($"Creation Date: {task.CreationDate}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine($"Is Completed: {task.IsCompleted}");

            Console.WriteLine(task.ToString());
        }
    }
}


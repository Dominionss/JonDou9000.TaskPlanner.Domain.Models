using System;
using System.Collections.Generic;
using JonDou9000.TaskPlanner.Domain.Models;
using JonDou9000.TaskPlanner.Domain.Logic;
using JonDou9000.TaskPlanner.Domain.Models.Enums;
using JonDou9000.TaskPlanner;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Створюємо список завдань
        List<WorkItem> workItems = new List<WorkItem>();

        while (true)
        {
            Console.WriteLine("Введіть деталі завдання або натисніть Enter для завершення:");

            // Введення назви завдання
            Console.Write("Назва завдання: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
                break;

            // Введення дати завершення
            Console.Write("Дата завершення (dd.MM.yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            // Введення пріоритету завдання
            Console.Write("Пріоритет (None, Low, Medium, High, Urgent): ");
            Priority priority = Enum.Parse<Priority>(Console.ReadLine(), ignoreCase: true);

            // Додати завдання в список
            workItems.Add(new WorkItem
            {
                Title = title,
                DueDate = dueDate,
                Priority = priority,
                CreationDate = DateTime.Now // Припустимо, дата створення - зараз
            });

            Console.WriteLine();
        }

        // Створюємо планувальник завдань
        SimpleTaskPlanner taskPlanner = new SimpleTaskPlanner();

        // Впорядковуємо список завдань
        WorkItem[] sortedWorkItems = taskPlanner.CreatePlan(workItems.ToArray());

        // Виводимо результати
        Console.WriteLine("Впорядковані завдання:");
        foreach (var workItem in sortedWorkItems)
        {
            Console.WriteLine(workItem.ToString());
        }
    }
}


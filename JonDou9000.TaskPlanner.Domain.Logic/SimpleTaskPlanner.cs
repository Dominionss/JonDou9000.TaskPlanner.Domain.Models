using System;
using System.Collections.Generic;
using System.Linq;
using JonDou9000.TaskPlanner.Domain.Models;

namespace JonDou9000.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        // Метод, що впорядковує завдання
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            var itemsAsList = items.ToList(); // Конвертація масиву в List<WorkItem>
            itemsAsList.Sort(CompareWorkItems); // Сортування
            return itemsAsList.ToArray(); // Конвертація назад у масив
        }

        // Метод для порівняння елементів WorkItem
        private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // Спершу сортуємо за пріоритетом (спадання)
            int priorityComparison = secondItem.Priority.CompareTo(firstItem.Priority);
            if (priorityComparison != 0) return priorityComparison;

            // Далі сортуємо за DueDate (зростання)
            int dueDateComparison = firstItem.DueDate.CompareTo(secondItem.DueDate);
            if (dueDateComparison != 0) return dueDateComparison;

            // Нарешті сортуємо за Title в алфавітному порядку
            return string.Compare(firstItem.Title, secondItem.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
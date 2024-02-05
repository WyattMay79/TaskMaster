using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

class Program
{
    //new list for all tasks
    static List<string> tasks = new List<string>();

    static void Main()
    {
        bool active = true;

        do
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("\n");
            Console.WriteLine("[S]ee all Todo\'s");
            Console.WriteLine("[A]dd a new Todo to the list");
            Console.WriteLine("[R]emove a Todo from the list");
            Console.WriteLine("[E]xit the Todo list");

            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "S":
                case "s":
                    PrintTasksToConsole();
                    break;
                case "A":
                case "a":
                    AddTaskToList();
                    break;
                case "R":
                case "r":
                    RemoveTaskFromList();
                    break;
                case "E":
                case "e":
                    Console.WriteLine("\n");
                    Console.WriteLine("Closing the program");
                    active = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please enter the correct letter for the option you want!");
                    break;
            }
        } while (active);
    }


    //See all tasks
    private static void PrintTasksToConsole()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list...");
            Console.WriteLine("Add some new tasks!.");
            return;
        }
        Console.WriteLine("Here are your tasks: ");

        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }


    //Create Task
    private static void AddTaskToList()
    {
        Console.WriteLine("Add a description of the task: ");
        var newTask = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newTask))
        {
            Console.WriteLine("No description was added, please enter a description");

            return;
        }
        else
        {
            foreach (var task in tasks)
            {
                if (task.Contains(newTask))
                {
                    Console.WriteLine("Duplicate description!");
                    Console.WriteLine("Please enter a unique task description");
                    return;
                }
            }

            int taskNumber = tasks.Count + 1;
            string formattedTask = $"{taskNumber}. {newTask}";

            Console.WriteLine("Adding new task: " + formattedTask);
            tasks.Add(formattedTask);

            return;
        }
    }


    //Remove Task
    private static void RemoveTaskFromList()
    {
        if (tasks.Count == 0) 
        {
            Console.WriteLine("There are no tasks to remove.");
            return;
        }
        Console.WriteLine("Enter number of task you would like to delete: ");
        var userSelection = Console.ReadLine();

        if (int.TryParse(userSelection, out int taskIndex))
        {
            taskIndex--;

            // Checking to make sure the index is valid
            if (taskIndex >= 0 && taskIndex < tasks.Count)
            {
                Console.WriteLine("Removing task: " + tasks[taskIndex]);
                tasks.RemoveAt(taskIndex);

                //Corrects all the task numbers since a task was removed from the list
                UpdateTaskNumbers();
            }
            else
            {
                Console.WriteLine("Invalid selection. No task was removed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection. Please enter a valid task number.");
        }
    }


    private static void UpdateTaskNumbers()
    {
        for(int i = 0; i < tasks.Count; i++)
        {
            //Getting the description(string) body after the number that is prefixed to the task description and saving it to the description variable
            string description = tasks[i].Substring(tasks[i].IndexOf('.') + 2);

            //setting all task prefix numbers with the correct numbers **(only used when deleting a task)**
            tasks[i] =  $"{i + 1}. {description}";
        }
    }
}


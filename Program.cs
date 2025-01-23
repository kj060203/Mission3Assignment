using System;
using System.Collections.Generic;
using Mission3Assignment;

class Program
{
    // Create list that can be used for every instance of the program
    static List<FoodItem> foodList = new List<FoodItem>();

    static void Main(string[] args)
    {
        while (true)
        {
            // Main menu text
            Console.WriteLine("Welcome to the Food Bank!\n Please Select What You Would Like to Do Today:" +
                              "\n 1. Add Food Item(s)" +
                              "\n 2. Delete Food Item(s)" +
                              "\n 3. Print List of Current Food Items" +
                              "\n 4. Exit the Program");

            int menu;
            do
            {
                Console.Write("Please enter the number for what you would like to do today: ");
            // error handling to make sure the user picks a valid number
            } while (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 4);

            if (menu == 1)
            {
                AddFoodItems();
            }
            else if (menu == 2)
            {
                DeleteFoodItems();
            }
            else if (menu == 3)
            {
                PrintFoodItems();
            }
            else if (menu == 4)
            {
                ExitProgram();
                return;
            }
        }
    }

    static void AddFoodItems()
    {
        // User enters in what is needed for the food item
        Console.Write("Enter the name of the food item: ");
        string name = Console.ReadLine(); // these should connect to the constructors in the fooditem.cs

        Console.Write("Enter the category of the food item: ");
        string category = Console.ReadLine();

        Console.Write("Enter the quantity of the food item: ");
        int quantity;
        //Another error handling to make sure they are entering positive inventory
        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
        {
            Console.WriteLine("Quantity must be positive. Please enter a valid quantity.");
        }

        DateTime expirationDate;
        // Another error handling. Makes sure it is a valid future date
        while (true)
        {
            Console.Write("Enter the expiration date of the food item (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out expirationDate) && expirationDate > DateTime.Now)
            {
                break;
            }
            else
            {
                Console.WriteLine("Expiration dates must be in the future and in the format MM/DD/YYYY. Please enter a correct expiration date.");
            }
        }

        // This adds the new food item created to the list storing them
        foodList.Add(new FoodItem(name, category, quantity, expirationDate));
        Console.WriteLine("Thank you for your donation");
    }

    // Called when the user chooses 2
    static void DeleteFoodItems()
    {
        Console.Write("Enter the name of the food item you would like to delete: ");
        string name = Console.ReadLine();

        // This searches the list and finds the item
        FoodItem itemToRemove = foodList.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // If found it will delete it, if not then it will tell the user that that item was not in inventory
        if (itemToRemove != null)
        {
            foodList.Remove(itemToRemove);
            Console.WriteLine($"{name} has been deleted.");
        }
        else
        {
            Console.WriteLine("Not a valid food.");
        }
    }

    // Called when the user picks 3
    static void PrintFoodItems()
    {
        // Prints off a list of all current foods by looping through the foodList
        for (int i = 0; i < foodList.Count; i++)
        {
            Console.WriteLine($"\nName: {foodList[i].Name}");
            Console.WriteLine($"Category: {foodList[i].Category}");
            Console.WriteLine($"Quantity: {foodList[i].Quantity}");
            Console.WriteLine($"Expiration Date: {foodList[i].ExpirationDate.ToShortDateString()}");
        }
    }

    // Exits out of program when user selects 4
    static void ExitProgram()
    {
        Console.WriteLine("Goodbye!");
    }
}

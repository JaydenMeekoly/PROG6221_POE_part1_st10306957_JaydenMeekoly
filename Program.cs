
using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Prog Final POE
// st10306957
// Jayden Meekoly
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


class Program
{
    // Define delegates--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public delegate void RecipeAction(Recipe recipe);

    static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>();
        bool exit = false;

        //starting the while loop----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        while (!exit)
        {
            Console.WriteLine("Recipe App");
            Console.WriteLine("1. Enter Recipe Details");
            Console.WriteLine("2. Display Recipes");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Clear All Data");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                // this is choice 1, that allows the user to enter a new recipe------------------------------------------------------------------------------------------------------------------------
                case 1:
                    Recipe newRecipe = new Recipe();
                    newRecipe.OnCalorieNotification += NotifyCalorieLimitExceeded;
                    newRecipe.EnterRecipeDetails();
                    recipes.Add(newRecipe);
                    break;

                // choice to allows the user to display the recipes they have made--------------------------------------------------------------------------------------------------------------------
                case 2:
                    if (recipes.Count == 0)
                    {
                        Console.WriteLine("No recipes to display.");
                    }
                    else
                    {
                        var sortedRecipes = recipes.OrderBy(r => r.RecipeName).ToList();
                        Console.WriteLine("Recipes:");
                        foreach (var recipe in sortedRecipes)
                        {
                            Console.WriteLine(recipe.RecipeName);
                        }

                        Console.WriteLine("Enter the name of the recipe to display:");
                        string displayName = Console.ReadLine();
                        var displayRecipe = recipes.FirstOrDefault(r => r.RecipeName == displayName);
                        if (displayRecipe != null)
                        {
                            displayRecipe.DisplayRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                    }
                    break;

                //this choice allows the user to scale the recipe--------------------------------------------------------------------------------------------------------------------------------------
                case 3:
                    Console.WriteLine("Enter the name of the recipe to scale:");
                    string scaleName = Console.ReadLine();
                    var scaleRecipe = recipes.FirstOrDefault(r => r.RecipeName == scaleName);
                    if (scaleRecipe != null)
                    {
                        scaleRecipe.ScaleRecipe();
                    }
                    else
                    {
                        Console.WriteLine("Recipe not found.");
                    }
                    break;

                // this choice allows the user to reset the quantities 0f the recipe-------------------------------------------------------------------------------------------------------------------
                case 4:
                    Console.WriteLine("Enter the name of the recipe to reset quantities:");
                    string resetName = Console.ReadLine();
                    var resetRecipe = recipes.FirstOrDefault(r => r.RecipeName == resetName);
                    if (resetRecipe != null)
                    {
                        resetRecipe.ResetQuantities();
                    }
                    else
                    {
                        Console.WriteLine("Recipe not found.");
                    }
                    break;

                //this choice allows the user to clear the recipe-------------------------------------------------------------------------------------------------------------------------------------- 
                case 5:
                    recipes.Clear();
                    Console.WriteLine("All recipes cleared.");
                    break;

                // and this choice allows the user to finally exit the recipe ------------------------------------------------------------------------------------------------------------------------
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    // Event handler for calorie notification----------------------------------------------------------------------------------------------------------------------------------------------------------
    static void NotifyCalorieLimitExceeded(double totalCalories)
    {
        Console.WriteLine($"Warning: This recipe exceeds 300 calories with a total of {totalCalories} calories.");
    }
}

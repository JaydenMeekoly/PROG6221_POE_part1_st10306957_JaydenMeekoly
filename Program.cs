using RecipeApp;

class Program
{
    // Define delegates
    public delegate void RecipeAction(Recipe recipe);

    static void Main(string[] args)
    {
        List<Recipe> recipes = new List<Recipe>();
        bool exit = false;

        // Start of the while loop
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

            // Switch case to call methods to the main
            switch (choice)
            {
                // Choice 1 allows the user to insert a new recipe.
                // This recipe will also fall under a name
                case 1:
                    Recipe newRecipe = new Recipe();
                    newRecipe.EnterRecipeDetails();
                    recipes.Add(newRecipe);
                    break;
                // Choice 2 allows the user to display the recipes they have created.
                // The user will first choose which recipe they would like to display.
                // The options will display in alphabetical order.
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
                // Choice 3 allows the user to scale the recipe's quantities by 0.5, 2 or 3.
                // The user must first choose which recipe they would like to scale.
                // The program will send them back to the menu once they have scaled the quantities.
                // If they wish to view the scaled quantities they can select display in the menu again
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
                // Choice 4 allows the user to reset the quantities that were scaled.
                // The user must first select the name of the recipe that they wish to reset.
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
                // Choice 5 allows the user to completely clear all recipes.
                case 5:
                    recipes.Clear();
                    Console.WriteLine("All recipes cleared.");
                    break;
                // Choice 6 allows the user to exit the program.
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}
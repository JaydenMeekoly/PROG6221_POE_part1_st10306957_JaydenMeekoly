using System;

////////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
//st10306957
//Jayden Meekoly
//PROG6221
///////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            bool exit = false;

            //start of the while loop---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            while (!exit)
            {
                Console.WriteLine("Recipe App");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
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

                //switch case to call methods tp the main ------------------------------------------------------------------------------------------------------------------------------------------------------------
                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipeDetails();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ScaleRecipe();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.ClearData();
                        break;
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
}
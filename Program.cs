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

            }
        }
}
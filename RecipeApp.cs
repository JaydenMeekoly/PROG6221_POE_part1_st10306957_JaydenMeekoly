
using System;
using System.Collections.Generic;
using System.Linq;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//PROG6221 Final POE
//st10306957
//Jayden Meekoly
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace RecipeApp
{
    public class Recipe
    {
        public string RecipeName { get; private set; }
        private List<string> ingredients;
        private List<double> quantities;
        private List<string> units;
        private List<string> steps;
        private List<double> originalQuantities;
        private List<double> calories;
        private List<string> foodGroups;

        // Delegate for calorie notification-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public delegate void CalorieNotificationHandler(double totalCalories);
        public event CalorieNotificationHandler OnCalorieNotification;


        public Recipe()
        {
            ingredients = new List<string>();
            quantities = new List<double>();
            units = new List<string>();
            steps = new List<string>();
            originalQuantities = new List<double>();
            calories = new List<double>();
            foodGroups = new List<string>();
        }

        // this is the method that allows the user to enter a new recipe ------------------------------------------------------------------------------------------------------------------------------
        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            RecipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients:");
            if (!int.TryParse(Console.ReadLine(), out int numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1}:");
                ingredients.Add(Console.ReadLine());

                Console.WriteLine($"Enter quantity for {ingredients[i]}:");
                if (!double.TryParse(Console.ReadLine(), out double quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    return;
                }
                quantities.Add(quantity);
                originalQuantities.Add(quantity);

                Console.WriteLine($"Enter unit for {ingredients[i]}:");
                units.Add(Console.ReadLine());

                Console.WriteLine($"Enter calories for {ingredients[i]} (0 or more):");
                if (!double.TryParse(Console.ReadLine(), out double calorie) || calorie < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    return;
                }
                calories.Add(calorie);

                Console.WriteLine($"Enter food group for {ingredients[i]} (carbohydrates, protein, dairy, fruits and vegetables, fats and sugars, water):");
                foodGroups.Add(Console.ReadLine());
            }

            Console.WriteLine("Enter the number of steps:");
            if (!int.TryParse(Console.ReadLine(), out int numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps.Add(Console.ReadLine());
            }
        }

        //method to display the recipe-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void DisplayRecipe()
        {
            if (string.IsNullOrWhiteSpace(RecipeName) || ingredients.Count == 0 || steps.Count == 0)
            {
                Console.WriteLine("There is no recipe.");
                return;
            }

            Console.WriteLine($"Recipe: {RecipeName}");
            Console.WriteLine("Ingredients:");

            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]} - {calories[i]} calories, {foodGroups[i]}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }

            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                OnCalorieNotification?.Invoke(totalCalories);
            }
        }

        //method to calculate the calories of the recipe-----------------------------------------------------------------------------------------------------------------------------------------------
        public double CalculateTotalCalories()
        {
            return calories.Sum();
        }

        //methods that allows the user to scale the recipe byo.5, 2 or 3-------------------------------------------------------------------------------------------------------------------------------
        public void ScaleRecipe()
        {
            Console.WriteLine("Enter scaling factor (e.g., 0.5, 2, 3):");
            if (!double.TryParse(Console.ReadLine(), out double factor) || factor <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            for (int i = 0; i < quantities.Count; i++)
            {
                quantities[i] = originalQuantities[i] * factor;
                calories[i] = originalQuantities[i] * factor * (calories[i] / originalQuantities[i]);
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        //method allows the user to reset the quantities of the recipe---------------------------------------------------------------------------------------------------------------------------------
        public void ResetQuantities()
        {
            for (int i = 0; i < quantities.Count; i++)
            {
                quantities[i] = originalQuantities[i];
                calories[i] = originalQuantities[i] * (calories[i] / quantities[i]);
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        //method that allows the user to clear all data in the recipe----------------------------------------------------------------------------------------------------------------------------------
        public void ClearData()
        {
            RecipeName = null;
            ingredients.Clear();
            quantities.Clear();
            units.Clear();
            steps.Clear();
            originalQuantities.Clear();
            calories.Clear();
            foodGroups.Clear();

            Console.WriteLine("All recipe data cleared.");
        }
    }
}


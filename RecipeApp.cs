using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // The Recipe class handles all details and actions related to a recipe.
    public class Recipe
    {
       
        public string RecipeName { get; private set; }
        private List<string> ingredients;       // List to store ingredients
        private List<double> quantities;        // List to store quantities of each ingredient
        private List<string> units;             // List to store units of each quantity
        private List<string> steps;             // List to store steps of the recipe
        private List<double> originalQuantities;// List to store original quantities before scaling
        private List<double> calories;          // List to store calories for each ingredient
        private List<string> foodGroups;        // List to store food groups for each ingredient

        // Constructor to initialize lists
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

        // Method to enter details of the recipe
        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the name of the recipe:");
            RecipeName = Console.ReadLine();  // User inputs the recipe name

            // Prompt for number of ingredients
            Console.WriteLine("Enter the number of ingredients:");
            if (!int.TryParse(Console.ReadLine(), out int numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            // Loop to enter each ingredient's details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1}:");
                ingredients.Add(Console.ReadLine());  // User inputs ingredient name

                // Prompt for quantity and validate input
                Console.WriteLine($"Enter quantity for {ingredients[i]}:");
                if (!double.TryParse(Console.ReadLine(), out double quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    return;
                }
                quantities.Add(quantity);
                originalQuantities.Add(quantity);  // Store original quantity for scaling purposes

                // Prompt for unit of the quantity
                Console.WriteLine($"Enter unit for {ingredients[i]}:");
                units.Add(Console.ReadLine());

                // Prompt for calories and validate input
                Console.WriteLine($"Enter calories for {ingredients[i]} (0 or more):");
                if (!double.TryParse(Console.ReadLine(), out double calorie) || calorie < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    return;
                }
                calories.Add(calorie);

                // Prompt for food group
                Console.WriteLine($"Enter food group for {ingredients[i]} (carbohydrates, protein, dairy, fruits and vegetables, fats and sugars, water):");
                foodGroups.Add(Console.ReadLine());
            }

            // Prompt for number of steps in the recipe
            Console.WriteLine("Enter the number of steps:");
            if (!int.TryParse(Console.ReadLine(), out int numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            // Loop to enter each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps.Add(Console.ReadLine());  // User inputs each step
            }
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            // Check if recipe details are present
            if (string.IsNullOrWhiteSpace(RecipeName) || ingredients.Count == 0 || steps.Count == 0)
            {
                Console.WriteLine("There is no recipe.");
                return;
            }

            // Display recipe name
            Console.WriteLine($"Recipe: {RecipeName}");
            Console.WriteLine("Ingredients:");

            // Display each ingredient's details
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]} - {calories[i]} calories, {foodGroups[i]}");
            }

            // Display each step of the recipe
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step {i + 1}: {steps[i]}");
            }

            // Calculate and display total calories
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories.");
            }
        }

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            return calories.Sum();  // Sum up all the calories
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            // Prompt for scaling factor and validate input
            Console.WriteLine("Enter scaling factor (e.g., 0.5, 2, 3):");
            if (!double.TryParse(Console.ReadLine(), out double factor) || factor <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            // Scale each quantity and calorie by the scaling factor
            for (int i = 0; i < quantities.Count; i++)
            {
                quantities[i] = originalQuantities[i] * factor;
                calories[i] = originalQuantities[i] * factor * (calories[i] / originalQuantities[i]);
            }

            Console.WriteLine("Recipe scaled successfully.");
        }

        // Method to reset quantities to their original values
        public void ResetQuantities()
        {
            for (int i = 0; i < quantities.Count; i++)
            {
                quantities[i] = originalQuantities[i];  // Reset to original quantity
                calories[i] = originalQuantities[i] * (calories[i] / quantities[i]);  // Reset calories accordingly
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        // Method to clear all data of the recipe
        public void ClearData()
        {
            RecipeName = null;  // Clear recipe name
            ingredients.Clear();  // Clear all ingredient-related data
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

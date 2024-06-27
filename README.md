 Recipe App

This is a console-based Recipe App that allows you to create, display, scale, reset, and clear recipes. It includes features to calculate total calories and notify if the total calories exceed 300.

How to run the application:

1. Open the project in Visual Studio.
2. Press the "Run" button at the top of Visual Studio to start the application.
3. You will be presented with a menu with 6 options.

Option you will have once you run the application:

1. Enter Recipe Details: Allows you to insert ingredients, quantities, and steps for a recipe. Also includes calories and food groups for each ingredient.
2. Display Recipes: Displays all the information about the recipes you have created. Recipes are listed in alphabetical order.
3. Scale Recipe: Scales the recipe quantities by a factor (e.g., 0.5, 2, 3). You need to select which recipe to scale.
4. Reset Quantities: Resets the scaled quantities to their original values. You need to select which recipe to reset.
5. Clear All Data: Clears all recipes and returns you to the menu.
6. Exit: Exits the application.

Notification that might pop up

- If the total calories of a recipe exceed 300, a notification will be displayed.

 Unit Tests

Unit tests have been included to validate the calorie calculation functionality. To run the tests:
1. Open the UnitTest1.cs project in Visual Studio under POEUnitTest.
2. Run the tests using the Test Explorer.

 Test Methods

- `CalculateTotalCalories_ShouldReturnCorrectSum`: checks that the total calories are correctly calculated.
- `CalculateTotalCalories_ShouldReturnZero_WhenNoIngredients`: Validates that the total calories are zero when there are no ingredients.

 Example of how to use the application

- When you select option 1, you will be prompted to enter the recipe details including ingredients, quantities, units, calories, and food groups.
- When you select option 2, you can display the details of a specific recipe by entering its name.
- When you select option 3, you can scale a recipe by a chosen factor.
- When you select option 4, you can reset the scaled quantities of a recipe.
- When you select option 5, all recipes will be cleared.
- When you select option 6, the application will exit.

Press "Enter" after every choice to proceed.

Recipe App on WPF:

This application allows you to manage recipes, including entering new recipes, displaying recipe details, scaling recipes, resetting quantities, and clearing data.

Getting Started
Run the RecipeAppWPF.exe executable.

Interface Overview:

Recipe List Tab: View all saved recipes. Select a recipe and use the buttons to interact with it.
Enter New Recipe Tab: Enter details for a new recipe including name, ingredients, and steps. Click "Save Recipe" to add it to the list.
Display Recipe Tab: View detailed information of a selected recipe.

Using the Application

1.Enter New Recipe:
2.Enter a recipe name.
3.Add ingredients by filling out the fields (Ingredient Name, Quantity, Unit, Calories, Food Group) and clicking "Add Ingredient".
4.Enter recipe steps in the "Steps" textbox.
5.Click "Save Recipe" to save the recipe.

Manage Recipes:

Display Recipe: Select a recipe from the list and click "Display Recipe" to view its details.
Scale Recipe: Select a recipe from the list and click "Scale Recipe". Enter a scaling factor (e.g., 0.5, 2, 3) in the popup window and click "Scale" to resize the recipe.
Reset Quantities: Select a recipe from the list and click "Reset Quantities" to revert ingredient quantities to their original values.
Clear Data: Select a recipe from the list and click "Clear Data" to remove the recipe from the list.
Additional Notes
Ensure all fields are filled correctly when entering new recipes to avoid errors.
Handle warnings that may appear during scaling if ingredient data is incomplete or missing.
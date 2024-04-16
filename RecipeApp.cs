class Recipe
{
    //array that holds the infomation of the recipe-------------------------------------------------------------------------------------------------------------
    private string[] ingredients;
    private double[] quantities;
    private string[] units;
    private string[] steps;
    private double[] originalQuantities;

    //method to enter a new recipe-----------------------------------------------------------------------------------------------------------------------------
    public void EnterRecipeDetails()
    {
        Console.Write("Enter the number of ingredients: ");
        int numIngredients;
        while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of ingredients.");
            Console.Write("Enter the number of ingredients: ");
        }

        ingredients = new string[numIngredients];
        quantities = new double[numIngredients];
        units = new string[numIngredients];
        originalQuantities = new double[numIngredients];
        Array.Copy(quantities, originalQuantities, numIngredients);

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write($"Enter ingredient {i + 1}: ");
            string ingredient = Console.ReadLine();
            while (string.IsNullOrEmpty(ingredient))
            {
                Console.WriteLine("Ingredient cannot be empty. Please enter ingredient name again.");
                Console.Write($"Enter ingredient {i + 1}: ");
                ingredient = Console.ReadLine();
            }
            ingredients[i] = ingredient;

            Console.Write($"Enter quantity of {ingredients[i]}: ");
            double quantity;
            while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for the quantity.");
                Console.Write($"Enter quantity of {ingredients[i]}: ");
            }
            quantities[i] = quantity;

            Console.Write($"Enter unit of measurement for {ingredients[i]}: ");
            string unit = Console.ReadLine();
            while (string.IsNullOrEmpty(unit))
            {
                Console.WriteLine("Unit of measurement cannot be empty. Please enter unit again.");
                Console.Write($"Enter unit of measurement for {ingredients[i]}: ");
                unit = Console.ReadLine();
            }
            units[i] = unit;
        }

        Console.Write("Enter the number of steps: ");
        int numSteps;
        while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of steps.");
            Console.Write("Enter the number of steps: ");
        }

        steps = new string[numSteps];

        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            string step = Console.ReadLine();
            while (string.IsNullOrEmpty(step))
            {
                Console.WriteLine("Step cannot be empty. Please enter step description again.");
                Console.Write($"Enter step {i + 1}: ");
                step = Console.ReadLine();
            }
            steps[i] = step;
        }

        Console.WriteLine("Recipe details entered successfully.");
    }

    //method to display recipe details-------------------------------------------------------------------------------------------------------------------------
    public void DisplayRecipe()
    {
        if (ingredients == null || ingredients.Length == 0)
        {
            Console.WriteLine("There is no recipe.");
            return;
        }

        Console.WriteLine("Recipe:");
        Console.WriteLine("Ingredients:");

        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
        }

        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    //method to scale the quatities of the recipes-------------------------------------------------------------------------------------------------------------
    public void ScaleRecipe()
    {
        Console.Write("Enter scale factor by choosing 0.5 or 2 or 3 (x0.5, x2, or x3): ");
        double scaleFactor = double.Parse(Console.ReadLine());

        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] *= scaleFactor;
        }

        Console.WriteLine($"Recipe scaled by a factor of {scaleFactor}.");
    }



}
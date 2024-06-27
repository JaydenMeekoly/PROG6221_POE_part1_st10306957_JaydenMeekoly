using System.Windows.Media;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using RecipeApp;
using System;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//PROG6221 Final POE
//st10306957
//Jayden Meekoly
//Reference to help with event handeling: https://stackoverflow.com/questions/4663372/how-to-add-event-handler-programmatically-in-wpf-like-one-can-do-in-winform
//Reference to xaml layout: https://learn.microsoft.com/en-us/windows/apps/design/layout/layout-panels
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new ObservableCollection<Recipe>();
            lstRecipes.ItemsSource = recipes;
        }
        //event handlers to display recipe-------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnDisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = lstRecipes.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                txtRecipeDisplay.Text = GetRecipeDisplayText(selectedRecipe);

                // Find the TabControl in the window
                TabControl tabControl = FindTabControl(this);
                if (tabControl != null)
                {
                    tabControl.SelectedIndex = 2; // Switch to Display Recipe tab
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.");
            }
        }

        // Helper method to find the TabControl--------------------------------------------------------------------------------------------------------------------------------------------------------
        private TabControl FindTabControl(DependencyObject parent)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TabControl tabControl)
                {
                    return tabControl;
                }
                else
                {
                    TabControl result = FindTabControl(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        //event handler to get recipe disply text------------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetRecipeDisplayText(Recipe recipe)
        {
            string display = $"Recipe: {recipe.RecipeName}\n\nIngredients:\n";

            for (int i = 0; i < recipe.ingredients.Count; i++)
            {
                display += $"{recipe.quantities[i]} {recipe.units[i]} of {recipe.ingredients[i]} - {recipe.calories[i]} calories, {recipe.foodGroups[i]}\n";
            }

            display += "\nSteps:\n";
            for (int i = 0; i < recipe.steps.Count; i++)
            {
                display += $"Step {i + 1}: {recipe.steps[i]}\n";
            }

            double totalCalories = recipe.CalculateTotalCalories();
            display += $"\nTotal Calories: {totalCalories}";

            if (totalCalories > 300)
            {
                display += "\nWarning: This recipe is high in calories!";
            }

            return display;
        }

        //event handler to scale the recipe------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = lstRecipes.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                // Create a simple dialog for scaling
                var scaleDialog = new Window
                {
                    Title = "Scale Recipe",
                    Width = 300,
                    Height = 150,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this
                };

                var stackPanel = new StackPanel { Margin = new Thickness(10) };
                var textBlock = new TextBlock { Text = "Enter scaling factor (e.g., 0.5, 2, 3):", Margin = new Thickness(0, 0, 0, 5) };
                var textBox = new TextBox { Margin = new Thickness(0, 0, 0, 10) };
                var button = new Button { Content = "Scale", Width = 75 };

                button.Click += (s, args) =>
                {
                    if (double.TryParse(textBox.Text, out double factor) && factor > 0)
                    {
                        for (int i = 0; i < selectedRecipe.quantities.Count; i++)
                        {
                            if (i < selectedRecipe.originalQuantities.Count && i < selectedRecipe.calories.Count)
                            {
                                selectedRecipe.quantities[i] = selectedRecipe.originalQuantities[i] * factor;
                                selectedRecipe.calories[i] = selectedRecipe.originalQuantities[i] * factor * (selectedRecipe.calories[i] / selectedRecipe.originalQuantities[i]);
                            }
                            else
                            {
                                // Handle the case where originalQuantities or calories doesn't have enough elements
                                MessageBox.Show("Warning: Some ingredient data is missing. Scaling may be incomplete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                        }
                    }
                    };

                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(textBox);
                stackPanel.Children.Add(button);
                scaleDialog.Content = stackPanel;

                if (scaleDialog.ShowDialog() == true)
                {
                    MessageBox.Show("Recipe scaled successfully.");

                    // Refresh the recipe display if it's currently shown
                    if (txtRecipeDisplay.Text.StartsWith($"Recipe: {selectedRecipe.RecipeName}"))
                    {
                        txtRecipeDisplay.Text = GetRecipeDisplayText(selectedRecipe);
                    }

                    // Refresh the list view to reflect any changes
                    lstRecipes.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.");
            }
        }

        //event handel to to reset quantities----------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = lstRecipes.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantities();
                MessageBox.Show("Quantities reset to original values.");
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.");
            }
        }

        //event handler to clear data------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = lstRecipes.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                recipes.Remove(selectedRecipe);
                MessageBox.Show("Recipe removed.");
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.");
            }
        }

        //event handler to add ingredient--------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateIngredientInput())
            {
                string ingredientName = txtIngredientName.Text;
                double quantity = double.Parse(txtQuantity.Text);
                string unit = txtUnit.Text;
                double calories = double.Parse(txtCalories.Text);
                string foodGroup = (cmbFoodGroup.SelectedItem as ComboBoxItem)?.Content.ToString();

                string ingredientInfo = $"{quantity} {unit} of {ingredientName} - {calories} calories, {foodGroup}";
                lstIngredients.Items.Add(ingredientInfo);

                
                txtIngredientName.Text = "";
                txtQuantity.Text = "";
                txtUnit.Text = "";
                txtCalories.Text = "";
                cmbFoodGroup.SelectedIndex = -1;
            }
        }

        private bool ValidateIngredientInput()
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtCalories.Text) ||
                cmbFoodGroup.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all ingredient fields.");
                return false;
            }

            if (!double.TryParse(txtQuantity.Text, out _) || !double.TryParse(txtCalories.Text, out _))
            {
                MessageBox.Show("Quantity and Calories must be numeric values.");
                return false;
            }

            return true;
        }

        //event handler to save recipe-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text) || lstIngredients.Items.Count == 0 || string.IsNullOrWhiteSpace(txtSteps.Text))
            {
                MessageBox.Show("Please enter a recipe name, at least one ingredient, and steps.");
                return;
            }

            Recipe newRecipe = new Recipe();
            newRecipe.RecipeName = txtRecipeName.Text;

            foreach (string ingredientInfo in lstIngredients.Items)
            {
                string[] parts = ingredientInfo.Split(new[] { " of ", " - ", ", " }, StringSplitOptions.None);
                newRecipe.ingredients.Add(parts[1]);
                newRecipe.quantities.Add(double.Parse(parts[0].Split(' ')[0]));
                newRecipe.units.Add(parts[0].Split(' ')[1]);
                newRecipe.calories.Add(double.Parse(parts[2].Split(' ')[0]));
                newRecipe.foodGroups.Add(parts[3]);
            }

            newRecipe.steps.AddRange(txtSteps.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            recipes.Add(newRecipe);

            
            txtRecipeName.Text = "";
            lstIngredients.Items.Clear();
            txtSteps.Text = "";
            txtIngredientName.Text = "";
            txtQuantity.Text = "";
            txtUnit.Text = "";
            txtCalories.Text = "";
            cmbFoodGroup.SelectedIndex = -1;

            MessageBox.Show("Recipe saved successfully.");
        }
    }
}
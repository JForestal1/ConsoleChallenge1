using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    class ProgramUI
    {
        public MenuItemsRepo _menu = new MenuItemsRepo();

        public void Run()
        {
            SeedMenu1();
            SeedMenu2();
 //           GetSingleMenuItem();
 //           GetSingleMenuItem();
            Console.WriteLine("+++++++++++++++++++++ Now Add \n");
            AddMenuItem();
            GetAllMenuItems();
        }

        // Seed A Menu Item
        private void SeedMenu1()
        {
            //create working instancies for all needed stuff
            var SeedItem1 = new MenuItems();
            List<Ingredients> _ingredientsToAdd = new List<Ingredients>();
            Ingredients ingredientToSeed = new Ingredients();

            // Set seed Menu item values
            SeedItem1.MenuItem = 1;
            SeedItem1.MenuName = "Donut";
            SeedItem1.Price = 1.25;
            SeedItem1.Description = "Baked Wonderland witha hole in the middle";

            // Set ingredients list for this seed item
            ingredientToSeed.Item = "Flour";
            ingredientToSeed.Quantity = 2;
            ingredientToSeed.Units = Ingredients.UnitTypes.cups;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed);

            // Add temporary list of ingredients to temporary menu item
            SeedItem1._ListOfIngredients = _ingredientsToAdd;

            // add this menu item to the menuItem list
            _menu.AddMenuItem(SeedItem1);
        }

        private void SeedMenu2()
        {
            //create working instancies for all needed stuff
            var SeedItem1 = new MenuItems();
            List<Ingredients> _ingredientsToAdd = new List<Ingredients>();
            Ingredients ingredientToSeed = new Ingredients();
            Ingredients ingredientToSeed2 = new Ingredients();

            // Set seed Menu item values
            SeedItem1.MenuItem = 2;
            SeedItem1.MenuName = "Waffle";
            SeedItem1.Price = 2.25;
            SeedItem1.Description = "Like a pancake but with tiny cups built in for syrup";

            // Set ingredients list for this seed item
            ingredientToSeed.Item = "batter";
            ingredientToSeed.Quantity = 3;
            ingredientToSeed.Units = Ingredients.UnitTypes.cups;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed);

            ingredientToSeed2.Item = "milk";
            ingredientToSeed2.Quantity = 1;
            ingredientToSeed2.Units = Ingredients.UnitTypes.tbsp;

            // Add this ingedient to the working list
            _ingredientsToAdd.Add(ingredientToSeed2);

            // Add temporary list of ingredients to temporary menu item
            SeedItem1._ListOfIngredients = _ingredientsToAdd;

            // add this menu item to the menuItem list
            _menu.AddMenuItem(SeedItem1);
        }

        // Get A Menu Item
        private void GetSingleMenuItem()
        {
            var menuItemToView = new MenuItems();
            Console.WriteLine("Enter a Menu Item to Review:");
            string nameOfMenuItemToView = Console.ReadLine();
            DisplayMenuItem(_menu.GetMenuItemByName(nameOfMenuItemToView));

        }
        private void GetAllMenuItems()
        {
            List<MenuItems> _ViewMenu = new List<MenuItems>();
            if (_menu.GetEntireMenu() != null)
            {
                _ViewMenu = _menu.GetEntireMenu();
                foreach (MenuItems allMenuItems in _ViewMenu)
                {
                    Console.WriteLine("----------------------------------------------------");
                    DisplayMenuItem(allMenuItems);
                }
            }
            else
                Console.WriteLine("No Menu items exist yet");
        }


 

        private void AddMenuItem()
        {
            // initatize stuff
            var newMenuItem = new MenuItems();
            bool active = true;
            string continueString;

            // start the input loop
            while (active)
            {
                newMenuItem = CollectMenuItemInput();
                Console.WriteLine("Do you wish to add ingredients to this item? (y/n)");
                continueString = Console.ReadLine();
                if (continueString.ToLower() == "y")
                {
                    newMenuItem._ListOfIngredients = CollectIngredientInput();
                }
                if (_menu.AddMenuItem(newMenuItem))
                {
                    Console.WriteLine("Item Added\n");
                }
                else
                {
                    Console.WriteLine("Item not added");
                }
                Console.WriteLine("\nDo you wish to add another item? (y/n)");
                continueString = Console.ReadLine();
                if (continueString.ToLower() != "y")
                {
                    active = false;
                }
            }
        }
        private void DisplayMenuItem(MenuItems itemToDisplay)
        {
            Console.WriteLine("Item Number: " + itemToDisplay.MenuItem);
            Console.WriteLine("Item Name: " + itemToDisplay.MenuName);
            Console.WriteLine("Item Description: " + itemToDisplay.Description);
            Console.WriteLine("Item price: " + itemToDisplay.Price);
            if (itemToDisplay._ListOfIngredients != null) 
                    foreach (Ingredients ingredientToDisplay in itemToDisplay._ListOfIngredients)
                    {
                        Console.WriteLine("Item Ingredient: " + ingredientToDisplay.Item);
                        Console.WriteLine("Item Ingredient quantity: " + ingredientToDisplay.Quantity);
                        Console.WriteLine("Item Ingredient Unit of Measurement: " + ingredientToDisplay.Units);
                    }
            else
            {
                Console.WriteLine("Item contains no ingredients yet");
            }
        }

        // helper UI for collecting Menu Item Input
        private MenuItems CollectMenuItemInput()
        {
            var newMenuItem = new MenuItems();
            Console.WriteLine("Enter the Menu Item Number:");
            newMenuItem.MenuItem = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Item Name");
            newMenuItem.MenuName = Console.ReadLine();
            Console.WriteLine("Enter Item Description:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter Item Price (without dollar sign):");
            newMenuItem.Price = Double.Parse(Console.ReadLine());
            return newMenuItem;
        }

        // helper UI for collecting Ingredient Item Input
        private List<Ingredients> CollectIngredientInput()
        {
            var newIngredient = new Ingredients();
            var _newListOfIngredients = new List<Ingredients>();
            string addMoreIngredientsString = "";
            bool addMore = true;
            while (addMore)
            {
                Console.WriteLine("\nEnter the Ingredient Name:");
                newIngredient.Item = Console.ReadLine();
                Console.WriteLine("Enter units of measurement:\n" +
                        "1) tbsp\n" +
                        "2) tsp\n" +
                        "3) cups\n" +
                        "4) quarts\n" +
                        "5) gallons");
                string unitOfMeasurementString = Console.ReadLine();

                switch (unitOfMeasurementString.ToLower())
                {
                    case "1":
                        {
                            newIngredient.Units = Ingredients.UnitTypes.tbsp;
                            break;
                        }
                    case "2":
                        {
                            newIngredient.Units = Ingredients.UnitTypes.tsp;
                            break;
                        }
                    case "3":
                        {
                            newIngredient.Units = Ingredients.UnitTypes.cups;
                            break;
                        }
                    case "4":
                        {
                            newIngredient.Units = Ingredients.UnitTypes.quarts;
                            break;
                        }
                    case "5":
                        {
                            newIngredient.Units = Ingredients.UnitTypes.gallons;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input. Defaulting to cups");
                            newIngredient.Units = Ingredients.UnitTypes.cups;
                            break;
                        }
                }
                Console.WriteLine("Enter the quantity of this ingredient:");
                newIngredient.Quantity = Int32.Parse(Console.ReadLine());
                _newListOfIngredients.Add(newIngredient);
                Console.WriteLine("\nDo you wish to add another ingredient to this menu item? (y/n)");
                addMoreIngredientsString = Console.ReadLine();
                if (addMoreIngredientsString.ToLower() == "n")
                {
                    addMore = false;
                }
            }
            return _newListOfIngredients;
        }
    }
}

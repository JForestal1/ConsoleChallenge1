using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    class IngredientsRepo
    {
        // instantiate list
        private List<Ingredients> _listOfIngredients = new List<Ingredients>();

        // method to read the list
        public List<Ingredients> GetIngredients()
        {
            return _listOfIngredients;
        }

        // add individual ingredient to the list
        public void AddIngredients (Ingredients newItem)
        {
            _listOfIngredients.Add(newItem);
        }

        // Update ingredients
        public bool UpdateExistingIngredients (string originalItem, Ingredients UpdatedIngredient)
        {
            Ingredients originalIngredient = GetIngredientByItem(originalItem);
            if (originalItem != null)
            {
                originalIngredient.Item = UpdatedIngredient.Item;
                originalIngredient.Quantity = UpdatedIngredient.Quantity;
                originalIngredient.Units = UpdatedIngredient.Units;
                return true;
            }
            else
                return false;
        }
         public bool RemoveIngredient(string originalItem)
        {
            Ingredients originalIngredient = GetIngredientByItem(originalItem);
            if (originalItem != null)
            {
                _listOfIngredients.Remove(originalIngredient);
                return true;
            }
            else
                return false;
        }


        // Get an individual ingredient by item name
        public Ingredients GetIngredientByItem (string itemToGet)
        {
            foreach (Ingredients ingredient in _listOfIngredients)
                if (ingredient.Item.ToLower() == itemToGet.ToLower())
                    return ingredient;
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChallenges
{
    class MenuItemsRepo
    {
        // Instantiate the list of menu items
        List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        // Get menu item
        public MenuItems GetMenuItemByName(string nameToGet)
        {
            foreach (MenuItems itemToSearchFor in _listOfMenuItems)
                if (itemToSearchFor.MenuName.ToLower() == nameToGet.ToLower())
                    return itemToSearchFor;
            return null;
        }

        // add menu item
        public bool AddMenuItem(MenuItems newItem)
        {
            int itemCountBeforeAdd = _listOfMenuItems.Count;
            _listOfMenuItems.Add(newItem);
            if (_listOfMenuItems.Count != itemCountBeforeAdd + 1)
                return false;
            else
                return true;
        }
        // delete menu item
        // update menu item
        // show all menu items
        public List<MenuItems> GetEntireMenu()
        {
            return _listOfMenuItems;
        }
    }
}

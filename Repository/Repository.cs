using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeOnePoco;

namespace ChallengeOneRepo
{
    public class Repository
    {
        private readonly List<MenuItems> _listOfItems = new List<MenuItems>();

        //Create
        public bool AddItemToList(MenuItems menuItems)
        {
            if (menuItems == null)
            {
                return false;
            }
            _listOfItems.Add(menuItems);
            return true;
        }
        //Read
        public List<MenuItems> ReadItemList()
        {
            return _listOfItems;
        }
        //Delete
        public bool DeleteItem(int mealNumber)
        {

            MenuItems items = GetItemByNumber(mealNumber);

            if (items == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(items);

            if (initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Methods
        public MenuItems GetItemByNumber(int mealNumber)
        {
            foreach (MenuItems items in _listOfItems)
            {
                if (items.MealNumber == mealNumber)
                {
                    return items;
                }
            }
            return null;
        }
        public MenuItems GetItemByName(string mealName)
        {
            foreach (MenuItems items in _listOfItems)
            {
                if (items.MealName == mealName)
                {
                    return items;
                }
            }
            return null;
        }
    }
}

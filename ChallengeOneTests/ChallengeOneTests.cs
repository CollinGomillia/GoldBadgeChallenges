using System.Collections.Generic;
using ChallengeOnePoco;
using ChallengeOneRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTests
{
    [TestClass]
    public class CafeUnitTest1
    {
        private readonly Repository _cafeRepo = new Repository();
        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            MenuItems items = new MenuItems("Soup Meal", 3, "A nice salty soup", "carrots,broth", 2.99);
            bool expected = true;

            //Act
            bool actual = _cafeRepo.AddItemToList(items);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            //Arrange
            MenuItems items = new MenuItems("Soup Meal", 3, "A nice salty soup", "carrots,broth", 2.99);
            _cafeRepo.AddItemToList(items);
            bool expected = true;
            //Act
            bool actual = _cafeRepo.DeleteItem(items.MealNumber);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestReadMethod()
        {
            //Arrange
            MenuItems items = new MenuItems("Soup Meal", 3, "A nice salty soup", "carrots,broth", 2.99);
            _cafeRepo.AddItemToList(items);
            //Act
            List<MenuItems> newList = _cafeRepo.ReadItemList();
            //Assert
            Assert.IsNotNull(newList);
        }
    }
}

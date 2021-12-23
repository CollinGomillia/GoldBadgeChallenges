using System;
using ChallengeThreePoco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeThreeRepo;
using System.Collections.Generic;

namespace ChallengeThreeTests
{
    [TestClass]
    public class BadgeTests
    {
        
        private readonly ThreeRepo _threeRepo = new ThreeRepo();

        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            BadgeItems badgeItems = new BadgeItems();
            bool expected = true;
            //Act
            bool actual = _threeRepo.CreateBadge(badgeItems);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestReadMethod()
        {
            //Arrange
            BadgeItems badgeItems = new BadgeItems(1, new List<string> { "a1" });
            _threeRepo.CreateBadge(badgeItems);
            //Act
            Dictionary<int, BadgeItems> newDiction = _threeRepo.ReadBadges();
            //Assert
            if (newDiction.ContainsKey(1))
                Console.WriteLine($"{newDiction}");
            else
                Console.WriteLine($"{null}");


                Assert.IsNotNull(newDiction);
            CollectionAssert.Contains(newDiction, badgeItems);

            //Assert.IsNotNull(newDiction);
            //CollectionAssert.Contains(newDiction, badgeItems);
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            //Arrange
            BadgeItems badgeItems = new BadgeItems(1, new List<string> { "a1"});
            _threeRepo.CreateBadge(badgeItems);
            List<string> newList = new List<string>();
            //create new list to update
            badgeItems.DoorNames = newList;
            //Act
            bool actual = _threeRepo.UpdateBadge(1, badgeItems);
            var actualList = badgeItems.DoorNames;
            //Assert
            Assert.AreEqual(newList, actualList);
            Assert.IsTrue(actual); 
        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            //Arrange
            BadgeItems badgeItems = new BadgeItems(1, new List<string> { "a1" });
            _threeRepo.CreateBadge(badgeItems);
            bool expected = true;
            //Act
            bool actual = _threeRepo.DeleteDoor(1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

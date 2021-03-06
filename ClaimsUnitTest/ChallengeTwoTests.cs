using System;
using System.Collections.Generic;
using ChallengeTwoPoco;
using ChallengeTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsUnitTest
{
    [TestClass]
    public class ChallengeTwoTests
    {
        private readonly Queue<ClaimItems> _claimItems = new Queue<ClaimItems>();
        private readonly TwoRepository _claimRepo = new TwoRepository();
        [TestMethod]
        public void TestCreateMethod()
        {
            //Arrange
            ClaimItems claimItems = new ClaimItems();
            bool expected = true;
            //Act
            bool actual = _claimRepo.CreateClaim(claimItems);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestReadMethod()
        {
            //Arrange
            ClaimItems claimItems = new ClaimItems();
            _claimRepo.CreateClaim(claimItems);
            //Act
            Queue<ClaimItems> newQueue = _claimRepo.ReadClaims();
            //Assert
            Assert.IsNotNull(newQueue);

            CollectionAssert.Contains(newQueue, claimItems);
        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            //Arrange
            ClaimItems claimItems = new ClaimItems();
            _claimRepo.CreateClaim(claimItems);
            bool expected = true;
            //Act
            bool actual = _claimRepo.DeleteClaims();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestNextMethod()
        {
            //Arrange
            ClaimItems claimItems = new ClaimItems();
            _claimRepo.CreateClaim(claimItems);
            var expected = claimItems;
            //Act
            var actual = _claimRepo.NextClaim();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

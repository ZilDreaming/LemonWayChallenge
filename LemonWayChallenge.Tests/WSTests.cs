using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonWayChallenge.Controllers;


namespace LemonWayChallenge.Tests
{
    [TestClass]
    public class WSTests
    {
        [TestMethod]
        public void TestFibonacci()
        {
            FibonacciController fibController = new FibonacciController();

            Assert.AreEqual(-1, fibController.Get(-10));
            Assert.AreEqual(-1, fibController.Get(1000));
            Assert.AreEqual(8, fibController.Get(6));
        }

        [TestMethod]
        public void TestToJson()
        {
            ToJsonController JsonControler = new ToJsonController();

            string xmlInvalid = "error<xml>floating text<subelement attribute=\"value\"></subelement><autoclose /></xml>";
            string xmlValid = "<xml>floating text<subelement attribute=\"value\"></subelement><autoclose /></xml>";

            Assert.AreEqual("Bad xml format", JsonControler.Post(xmlInvalid));
            Assert.AreNotEqual("Bad xml format", JsonControler.Post(xmlValid));
        }
    }
}

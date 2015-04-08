using System;
using Xunit;
using Moq;
using BuggerOff.Controllers;
using System.Collections.Generic;
using Data_Layer.Models;
using Data_Layer.Interfaces;
using System.Linq;
using System.Web;
using Data_Layer.Contexts;

namespace BuggerOff.Tests
{
    public class BugControllerTest
    {
		private List<Bug> bugList = new List<Bug>();
		private Bug testBug = new Bug { Description = "Test Bug", Fixed = false };
		private BugsController bugController;
        private Mock<BugContext> bugDb;

		public BugControllerTest()
		{
			bugList.Add(testBug);

            bugDb = new Mock<BugContext>();
			bugController = new BugsController(bugDb.Object);
		}

        [Fact]
        public void TestAll()
        {
            var allBugs = bugController.All();

            bugDb.VerifyGet(x => x.Bugs, Times.Once());
        }
    }
}
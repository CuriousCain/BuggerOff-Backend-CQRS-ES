using System;
using Xunit;
using Moq;
using BuggerOff.Controllers;
using System.Collections.Generic;
using Data_Layer.Models;
using System.Linq;
using System.Web;
using Data_Layer.Contexts;
using Data_Layer.Commands.Bug;

namespace BuggerOff.Tests
{
    public class BugControllerTest
    {
		private List<Bug> bugList = new List<Bug>();
		private Bug testBug = new Bug { Description = "Test Bug", Fixed = false };
		private BugsController bugController;
        private Mock<BugContext> bugDb;
		private Mock<IBugCommandHandler> commandHandler;

		public BugControllerTest()
		{
			bugList.Add(testBug);

            bugDb = new Mock<BugContext>();
			commandHandler = new Mock<IBugCommandHandler>();
			bugController = new BugsController(bugDb.Object, commandHandler.Object);
		}

        [Fact]
        public void TestAll()
        {
			commandHandler.Setup(x => x.Handle(It.IsAny<OpenBug>())).Verifiable();

			bugController.OpenBug(new Bug { Description = "Test Description" });

			commandHandler.VerifyAll();
        }
    }
}
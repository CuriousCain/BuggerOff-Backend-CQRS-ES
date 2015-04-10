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
		private Mock<ICommandHandler> commandHandler;

		public BugControllerTest()
		{
			bugList.Add(testBug);

            bugDb = new Mock<BugContext>();
			commandHandler = new Mock<ICommandHandler>();
			bugController = new BugsController(bugDb.Object, commandHandler.Object);
		}

        [Fact]
        public void TestOpenBug()
        {
			commandHandler.Setup(x => x.Handle(It.IsAny<OpenBug>())).Verifiable();

            bugController.OpenBug(new Bug { Description = "Test Description" });

			commandHandler.VerifyAll();
        }

        [Fact]
        public void TestCloseBug()
        {
            commandHandler.Setup(x => x.Handle(It.IsAny<CloseBug>())).Verifiable();

            bugController.CloseBug(1);

            commandHandler.VerifyAll();
        }

        [Fact]
        public void TestCloseMultipleBugs()
        {
            commandHandler.Setup(x => x.Handle(It.IsAny<CloseMultipleBugs>())).Verifiable();

            bugController.CloseMultipleBugs(new int[3]);

            commandHandler.VerifyAll();
        }
    }
}
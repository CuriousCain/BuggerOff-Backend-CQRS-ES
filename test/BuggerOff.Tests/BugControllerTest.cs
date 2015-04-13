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
using Data_Layer.Events;

namespace BuggerOff.Tests
{
    public class BugControllerTest
    {
		private List<Bug> bugList = new List<Bug>();
		private Bug testBug = new Bug { Description = "Test Bug", Fixed = false };
		private BugsController bugController;
        private Mock<BugContext> bugDb;
		private Mock<ICommandHandler> commandHandler;
		private Mock<IEventHandler> eventHandler;

		public BugControllerTest()
		{
			bugList.Add(testBug);

            bugDb = new Mock<BugContext>();
			commandHandler = new Mock<ICommandHandler>();
			eventHandler = new Mock<IEventHandler>();
			bugController = new BugsController(bugDb.Object, commandHandler.Object);
		}

        [Fact]
        public void TestOpenBug_CallsCommandHandler()
        {
			commandHandler.Setup(x => x.Handle(It.IsAny<OpenBug>())).Verifiable();

            bugController.OpenBug(new Bug { Description = "Test Description" });

			commandHandler.VerifyAll();
        }

        [Fact]
        public void TestCloseBug_CallsCommandHandler()
        {
            commandHandler.Setup(x => x.Handle(It.IsAny<CloseBug>())).Verifiable();

            bugController.CloseBug(1);

            commandHandler.VerifyAll();
        }

        [Fact]
        public void TestCloseMultipleBugs_CallsCommandHandler()
        {
            commandHandler.Setup(x => x.Handle(It.IsAny<CloseMultipleBugs>())).Verifiable();

            bugController.CloseMultipleBugs(new int[3]);

            commandHandler.VerifyAll();
        }
    }
}
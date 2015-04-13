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
using Data_Layer.Queries.Bug;

namespace BuggerOff.Tests
{
    public class BugControllerTest
    {
		private List<Bug> bugList = new List<Bug>();
		private Bug testBug = new Bug { Description = "Test Bug", Fixed = false };
		private BugsController bugController;
        private Mock<BugContext> bugDb;
		private Mock<ICommandHandler> commandHandler;
        private Mock<IQueryHandler> queryHandler;

		public BugControllerTest()
		{
			bugList.Add(testBug);

            bugDb = new Mock<BugContext>();
			commandHandler = new Mock<ICommandHandler>();
            queryHandler = new Mock<IQueryHandler>();
			bugController = new BugsController(bugDb.Object, commandHandler.Object, queryHandler.Object);
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

        [Fact]
        public void TestAll_CallsQueryHandler()
        {
            queryHandler.Setup(x => x.GetBugSummary()).Verifiable();

            bugController.All();

            queryHandler.VerifyAll();
        }

        [Fact]
        public void TestGetByID_CallsQueryHandler()
        {
            queryHandler.Setup(x => x.GetBugByID(It.IsAny<int>())).Verifiable();

            bugController.GetByID(1);

            queryHandler.VerifyAll();
        }
    }
}
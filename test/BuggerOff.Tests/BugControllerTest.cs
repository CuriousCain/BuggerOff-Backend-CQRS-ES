using System;
using Xunit;
using Moq;
using BuggerOff.Controllers;
using System.Collections.Generic;
using Data_Layer.Models;
using Data_Layer.Interfaces;
using System.Linq;
using System.Web;

namespace BuggerOff.Tests
{
    public class BugControllerTest
    {
		private List<Bug> bugList = new List<Bug>();
		private Bug testBug = new Bug { Description = "Test Bug", Fixed = false };
		private Mock<IBugRepository> repo;
		private BugsController bugController;
		private Mock<HttpRequestBase> mockRequest;

		public BugControllerTest()
		{
			bugList.Add(testBug);

			repo = new Mock<IBugRepository>();
			//bugController = new BugsController(repo.Object);
		}

		[Fact]
		public void AllBugs_returns_bug_list()
		{
			repo.Setup(x => x.AllBugs).Returns(bugList);

			var testBugList = bugController.GetAll();

			repo.Verify(x => x.AllBugs, Times.Once());
			Assert.True(testBugList == bugList);
		}

		[Fact]
		public void CreateBug_creates_bug()
		{
			repo.Setup(x => x.Add(It.IsAny<Bug>()));
			
			bugController.CreateBug(testBug);

			repo.Verify(x => x.Add(It.Is<Bug>(b => b == testBug)), Times.Once());
		}

		[Fact]
		public void GetByID_returns_correct_bug()
		{
			repo.Setup(x => x.AllBugs).Returns(bugList);

			bugController.GetByID(0);

			repo.Verify(x => x.GetByID(0), Times.Once());
		}
    }
}
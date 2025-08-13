using System.Threading.Tasks;
using CommBank.Controllers;
using CommBank.Models;
using CommBank.Services;
using Microsoft.AspNetCore.Http;
using Xunit;
using CommBank.Tests.Fake;


namespace CommBank.Tests
{
    public class GoalControllerTests
    {
       private readonly FakeCollections collections;
    public GoalControllerTests()
    {
        collections = new FakeCollections();
    }

    [Fact]
    public async Task GetForUser_ReturnsGoalsForUser()
    {
        var goals = collections.GetGoals();
        var users = collections.GetUsers();

        // Pass all goals and the first goal to the fake service
        IGoalsService goalsService = new FakeGoalsService(goals, goals[0]);
        // Pass all users and the first user to the fake service
        IUsersService usersService = new FakeUsersService(users, users[0]);

        var controller = new GoalController(goalsService, usersService);

        // Setup HttpContext for the controller (if needed)
        var httpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext();
        controller.ControllerContext.HttpContext = httpContext;

        // Act
        var result = await controller.GetForUser(goals[0].UserId!);

        // Assert
        Assert.NotNull(result);

        foreach (Goal goal in result!)
        {
            Assert.IsAssignableFrom<Goal>(goal);
            Assert.Equal(goals[0].UserId, goal.UserId);
        }
    }
    }
}

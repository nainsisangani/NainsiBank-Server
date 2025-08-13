using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommBank.Models;
using CommBank.Services;

namespace CommBank.Tests
{
    public class FakeGoalsService : IGoalsService
{
    private readonly List<Goal> _goals;

    public FakeGoalsService(List<Goal> goals, Goal goal)
    {
        _goals = goals;
    }

    public Task<Goal?> CreateAsync(Goal goal)
    {
        _goals.Add(goal);
        return Task.FromResult(goal);
    }

    public Task<List<Goal>?> GetAsync()
    {
        return Task.FromResult<List<Goal>?>(_goals);
    }

    public Task<Goal?> GetAsync(string id)
    {
        var goal = _goals.FirstOrDefault(g => g.Id == id);
        return Task.FromResult(goal);
    }

    public Task<bool> RemoveAsync(string id)
    {
        var goal = _goals.FirstOrDefault(g => g.Id == id);
        if (goal != null)
        {
            _goals.Remove(goal);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<Goal?> UpdateAsync(string id, Goal updatedGoal)
    {
        var index = _goals.FindIndex(g => g.Id == id);
        if (index >= 0)
        {
            _goals[index] = updatedGoal;
            return Task.FromResult(updatedGoal);
        }
        return Task.FromResult<Goal?>(null);
    }

    public Task<List<Goal>?> GetForUserAsync(string userId)
    {
        var filteredGoals = _goals.Where(g => g.UserId == userId).ToList();
        return Task.FromResult<List<Goal>?>(filteredGoals);
    }

        Task IGoalsService.CreateAsync(Goal newGoal)
        {
            return CreateAsync(newGoal);
        }

        Task IGoalsService.RemoveAsync(string id)
        {
            return RemoveAsync(id);
        }

        Task IGoalsService.UpdateAsync(string id, Goal updatedGoal)
        {
            return UpdateAsync(id, updatedGoal);
        }
    }

}

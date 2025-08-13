using CommBank.Models;
using CommBank.Tests;

namespace CommBank.Tests.Fake
{
    public class FakeCollections
    {
        List<Account> accounts;
        List<Goal> goals;
        List<Tag> tags;
        List<Transaction> transactions;
        List<User> users;


        public FakeCollections()
        {
            accounts = new()
            {
                new()
                {
                    Id = "1",
                    Name = "Tag's GoalSaver"
                },

                new()
                {
                    Id = "2",
                    Name = "Trot's GoalSaver"
                }
            };

            goals = new()
            {
                new()
               {
                    Id = "64d2b4f5e42f5d6f8b5d9c21",
                    Name = "Buy a Car",
                    TargetAmount = 15000,
                    TargetDate = DateTime.Now.AddMonths(12),
                    Balance = 3000,
                    Created = DateTime.Now.AddMonths(-3),
                    TransactionIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c31" },
                    TagIds = new List<string> { "tag1", "tag2" },
                    UserId = "64d2b4f5e42f5d6f8b5d9c01",
                    Icon = "car"
                },
                new()
                {
                    Id = "64d2b4f5e42f5d6f8b5d9c22",
                    Name = "Vacation Fund",
                    TargetAmount = 5000,
                    TargetDate = DateTime.Now.AddMonths(6),
                    Balance = 1500,
                    Created = DateTime.Now.AddMonths(-5),
                    TransactionIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c32" },
                    TagIds = new List<string> { "tag3" },
                    UserId = "64d2b4f5e42f5d6f8b5d9c01",
                    Icon = "vacation"
                },
                new()
                {
                    Id = "64d2b4f5e42f5d6f8b5d9c23",
                    Name = "New Laptop",
                    TargetAmount = 2000,
                    TargetDate = DateTime.Now.AddMonths(4),
                    Balance = 500,
                    Created = DateTime.Now.AddMonths(-2),
                    TransactionIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c33" },
                    TagIds = new List<string> { "tag4" },
                    UserId = "64d2b4f5e42f5d6f8b5d9c02",
                    Icon = "laptop"
                }
            };

            tags = new()
            {
                new()
                {
                    Id = "1"
                },

                new()
                {
                    Id = "2"
                }
            };

            transactions = new()
            {
                new()
                {
                    Id = "1"
                },

                new()
                {
                    Id = "2"
                }
            };

            users = new()
            {
                new()
                {
                    Id = "64d2b4f5e42f5d6f8b5d9c01",
                    Name = "j j",
                    Email = "r@gmail.com",
                    Password = "password123",
                    AccountIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c11" },
                    GoalIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c21", "64d2b4f5e42f5d6f8b5d9c22" },
                    TransactionIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c31", "64d2b4f5e42f5d6f8b5d9c32" }
                },
                new()
                {
                    Id = "64d2b4f5e42f5d6f8b5d9c02",
                    Name = "n n",
                    Email = "n@gmail.com",
                    Password = "password456",
                    AccountIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c12" },
                    GoalIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c23" },
                    TransactionIds = new List<string> { "64d2b4f5e42f5d6f8b5d9c33" }
                }
            };
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public List<Goal> GetGoals()
        {
            return goals;
        }

        public List<Tag> GetTags()
        {
            return tags;
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
using NUnit.Framework;
using Assignment03;
using Assignment03.Utility;
using System.IO;

namespace Assignment03Tests
{
    public class UnitTest1
    {
        private SLL users;

        [SetUp]
        public void Setup()
        {
            users = new SLL();
            users.AddLast(new User(1, "Alice", "alice@example.com", "password"));
            users.AddLast(new User(2, "Bob", "bob@example.com", "1234"));
        }

        [Test]
        public void Test_AddFirst()
        {
            users.AddFirst(new User(0, "Zara", "zara@example.com", "secure123"));
            Assert.AreEqual(0, users.GetValue(0).Id);
            Assert.AreEqual("Zara", users.GetValue(0).Name);
        }

        [Test]
        public void Test_AddLast()
        {
            users.AddLast(new User(3, "Charlie", "charlie@example.com", "pass567"));
            Assert.AreEqual(3, users.GetValue(users.Count() - 1).Id);
            Assert.AreEqual("Charlie", users.GetValue(users.Count() - 1).Name);
        }

        [Test]
        public void Test_IsEmpty()
        {
            SLL emptyList = new SLL();
            Assert.IsTrue(emptyList.IsEmpty());
            emptyList.AddFirst(new User(1, "Test", "test@example.com", "test123"));
            Assert.IsFalse(emptyList.IsEmpty());
        }

        [Test]
        public void Test_Remove()
        {
            users.Remove(1); // Remove the second user (Bob)
            Assert.AreEqual(1, users.Count());
            Assert.AreEqual("Alice", users.GetValue(0).Name);
        }

        [Test]
        public void Test_Reverse()
        {
            users.Reverse();
            Assert.AreEqual("Bob", users.GetValue(0).Name);
            Assert.AreEqual("Alice", users.GetValue(1).Name);
        }
    }
}

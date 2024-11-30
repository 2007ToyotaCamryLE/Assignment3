using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private SLL list;

        [SetUp]
        public void SetUp() { list = new SLL(); }

        [Test]
        public void IsEmpty_NewList_ReturnsTrue()
        {
            var list = new SLL();
            Assert.IsTrue(list.IsEmpty());
        }
        [Test]
        public void AddFirst_AddsItemAtTheBeginning()
        {
            var list = new SLL();
            var user = new User(1, "Test User", "test@example.com", "password");
            list.AddFirst(user);
            Assert.AreEqual(user, list.GetValue(0));
        }
        [Test]
        public void AddLast_AddsItemAtTheEnd()
        {
            var list = new SLL();
            var user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);
            Assert.AreEqual(user, list.GetValue(list.Count() - 1));
        }
        [Test]
        public void Add_InsertsItemAtSpecificIndex()
        {
            var list = new SLL();
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            list.AddLast(user1);
            list.Add(user2, 0);
            Assert.AreEqual(user2, list.GetValue(0));
        }
        [Test]
        public void Replace_ReplacesItemAtSpecificIndex()
        {
            var list = new SLL();
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            list.AddLast(user1);
            list.Replace(user2, 0);
            Assert.AreEqual(user2, list.GetValue(0));
        }
        [Test]
        public void RemoveFirst_RemovesFirstItem()
        {
            // Arrange
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            list.RemoveFirst();

            // Assert
            Assert.AreEqual(user2, list.GetValue(0));
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void RemoveLast_RemovesLastItem()
        {
            // Arrange
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            list.RemoveLast();

            // Assert
            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void Remove_RemovesItemFromMiddle()
        {
            // Arrange
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            var user3 = new User(3, "Test User 3", "user3@example.com", "password3");
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            // Act
            list.Remove(1); // Remove the second item

            // Assert
            Assert.AreEqual(user1, list.GetValue(0));
            Assert.AreEqual(user3, list.GetValue(1));
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void GetValue_RetrievesItemByIndex()
        {
            // Arrange
            var user = new User(1, "Test User", "test@example.com", "password");
            list.AddLast(user);

            // Act
            User result = list.GetValue(0);

            // Assert
            Assert.AreEqual(user, result);
        }

        [Test]
        public void Reverse_ReversesTheList()
        {
            // Arrange
            var user1 = new User(1, "Test User 1", "user1@example.com", "password1");
            var user2 = new User(2, "Test User 2", "user2@example.com", "password2");
            list.AddLast(user1);
            list.AddLast(user2);

            // Act
            list.Reverse();

            // Assert
            Assert.AreEqual(user2, list.GetValue(0));
            Assert.AreEqual(user1, list.GetValue(1));
        }


    }
}

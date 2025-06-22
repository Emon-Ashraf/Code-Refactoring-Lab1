
using Xunit;
using PersonalFinanceManagement;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class PasswordHashingTests
    {
        /*
        ISSUE #3 – Primitive Obsession in Password Handling

        The reasons I think is this code flawed?
        - Passwords are stored and passed as raw `string` types.
        - The hashing logic is hidden inside the `User` class.
        - Password-related logic should ideally be encapsulated in a reusable structure or service.

        What this test checks:
        -> Whether two identical passwords produce the same hash.
        -> Whether different passwords produce different hashes.
        -> Ensures password is hashed properly (not stored in plain text).
        */

        [Fact]
        public void HashPassword_SameInput_ReturnsSameHash()
        {
            // Arrange
            var user1 = new User("A", "a@email.com", "secure123");
            var user2 = new User("B", "b@email.com", "secure123");

            // Act
            string hash1 = user1.PasswordHash;
            string hash2 = user2.PasswordHash;

            // Assert
            Assert.Equal(hash1, hash2); // Same password => same hash
        }

        [Fact]
        public void HashPassword_DifferentInput_ReturnsDifferentHash()
        {
            // Arrange
            var user1 = new User("A", "a@email.com", "secure123");
            var user2 = new User("B", "b@email.com", "diff456");

            // Act
            string hash1 = user1.PasswordHash;
            string hash2 = user2.PasswordHash;

            // Assert
            Assert.NotEqual(hash1, hash2); // Different password => different hash
        }

        [Fact]
        public void Password_IsHashed_NotStoredAsPlainText()
        {
            // Arrange
            var password = "mySuperSecret";
            var user = new User("C", "c@email.com", password);

            // Act
            string stored = user.PasswordHash;

            // Assert
            Assert.NotEqual(password, stored); // Password should not be stored directly
            Assert.True(stored.Length > 10);   // Sanity check: hash looks like a hash
        }
    }
}

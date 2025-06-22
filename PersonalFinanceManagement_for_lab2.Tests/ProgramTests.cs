using Xunit;
using PersonalFinanceManagement;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TryAuthenticate_ValidCredentials_ReturnsUser()
        {
            // Test for Issue #1: Verifying correct login
            // This test checks if the TryAuthenticate method returns a User object when valid email and password are provided.

            var testUser = new User("TestUser", "test@example.com", "1234");
            Storage.users.Clear();
            Storage.users.Add(testUser);

            var result = Program.TryAuthenticate("test@example.com", "1234");

            Assert.NotNull(result);
            Assert.Equal("TestUser", result.Name);
        }

        [Fact]
        public void TryAuthenticate_InvalidPassword_ReturnsNull()
        {
            // Test for Issue #1: Verifying incorrect password
            // This test checks if TryAuthenticate returns null when the password is wrong.

            var testUser = new User("TestUser", "test@example.com", "1234");
            Storage.users.Clear();
            Storage.users.Add(testUser);

            var result = Program.TryAuthenticate("test@example.com", "wrong");

            Assert.Null(result);
        }

        [Fact]
        public void TryAuthenticate_NonExistingEmail_ReturnsNull()
        {
            // Test for Issue #1: Non-existing user
            // This test checks if TryAuthenticate returns null when the email doesn't exist.

            Storage.users.Clear();

            var result = Program.TryAuthenticate("nonexistent@example.com", "1234");

            Assert.Null(result);
        }
    }
}

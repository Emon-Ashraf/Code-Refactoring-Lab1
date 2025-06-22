using System;
using System.IO;
using Xunit;
using PersonalFinanceManagement;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class ConsoleInputHelperTests
    {
        // ❌ Issue: Long Method in Log_in (Flaw #1 in Lab 1)
        // This test checks input parsing is correct and returns a valid integer.
        // Example: user enters "3", the method returns 3.
        [Fact]
        public void ReadInt_ValidInput_ReturnsCorrectInteger()
        {
            // Arrange
            var input = new StringReader("3");
            Console.SetIn(input);

            // Act
            int result = ConsoleInputHelper.ReadInt("Enter: ");

            // Assert
            Assert.Equal(3, result);
        }

        // ❌ Issue: Long Method in Log_in (Flaw #1 in Lab 1)
        // This test checks that the helper rejects invalid input and re-prompts until valid.
        // Example: user enters "abc" then "5", should return 5.
        [Fact]
        public void ReadInt_InvalidThenValidInput_ReturnsValidInteger()
        {
            // Arrange
            var input = new StringReader("abc\n5");
            Console.SetIn(input);

            // Act
            int result = ConsoleInputHelper.ReadInt("Enter: ");

            // Assert
            Assert.Equal(5, result);
        }

        // ❌ Issue: Long Method in Log_in (Flaw #1 in Lab 1)
        // This test ensures the helper can read valid double input.
        // Example: user enters "12.5", method returns 12.5.
        [Fact]
        public void ReadDouble_ValidInput_ReturnsCorrectDouble()
        {
            // Arrange
            var input = new StringReader("12.5");
            Console.SetIn(input);

            // Act
            double result = ConsoleInputHelper.ReadDouble("Enter: ");

            // Assert
            Assert.Equal(12.5, result);
        }

        // ❌ Issue: Long Method in Log_in (Flaw #1 in Lab 1)
        // This test checks that the helper prompts again after invalid input.
        // Example: user enters "wrong" then "7.7", should return 7.7.
        [Fact]
        public void ReadDouble_InvalidThenValid_ReturnsCorrect()
        {
            // Arrange
            var input = new StringReader("wrong\n7.7");
            Console.SetIn(input);

            // Act
            double result = ConsoleInputHelper.ReadDouble("Enter: ");

            // Assert
            Assert.Equal(7.7, result);
        }

        // ❌ Issue: Long Method in Log_in (Flaw #1 in Lab 1)
        // This test ensures ReadString returns the typed string.
        // Example: user types "wallet1", the method returns "wallet1".
        [Fact]
        public void ReadString_ReturnsInputString()
        {
            // Arrange
            var input = new StringReader("wallet1");
            Console.SetIn(input);

            // Act
            string result = ConsoleInputHelper.ReadString("Enter name: ");

            // Assert
            Assert.Equal("wallet1", result);
        }
    }
}

using Xunit;
using PersonalFinanceManagement;
using System;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class WalletTests
    {
        [Fact]
        // This test ensures that AddIncome correctly increases wallet balance when given valid input.
        // Example: Adding $100 as salary should increase balance by 100.
        public void AddIncome_ValidInput_IncreasesBalance()
        {
            var wallet = new Wallet("TestWallet", Currency.USD);
            double initialBalance = wallet.TotalBalance;

            wallet.AddIncome((int)IncomeType.Salary, 100, "Monthly salary");

            Assert.Equal(initialBalance + 100, wallet.TotalBalance);
        }

        [Fact]
        // This test verifies AddIncome throws exception for negative income value.
        // Example: Adding -50 should throw.
        public void AddIncome_NegativeAmount_ThrowsArgumentException()
        {
            var wallet = new Wallet("TestWallet", Currency.EUR);

            Assert.Throws<ArgumentException>(() =>
                wallet.AddIncome((int)IncomeType.Gift, -50, "Invalid amount")
            );
        }

        [Fact]
        // This test ensures AddIncome throws exception when description is null or empty.
        // Example: Description "" is not allowed.
        public void AddIncome_EmptyDescription_ThrowsArgumentException()
        {
            var wallet = new Wallet("TestWallet", Currency.RUB);

            Assert.Throws<ArgumentException>(() =>
                wallet.AddIncome((int)IncomeType.Other, 25, "")
            );
        }
    }
}

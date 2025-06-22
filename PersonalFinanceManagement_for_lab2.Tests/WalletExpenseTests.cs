using System;
using Xunit;
using PersonalFinanceManagement;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class WalletExpenseTests
    {
        // ❌ Issue: Long Method (Flaw #1 from Lab 1)
        // This test checks if AddExpense properly reduces wallet balance.
        // Example: starting at $0, adding $50 expense results in -50 total expense.
        [Fact]
        public void AddExpense_ValidInput_AddsExpense()
        {
            var wallet = new Wallet("TestWallet", Currency.USD);
            wallet.AddExpense((int)ExpenseType.Food, 50, "Lunch");

            double totalExpense = wallet.CalculateTotalExpense();

            Assert.Equal(50, totalExpense);
        }

        // ❌ Issue: Long Method (Flaw #1 from Lab 1)
        // This test ensures AddExpense throws an exception for negative amount.
        // Example: user tries to add -100, should throw ArgumentException.
        [Fact]
        public void AddExpense_NegativeAmount_ThrowsException()
        {
            var wallet = new Wallet("TestWallet", Currency.EUR);

            Assert.Throws<ArgumentException>(() =>
                wallet.AddExpense((int)ExpenseType.Medicine, -100, "Invalid Expense")
            );
        }

        // ❌ Issue: Long Method (Flaw #1 from Lab 1)
        // This test checks that AddExpense throws for an empty description.
        // Example: adding 25 with "" description should throw.
        [Fact]
        public void AddExpense_EmptyDescription_ThrowsException()
        {
            var wallet = new Wallet("TestWallet", Currency.RUB);

            Assert.Throws<ArgumentException>(() =>
                wallet.AddExpense((int)ExpenseType.Fun, 25, "")
            );
        }
    }
}

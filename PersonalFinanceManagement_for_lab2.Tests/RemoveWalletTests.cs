using System;
using System.Collections.Generic;
using Xunit;
using PersonalFinanceManagement;

namespace PersonalFinanceManagement_for_lab2.Tests
{
    public class RemoveWalletTests
    {
        // ❌ Issue: Missing Validation in RemoveWallet (Flaw #5 in Lab 1)
        // This test ensures that a wallet is successfully removed if it exists.
        // Example: Add wallet "FoodWallet", remove it, list should be empty.
        [Fact]
        public void RemoveWallet_ExistingWallet_RemovesSuccessfully()
        {
            var user = new User("Test", "test@test.com", "1234");
            var wallet = new Wallet("FoodWallet", Currency.USD);
            user.AddWallet(wallet);

            user.RemoveWallet(wallet);

            Assert.DoesNotContain(wallet, user.GetWallets());
        }

        // ❌ Issue: Missing Validation in RemoveWallet (Flaw #5 in Lab 1)
        // This test checks that removing a wallet not in the list does nothing.
        // Example: Add "Main", then try removing a different "Ghost" wallet.
        [Fact]
        public void RemoveWallet_NonExistingWallet_DoesNothing()
        {
            var user = new User("Test", "test@test.com", "1234");
            var wallet1 = new Wallet("Main", Currency.EUR);
            var wallet2 = new Wallet("Ghost", Currency.EUR); // never added

            user.AddWallet(wallet1);
            user.RemoveWallet(wallet2); // Should do nothing

            Assert.Single(user.GetWallets());
            Assert.Contains(wallet1, user.GetWallets());
        }

        // ❌ Issue: Missing Null Check in RemoveWallet (Flaw #5 in Lab 1)
        // This test ensures that calling RemoveWallet(null) is safely handled.
        // Example: user.RemoveWallet(null) should not crash.
        [Fact]
        public void RemoveWallet_NullInput_HandledGracefully()
        {
            var user = new User("Test", "test@test.com", "1234");

            Exception ex = Record.Exception(() => user.RemoveWallet((Wallet)null));

            Assert.Null(ex); // no crash
        }

    }
}

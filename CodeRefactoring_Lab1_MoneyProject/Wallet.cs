using System;
using System.Collections.Generic;

namespace PersonalFinanceManagement
{
    public enum IncomeType
    {
        Salary,
        Scholarship,
        Other
    }

    public enum ExpenseType
    {
        Food,
        Restaurants,
        Medicine,
        Sport,
        Taxi,
        Rent,
        Investments,
        Clothes,
        Fun,
        Other
    }

    public class IncomeTransaction : Operation
    {
        public IncomeType IncomeCategory { get; set; }

        public override string Category => throw new NotImplementedException();
        // Other properties in the IncomeTransaction class...
    }

    public class ExpenseTransaction : Operation
    {
        public ExpenseType ExpenseCategory { get; set; }

        public override string Category => throw new NotImplementedException();
        // Other properties in the ExpenseTransaction class...
    }

    public class Wallet
    {
        public string Name { get; set; }
        private List<Operation> operations;
        public Currency Currency { get; private set; } // Add Currency property

        public Wallet(string name, Currency currency, double startingAmount = 0)
        {
            Name = name;
            Currency = currency;
            operations = new List<Operation>();

            if (startingAmount > 0)
            {
                // Create an initial income transaction for the starting amount
                IncomeTransaction initialIncome = new IncomeTransaction
                {
                    DateTime = DateTime.Now,
                    Amount = startingAmount,
                    Money = new Money { Amount = startingAmount, Currency = currency },
                    Description = "Initial balance",
                    IncomeCategory = IncomeType.Other // You can set a specific category for initial balance if needed
                };

                operations.Add(initialIncome);
            }
        }

        public void AddOperation(Operation operation)
        {
            operations.Add(operation);
        }

        public List<Operation> GetOperationsByDateRange(DateTime fromDate, DateTime toDate)
        {
            return operations.FindAll(op => op.DateTime >= fromDate && op.DateTime <= toDate);
        }

        public void AddIncome(int incomeType, double money, string text)
        {
            if (money <= 0)
            {
                money = 0.01;
            }

            IncomeTransaction it = new IncomeTransaction();
            it.Amount = money;
            it.Money = new Money { Amount = money, Currency = Currency };
            it.Description = text;
            it.DateTime = DateTime.Now;
            it.IncomeCategory = (IncomeType)incomeType;
            operations.Add(it);
        }

        public void AddExpense(int expenseType, double money, string text)
        {
            if (money <= 0)
            {
                money = 0.01;
            }

            ExpenseTransaction et = new ExpenseTransaction();
            et.Amount = money;
            et.Money = new Money { Amount = money, Currency = Currency };
            et.Description = text;
            et.DateTime = DateTime.Now;
            et.ExpenseCategory = (ExpenseType)expenseType;
            operations.Add(et);
        }


        public string ViewWalletDetails()
        {
            return $"Wallet: {Name}\nCurrency: {Currency}\nOperations Count: {operations.Count}";
        }

        public double CalculateTotalIncome()
        {
            double totalIncome = 0;
            foreach (var op in operations)
            {
                if (op is IncomeTransaction income)
                {
                    totalIncome += income.Money.Amount;
                }
            }
            return totalIncome;
        }

        public double CalculateTotalExpense()
        {
            double totalExpense = 0;
            foreach (var op in operations)
            {
                if (op is ExpenseTransaction expense)
                {
                    totalExpense += expense.Money.Amount;
                }
            }
            return totalExpense;
        }

        public string GetStatistics(DateTime startDate, DateTime endDate)
        {
            var operationsWithinRange = operations.Where(op => op.DateTime >= startDate && op.DateTime <= endDate).ToList();

            // Calculate total income and total expense within the date range
            double totalIncome = operationsWithinRange.OfType<IncomeTransaction>().Sum(income => income.Amount);
            double totalExpense = operationsWithinRange.OfType<ExpenseTransaction>().Sum(expense => expense.Amount);

            // Additional statistical calculations (e.g., average, highest expense/income)...
            // For example:
            double averageIncome = totalIncome / operationsWithinRange.OfType<IncomeTransaction>().Count();
            double highestExpense = operationsWithinRange.OfType<ExpenseTransaction>().Max(expense => expense.Amount);

            // Construct the statistics report
            string statisticsReport = $"Statistics for {Name} from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}:\n";
            statisticsReport += $"Total Income: {totalIncome}\n";
            statisticsReport += $"Total Expense: {totalExpense}\n";
            statisticsReport += $"Average Income: {averageIncome}\n";
            statisticsReport += $"Highest Expense: {highestExpense}\n";
            // Add more statistics or calculations as needed...

            return statisticsReport;
        }

    }
}

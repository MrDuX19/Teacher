using System;

class BankAccount
{
    public string Owner { get; }
    private decimal Balance { get; set; }

    public BankAccount(string owner, decimal balance = 0)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance is ${Balance}.");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance is ${Balance}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds or invalid withdrawal amount.");
        }
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public override string ToString()
    {
        return $"Account owner: {Owner}\nAccount balance: ${Balance}";
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount("John Doe", 1000);
        Console.WriteLine(account);
        account.Deposit(500);
        account.Withdraw(200);
        Console.WriteLine(account);
    }
}


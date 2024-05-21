class Account
{
    public int AccountId { get; set; }
    public float Balance { get; set; }
    public bool IsSpecial { get; set; }
    public float Limit { get; set; }
    public List<string> TransactionHistory { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Cpf { get; set; }

    // Constructor to initialize TransactionHistory, without this, we can't add strings to the List
    public Account()
    {
        TransactionHistory = new List<string>();
    }

    public delegate void AccountOperation(float value);

    public void CheckBalance()
    {
        Console.WriteLine($"Your account balance is: {Balance}");
    }

    public void Deposit(float value)
    {
        this.Balance += value;
        // How exactly does this Deposit argument work?
        this.RegisterHistory(Deposit, value);
    }

    public void Withdraw(float value)
    {
        if (this.Balance + Limit >= value)
        {
            this.Balance -= value;
            this.RegisterHistory(Withdraw, value);
        }
        else
        {
            Console.WriteLine("This withdraw is not possible!");
        }
    }

    public void Transfer(Account sender, Account receiver, float value)
    {
        if (sender.Balance >= value)
        {
            Console.WriteLine(sender.Balance);
            Console.WriteLine(receiver.Balance);
            sender.Balance -= value;
            receiver.Balance += value;
            Console.WriteLine("\n");
            Console.WriteLine(sender.Balance);
            Console.WriteLine(receiver.Balance);


        }
        else
        {
            Console.WriteLine("The sender does not have enough balance to perform this operation");
        }
    }

    public void RegisterHistory(AccountOperation operation, float value)
    {
        Console.WriteLine($"Registered operation: {operation.Method.Name} with value: {value}\n");
        string transaction = "Operation type: " + operation.Method.Name + "\n" + "Value: " + value.ToString();
        this.TransactionHistory.Add(transaction);
    }

    public void ShowHistory()
    {
        if (this.TransactionHistory.Count > 0)
        {
            Console.WriteLine("Your transaction history: ");
            for (int i = 0; i < this.TransactionHistory.Count; i++)
            {
                Console.WriteLine(this.TransactionHistory[i]);
                Console.Write("\n");
            }
        }
        else
        {
            Console.WriteLine("No transactions found in your history.");
        }
    }


}

class Program
{
    static void Main(string[] args)
    {
        Account AccountOne = new Account();
        Account AccountTwo = new Account();
        // First scenario  
        //AccountOne.Balance = 1000;
        //AccountOne.Limit = 500;
        //AccountOne.Withdraw(400);
        //AccountOne.CheckBalance();

        // Second scenario
        //AccountOne.Balance = 1000;
        //AccountOne.Limit = 500;
        //AccountOne.Withdraw(1500);
        //AccountOne.CheckBalance();

        // Third scenario, does it need an special account?


        // Fourth scenario  
        //AccountOne.Balance = 1000;
        //AccountOne.Deposit(500);
        //AccountOne.CheckBalance();

        // Fifth scenario
        //AccountOne.Balance = 1000;
        //AccountOne.CheckBalance();

        // Sixth scenario
        //AccountOne.Balance = 1000;
        //AccountTwo.Balance = 500;
        //AccountOne.Transfer(AccountOne, AccountTwo, 300);
        //AccountOne.CheckBalance();
        //AccountTwo.CheckBalance();




        //Account AccountTwo = new Account();
        //AccountTwo.Limit = 5000;

        //AccountOne.Transfer(AccountOne, AccountTwo, 500);
    }

}

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
        this.RegisterHistory(Deposit, value);
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
        AccountOne.Balance = 1000;
        AccountOne.CheckBalance();
        AccountOne.Deposit(2000);
        AccountOne.Deposit(3000);
        AccountOne.Deposit(3000);
        AccountOne.Deposit(3000);
        AccountOne.Deposit(3000);
        AccountOne.ShowHistory();

    }
}

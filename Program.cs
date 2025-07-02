Account checking = new(10)
{
    Transactions = [
        new Transaction(10),
        new Transaction(5),
        new Transaction(-2),
    ]
};

Console.WriteLine(checking.GetBalance());

public record Transaction(Decimal Amount);
public class Account
{
    public Decimal InitialBalance;
    public List<Transaction> Transactions = [];

    public Account(Decimal initialBalance)
    {
        InitialBalance = initialBalance;
    }

    public Decimal GetBalance()
    {
        return InitialBalance + Transactions.Sum((t) => t.Amount);
    }
}


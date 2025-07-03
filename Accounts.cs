public record Transaction(Decimal Amount);
public class Account
{
    public string Name = "";
    public Decimal InitialBalance = 0;
    public List<Transaction> Transactions = [];

    public Account(string name)
    {
        Name = name;
    }

    public Decimal GetBalance() => InitialBalance + Transactions.Sum((t) => t.Amount);

    public void ApplyTransaction(params Transaction[] newTransactions)
    {
        Transactions.AddRange(newTransactions);
    }
}

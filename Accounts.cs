public record Transaction(Decimal Amount);
public class Account
{
    public Decimal InitialBalance;
    public List<Transaction> Transactions = [];

    public Account(Decimal initialBalance)
    {
        InitialBalance = initialBalance;
    }

    public Decimal GetBalance() => InitialBalance + Transactions.Sum((t) => t.Amount);

    public void ApplyTransaction(params Transaction[] newTransactions)
    {
        Transactions.AddRange(newTransactions);
    }
}

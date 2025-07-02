Account checking = new(10)
{
    Transactions = [
        new Transaction(10),
        new Transaction(5),
    ]
};

Console.WriteLine(checking.GetBalance());

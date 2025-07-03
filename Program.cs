// ------------
// INIT
// ------------
Console.Clear();
Console.CancelKeyPress += (source, e) => { };
// ------------

// ------------
// MAIN LOOP 
// ------------
while (true)
{
    Console.Write("> ");

    string[] input = Console.ReadLine()?.Split(" ") ?? [];
    if (input.Count() == 0)
    {
        Console.WriteLine("No command provided.");
        continue;
    }

    string command = input[0];
    switch (command)
    {
        case "help":
            Console.Write("""
                Execute a command.

                Commands:
                    account-add <name> [options] 

                Command Options:
                    -h|--help   Show command help

                """);
            break;
        case "account-add":
            if (input.Count() > 0 && new[] { "-h", "--help" }.Contains(input[1]))
            {
                Console.Write("""
                        Description:
                            Create an account.

                        Arguments:
                            <name>  The account's name 

                        Options:
                            -h|--help               Show command help
                            -i|--initial-balance    The account's initial balance 

                    """);
                break;
            }

            if (input.Count() < 1 || CLI.isArgFlag(input[1]))
            {
                Console.WriteLine("No account name provided.");
                break;
            }

            string accountName = input[1];

            List<CLI.Option> options = CLI.Parse.Options(input[2..]);

            Account account = new(accountName);

            if (options.Count() > 0)
            {
                // COMMAND LOGIC
                foreach (CLI.Option option in options)
                {
                    switch (option.Name)
                    {
                        case "--initial-balance":
                        case "-i":
                            break;
                    }
                }
            }
            break;
        case "q":
            return;
        default:
            Console.WriteLine("Unknown command");
            break;
    }
}
// ------------

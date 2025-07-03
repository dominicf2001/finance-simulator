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
                    account-add <name> [options]    Create an account. 
                    quit                            Quit the program.

                Command Options:
                    -h|--help   Show command help.

                """);
            break;
        case "account-add":
            // HELP
            if (input.Count() > 0 && new[] { "-h", "--help" }.Contains(input[1]))
            {
                Console.Write("""
                        Description:
                            Create an account.

                        Usage:
                            account-add <name> [options]

                        Arguments:
                            <name>  The account's name.

                        Options:
                            -h|--help               Show command help.
                            -i|--initial-balance    The account's initial balance. 

                    """);
                break;
            }

            // ARGUMENTS
            if (input.Count() < 1 || CLI.isArgFlag(input[1]))
            {
                Console.WriteLine("No account name provided.");
                break;
            }
            string accountName = input[1];

            Account account = new(accountName);

            // OPTIONS
            string? optionsError = null;
            List<CLI.Option> options = CLI.Parse.Options(input[2..]);
            if (options.Count() > 0)
            {
                foreach (CLI.Option option in options)
                {
                    switch (option.Name)
                    {
                        case "--initial-balance":
                        case "-i":
                            if (option.Value is null)
                            {
                                optionsError = "No initial balance amount provided.";
                                break;
                            }

                            account.InitialBalance = Int32.Parse(option.Value);
                            break;
                        default:
                            optionsError = $"Unknown option: {option.Name}";
                            break;
                    }
                }
            }
            // options error check 
            if (optionsError is not null)
            {
                Console.WriteLine(optionsError);
                break;
            }

            Console.WriteLine($"{account.Name}: ${account.GetBalance()}");

            break;
        case "quit":
            return;
        default:
            Console.WriteLine($"Unknown command: {command}");
            break;
    }
}
// ------------

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
            string[] options = input[1..];
            if (options.Count() > 0)
            {
                if (new[] { "-h", "--help" }.Contains(options[0]))
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

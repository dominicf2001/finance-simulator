public class CLI
{
    public record Option(string Name, string? Value = null);

    public static bool isArgFlag(string arg) => arg.StartsWith("-") || arg.StartsWith("--");

    public class Parse
    {
        public static List<Option> Options(string[] args)
        {
            List<Option> options = [];

            string? currentName = null;
            foreach (string arg in args)
            {
                if (currentName is null)
                {
                    currentName = arg;
                }
                else
                {
                    if (CLI.isArgFlag(arg))
                    {
                        options.Add(new(currentName));
                        currentName = arg;
                    }
                    else
                    {
                        string currentValue = arg;
                        options.Add(new(currentName, currentValue));
                        currentName = null;
                    }
                }
            }

            if (currentName is not null)
                options.Add(new(currentName));

            return options;
        }
    };
}


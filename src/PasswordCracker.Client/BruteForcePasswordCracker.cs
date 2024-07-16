namespace PasswordCracker.Client;
public static class BruteForcePasswordCracker
{
    private static readonly string _passwordCharacters = "aAbBcC";
    //private static readonly string _passwordCharacters = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ1234567890";

    private static int _totalCombinations = 0;
    private static HashSet<string> _possiblePasswords = new HashSet<string>();

    public static void Crack(string password)
    {
        Process(_passwordCharacters.ToCharArray());

        var matchedPassword = _possiblePasswords.First(p => p.Equals(password));

        Console.WriteLine($"Password '{matchedPassword}' matched");
    }

    private static void Process(char[] characters)
    {
        for (int i = 1; i <= characters.Length; i++)
        {
            Generate(characters, i, string.Empty);
        }

        Console.WriteLine($"Total combinations: {_totalCombinations}");
    }

    private static void Generate(char[] passwordCharacters, int index, string partialPassword)
    {
        if (index == 0)
        {
            Console.WriteLine(partialPassword);
            _possiblePasswords.Add(partialPassword);
            _totalCombinations++;

            return;
        }

        var length = passwordCharacters.Length;

        for (int j = 0; j < length; j++)
        {
            var appended = partialPassword + passwordCharacters[j];
            Generate(passwordCharacters, index - 1, appended);
        }
    }
}

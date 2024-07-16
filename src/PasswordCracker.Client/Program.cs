namespace PasswordCracker.Client;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a password:");
        var password = Console.ReadLine();

        BruteForcePasswordCracker.Crack(password);

        Console.ReadLine();
    }
}

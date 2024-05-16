namespace MasterMind
{
    public class MastermindClass
    {
        Random random = new Random();
        string secretNumber = "";
        int attempts = 10;
        bool isGuessedCorrectly = false;

        public void Run()
        {
            InitializeSecretCode();
            Console.WriteLine("Welcome to Mastermind!");

            while (attempts > 0 && !isGuessedCorrectly)
            {
                Console.WriteLine("\nYou have " + attempts + " attempts left.");
                Console.Write("Enter your guess (four digits, each between 1 and 6): ");
                string userGuess = Console.ReadLine()!;

                if (userGuess.Length != 4)
                {
                    Console.WriteLine("Invalid input. Please enter exactly four digits.");
                    continue;
                }

                string hints = GetHints(secretNumber, userGuess);
                Console.WriteLine("Hint: " + hints);

                if (hints == "++++")
                {
                    isGuessedCorrectly = true;
                    Console.WriteLine("Congratulations! You've guessed the secret number!");
                }

                attempts--;

                if(attempts == 0)
                {
                    Console.WriteLine($"You have run out of attempts. The correct number was: {secretNumber}");
                }
            }
        }

        private void InitializeSecretCode()
        {
            for (int i = 0; i < 4; i++)
            {
                secretNumber += random.Next(1, 7).ToString();
            }
        }

        static string GetHints(string secret, string guess)
        {
            string hints = "";
            int plusCount = 0;
            int minusCount = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    plusCount++;
                }
                else if (secret.Contains(guess[i]))
                {
                    minusCount++;
                }
            }

            hints += new String('+', plusCount);
            hints += new String('-', minusCount);

            return hints;
        }
    }
}
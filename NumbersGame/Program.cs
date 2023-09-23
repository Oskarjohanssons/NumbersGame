using System;

class Program
{
   public static void Main()
    {
        bool PlayAgain = true;

        while (PlayAgain)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? ");
            Console.WriteLine("Du kommer att få fem försök på dig att gissa rätt, talet är mellan 1-20");


            Random random = new Random();
            int secretNumber = random.Next(1, 21);

            bool GuessedCorrectly = false;

            for (int attempt = 1; attempt <= 5; attempt++)
            {
                Console.Write("Gissning #" + attempt + ": ");
                int userGuess;

                if (!int.TryParse(Console.ReadLine(), out userGuess))
                {

                    Console.WriteLine("Nu förstår jag inte vad du menar, ange ett heltal mellan 1-20");
                    attempt--;
                    continue;

                }

                bool isCorrect = CheckGuess(userGuess, secretNumber);

                if (userGuess == secretNumber)
                {
                    Console.WriteLine("Woho! Du gjorde det!");
                    GuessedCorrectly = true;
                    break;
                }
                else if (userGuess < secretNumber)
                {
                    string[] Message = {
                "Tyvärr du gissade för lågt!",
                "Haha! Trodde du var bättre på att gissa ;) Det var för lågt",
                "Bra gissat men det var för lågt"
                };
                    Random Ran = new Random();
                    string RandomMessageLow = Message[Ran.Next(Message.Length)];
                    Console.WriteLine(RandomMessageLow);
                }
                else
                {
                    string[] Message = {
                "Tyvärr du gissade för högt!",
                "Haha! Trodde du var bättre på att gissa ;) Det var för högt!",
                "Bra gissat men det var för högt!"
                };
                    Random Ran = new Random();
                    string RandomMessageHigh = Message[Ran.Next(Message.Length)];
                    Console.WriteLine(RandomMessageHigh);
                }
            }

            if (!GuessedCorrectly)
            {
                Console.WriteLine($"Tyvärr du lyckades inte gissa talet på femte försöket! Rätt svar var: {secretNumber}");
            }

            Console.Write("Vill du spela igen? (ja/nej): ");
            string PlayAgainInput = Console.ReadLine();
            PlayAgain = (PlayAgainInput.ToLower() == "ja");
        }
    }

    static bool CheckGuess(int guess, int secretNumber)
    {
        return guess >= secretNumber;
    }
}


namespace GuessTheNumber;

internal class GameCore
{
    Random random = new Random();
    private int _target;
    private int _userChances = 0;
    private int _userLives;
    public int Target => _target;

    public GameCore()
    {
        _target = random.Next(101);
    }
    


    public static void GameStart()
    {
        GameCore gameCore = new GameCore();
        Console.WriteLine("Welcome to the Number Guessing Game!\nI'm thinking of a number between 1 and 100.");
        // User have to choose diffiulty level with proper input
        while (gameCore._userChances != 3 && gameCore._userChances != 5 && gameCore._userChances != 10)
        {
            try
            {
                Console.WriteLine("Please select the difficulty\nEasy (10 chances)\nMedium (5 chances)\nHard (3 chances)\n(e/m/h): ");
                string userInputDifficulty = Console.ReadLine();
                gameCore._userChances = GameDifficulty(userInputDifficulty);
                gameCore._userLives = gameCore._userChances;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // While user has chances the program will ask for inpout
        while (gameCore._userChances != 0)
        {
            // Making sure that user input is accepted
            try
            {
                Console.WriteLine("Enter your guess: ");
                int userInputGuess = int.Parse(Console.ReadLine());
                if (gameCore.IsCorrect(userInputGuess))
                {
                    break;
                }
                gameCore._userChances--;
                if (gameCore._userChances == 0)
                {
                    Console.WriteLine($"You lost :(\nThe target was: {gameCore._target}");
                    Console.WriteLine("Want to restart? (y/n)");
                    string userInputRestart = Console.ReadLine();
                    userInputRestart = userInputRestart.ToUpper();
                    if (userInputRestart[0] == 'Y')
                    {
                        GameStart();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public static int GameDifficulty(string gameDifficulty)
    {
        gameDifficulty = gameDifficulty.ToUpper();
            switch (gameDifficulty[0])
            {
                case 'E':
                    return 10;
                case 'M':
                    return 5;
                case 'H':
                    return 3;
            }
        // Throws an error if the user provided diffrent value than expected and the while loop did not work
        throw new Exception("Pass the correct value");
    }
    // Function that checks if user input is the targer
    public bool IsCorrect(int userInput)
    {
        if (userInput == Target) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You guessed the number! The number was: {Target}\nYou guessed it in {_userLives - _userChances + 1} attempts!");
            Console.ResetColor();
            return true;
        }

        if (userInput > Target)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The target is lower.");
            Console.ResetColor();
            return false;
        }

        if(userInput < Target)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The target is higher.");
            Console.ResetColor();
            return false;
        }
        return false;
    }
}

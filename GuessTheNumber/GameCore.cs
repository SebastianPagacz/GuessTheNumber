namespace GuessTheNumber;

internal class GameCore
{
    Random random = new Random();
    private int _target;
    private int _userChances = 0;
    public int Target => _target;

    public GameCore()
    {
        _target = random.Next(101);
    }
    


    public static void GameStart()
    {
        GameCore gameCore = new GameCore();

        Console.WriteLine("Welcome in the Guess The Number\nRules are simple, guess the random number in range form 0 to 100\nHave Fun :)");
        // User have to choose diffiulty level with proper input
        while (gameCore._userChances != 3 && gameCore._userChances != 5 && gameCore._userChances != 10)
        {
            try
            {
                Console.WriteLine("Pick the difficulty (e/m/h): ");
                string userInputDifficulty = Console.ReadLine();
                gameCore._userChances = GameDifficulty(userInputDifficulty);
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
                Console.WriteLine("Guess the number!");
                int userInputGuess = int.Parse(Console.ReadLine());
                if (gameCore.IsCorrect(userInputGuess))
                {
                    gameCore.IsCorrect(userInputGuess);
                    break;
                }
                gameCore._userChances--;
                if (gameCore._userChances == 0)
                {
                    Console.WriteLine($"You lost :(\nThe target was: {gameCore._target}");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    // Might change it to enum in the future
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
        throw new Exception("Error occured");
    }
    // Function that checks if user input is the targer
    public bool IsCorrect(int userInput)
    {
        GameCore gameCore = new GameCore();
        if (userInput == Target) 
        {
            Console.WriteLine("You guessed the number!");
            return true;
        }

        if (userInput > Target)
        {
            Console.WriteLine("The target is lower.");
            return false;
        }

        if(userInput < Target)
        {
            Console.WriteLine("The target is higher.");
            return false;
        }
        // Might change to an exception
        return false;
    }
}

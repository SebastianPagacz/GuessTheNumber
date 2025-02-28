namespace GuessTheNumber;

internal class Program
{
    static void Main(string[] args)
    {
        GameCore game = new GameCore();
        GameCore.GameStart();
        try
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();
            Console.Clear();
            while (userInput[0] == 'Y')
            {
                GameCore.GameStart();
                Console.WriteLine("Do you want to play again? (y/n)");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                Console.Clear();
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }  
    }
}

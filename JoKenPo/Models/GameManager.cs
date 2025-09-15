namespace JoKenPo.Models;

public class GameManager
{
    public GameManager(int totalRounds)
    {
        TotalRounds = totalRounds;
    }

    public int TotalRounds { get; private set; }

    public void Start()
    {
        var player1 = PreparePlayer(1);
        var player2 = PreparePlayer(2);
        Console.Clear();
        var continueGame = true;

        Console.WriteLine($"{nameof(Player)} 1: {player1.Name}");
        Console.WriteLine($"{nameof(Player)} 2: {player2.Name}\n");

        for (int i = 0; i < TotalRounds; i++)
        {
            Console.WriteLine($"Round {i + 1}");
            var movimentPlayer1 = player1.AutomaticSelectionHandMovement();
            var movimentPlayer2 = player1.AutomaticSelectionHandMovement();

            Console.WriteLine($"{player1.Name} chose {movimentPlayer1.ToString().ToUpper()}");
            Console.WriteLine($"{player2.Name} chose {movimentPlayer2.ToString().ToUpper()}\n");

            if (movimentPlayer1 == HandMoviment.Paper && movimentPlayer2 == HandMoviment.Paper
                || movimentPlayer1 == HandMoviment.Rock && movimentPlayer2 == HandMoviment.Rock
                || movimentPlayer1 == HandMoviment.Scissors && movimentPlayer2 == HandMoviment.Scissors)
            {
                Console.WriteLine("Draw game!");
                Console.WriteLine("Press any key to play the next round");
                Console.WriteLine("".PadRight(100, '='));
                Console.WriteLine();
                Console.ReadLine();
                i--;
                continue;
            }

            if (movimentPlayer1 == HandMoviment.Paper && movimentPlayer2 == HandMoviment.Rock
                || movimentPlayer1 == HandMoviment.Rock && movimentPlayer2 == HandMoviment.Scissors
                || movimentPlayer1 == HandMoviment.Scissors && movimentPlayer2 == HandMoviment.Paper)
            {
                player1.AddScore();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{player1.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" wins this round!\n");
            }
            else
            {
                player2.AddScore();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{player2.Name}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" wins this round!\n");
            }

            Console.WriteLine("Press any key to play the next round.");
            Console.WriteLine("".PadRight(100, '='));
            Console.WriteLine();
            Console.ReadLine();

            continueGame = CheckHighScore(player1, player2);

            // If the game ended early, break the loop
            if (!continueGame)
                break;
        }

        // Show final score if the game wasn't ended early
        if (continueGame)
            ShowFinalScore(player1, player2);
    }

    private static bool CheckHighScore(Player player1, Player player2)
    {
        var continueGame = true;

        // If any players make two consecutive points, the game ends!
        if (player1.Score == 2 || player2.Score == 2)
        {
            continueGame = false;
            ShowFinalScore(player1, player2);
        }

        return continueGame;
    }

    private static void ShowFinalScore(Player player1, Player player2)
    {
        Console.WriteLine("Final Score:");
        Console.WriteLine($"{player1.Name}: {player1.Score}");
        Console.WriteLine($"{player2.Name}: {player2.Score}\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Winner: {(player1.Score > player2.Score ? player1.Name : player2.Name)}! ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Press any key to continue.");
        Console.ReadLine();
    }

    private static Player PreparePlayer(int playerNumber)
    {
        string playerName = string.Empty;

        while (true)
        {
            Console.Write($"Type name for player {playerNumber}: ");
            playerName = Console.ReadLine()?.ToUpper()!;

            try
            {
                var player = new Player(playerName);
                return player;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
                Console.Clear();
                continue;
            }
        }
    }
}

using BaseGame;
using BaseGameInterface;

namespace MyGame
{
	class Program
	{
		static void Main(string[] args)
		{
			GameManager gameManager = new GameManager();

			IPlayer player1 = new Player();
			player1.SetID(1);
			player1.SetName("Player 1");

			IPlayer player2 = new Player();
			player2.SetID(2);
			player2.SetName("Player 2");

			IDice dice = new Dice(6);

			gameManager.AddPlayer(player1);
			gameManager.AddPlayer(player2);
			gameManager.AddDice(dice);

			while (gameManager.CheckWinner() == null)
			{
				gameManager.StartRound();
				Console.WriteLine("Current player positions:");
				foreach (var player in gameManager.GetPlayers())
				{
					Console.WriteLine($"{player.Key.GetName()} - ({player.Value.x}, {player.Value.y})");
				}
				Console.WriteLine();
			}

			IPlayer winner = gameManager.CheckWinner()!;
			Console.WriteLine($"Congratulations, {winner.GetName()}! You have won the game!");
		}
	}
}

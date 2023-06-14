using BaseGameInterface;
namespace BaseGame;

public class GameManager
{
	private Dictionary<IPlayer, IPosition>? _players;
	private List<IDice>? _dices;

	public GameManager()
	{
		_players = new Dictionary<IPlayer, IPosition>();
		_dices = new List<IDice>();
	}
	public GameManager(IPlayer player, IDice dice, IPosition post)
	{
		_players = new Dictionary<IPlayer, IPosition>();
		_dices = new List<IDice>();
		_players?.Add(player, post);
		_dices?.Add(dice);
	}
	public bool AddPlayer(IPlayer player)
	{
		if (!_players.ContainsKey(player))
		{
			IPosition post = new Position();
			_players.Add(player, post);
			return true;
		}
		else
		{
			return false;
		}
	}
	public Dictionary<IPlayer, IPosition> GetPlayers() 
	{
		return _players; 
	}
	public void AddDice(IDice dice)
	{
		if (_dices == null)
		{
			_dices = new List<IDice>();
		}

		_dices.Add(dice);
	}
	public void StartGame()
	{
		foreach (var player in _players)
		{
			int totalResult = 0;
			foreach (var dice in _dices)
			{
				totalResult += dice.Randomize();
			}

			IPosition currentPosition = player.Value;
			IPosition newPosition = new Position { x = currentPosition.x + totalResult, y = currentPosition.y + totalResult };
			_players[player.Key] = newPosition;
		}
	}
	public IPlayer? CheckWinner()
	{
		foreach (var player in _players)
		{
			if (player.Value.x >= 30 || player.Value.y >= 30)
			{
				return player.Key;
			}
		}
		return null;
	}
}

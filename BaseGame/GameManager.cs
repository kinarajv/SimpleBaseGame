using System.Collections;
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
	public bool? AddPlayer(IPlayer player)
	{
		if (_players != null)
		{
			if (!_players.ContainsKey(player))
			{
				IPosition post = new Position();
				_players.Add(player, post);
				return true;
			}
		}
		return false;

	}
	public Dictionary<IPlayer, IPosition>? GetPlayers()
	{
		if (_players != null)
		{
			return _players;
		}
		return null;

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
		if (_players != null && _dices != null)
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
		else
		{
			throw new KeyNotFoundException();
		}
	}
	public IPlayer? CheckWinner()
	{
		if (_players != null)
		{
			foreach (var player in _players)
			{
				if (player.Value.x >= 30 || player.Value.y >= 30)
				{
					return player.Key;
				}
			}
		}
		return null;
	}
}

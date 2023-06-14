using  BaseGameInterface;
namespace BaseGame;

public class Dice : IDice
{
	private int _diceSide;
	public Dice(int diceSide) 
	{
		_diceSide = diceSide;
	}
	int IDice.Randomize()
	{
		Random rnd = new Random();
		int randomVal = rnd.Next(1, _diceSide);
		return randomVal;
	}

	bool IDice.SetDice(int diceSide)
	{
		if(diceSide > 1) 
		{
			_diceSide = diceSide;
			return true;
		}
		else 
		{
			return false;
		}
	}

}

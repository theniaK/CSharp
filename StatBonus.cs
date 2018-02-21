using UnityEngine;
using System.Collections;

public class StatBonus 
{
	public int BonusValue { // this is a value that will be added to the base value of an item to form the final value
		get;
		set;
	}

	// this is the constructor
	public StatBonus (int bonusValue)
	{
		this.BonusValue = bonusValue;
		Debug.Log ("new stat bonus");
	}

}

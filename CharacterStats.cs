using UnityEngine;
using System.Collections.Generic;

public class CharacterStats : MonoBehaviour {

	//Create new list so that stats can be added
	public List<BaseStat> stats = new List<BaseStat>();

	void Start()
	{
		stats.Add (new BaseStat (4, "Power", "your power level.")); // add stats to the character
		stats [0].AddStatBonus(new StatBonus(5)); // add a bonus stat to the character
		stats [0].AddStatBonus(new StatBonus(-7)); 
		stats [0].AddStatBonus(new StatBonus(20)); 
		Debug.Log(stats[0].GetCalculatedStatValue());
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseStat
{

	public List<StatBonus> BaseAdditives {get; set;} // A list that will contain all the features of the character

	public int BaseValue { get; set;} // the value of the stat
	public string StatName { get; set;} // the name of the stat
	public string StatDescription {get; set;} // the description of the stat
	public int FinalValue { get; set;} // final value of the stat


	//This is the constractor of the list
	public BaseStat (int baseValue , string statName, string statDescription )
	{
		this.BaseAdditives = new List<StatBonus> ();
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDescription = statDescription;
	}

	// this method add a feature to the list
	public void AddStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Add (statBonus);
	}

	// this method removes a feature from the list
	public void RemoveStatbonus(StatBonus statBonus)
	{
		this.BaseAdditives.Remove (statBonus);
	}

	// this method return the final value of the feature
	public int GetCalculatedStatValue()
	{
		this.BaseAdditives.ForEach (x => this.FinalValue += x.BonusValue); // For each feature in the list the bonus value is added to the final value
		FinalValue += BaseValue; // base value is added to the final value
		return FinalValue;
	}
}

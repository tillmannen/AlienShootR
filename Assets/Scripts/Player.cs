using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Player {

	public Player()
	{
		//Default values
		Level = 1;
		Name = "Fredrik";
	}

	public string Name { get; set; }
	public string Email { get; set; }
	public int LevelsCleared { get; set; }
	public int LevelsLost { get; set; }
	public int EnemiesKilled { get; set; }
	public float Experience { get; set; }
	public float HighScore { get; set; }
	public float Money { get; set; }
	public int Level { get; set; }


	public bool IsInLevel { get; set; }
	public int LevelProgress { get; set; }
	public float MoneyLastLevel {get; set; }

}

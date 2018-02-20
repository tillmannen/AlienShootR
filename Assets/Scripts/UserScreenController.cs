using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace AlienShooter {

	public class UserScreenController : MonoBehaviour {

		public InputField playerName;
		public InputField playerEmail;
		public Text levelsCleared;
		public Text levelsLost;
		public Text enemiesKilled;

		public Player player => GameControl.instance.player;

		// Use this for initialization
		void Start () {
			playerName.text = player.Name;
			playerEmail.text = player.Email;
			levelsCleared.text = player.LevelsCleared.ToString();
			levelsLost.text = player.LevelsLost.ToString();
			enemiesKilled.text = player.EnemiesKilled.ToString();
		}
		
		// Update is called once per frame
		void Update () {
			
		}


		public void CloseClicked(){
			GameControl.instance.Save();
			// LevelController.LoadLevel(0);
			LevelController.ClosePopup("UserScreen");
		}
	}
}
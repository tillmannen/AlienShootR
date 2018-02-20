using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace AlienShooter {
	public class GameControl : MonoBehaviour
	{
		public static GameControl instance;

		public Player player;
		public Font font;

		public int badGuysKilledThisWave;

		void Awake(){
			if (instance == null) {
				DontDestroyOnLoad (gameObject);
				if(player == null)
					player = new Player();
				instance = this;
			}
			else if (instance != this)
				Destroy (gameObject);		
		}

		void OnEnable(){
			Load();
		}

		void OnDisable(){
			Save();
		}

		private string filePath {
			get {
				return Application.persistentDataPath + "/playerInfo.dat";
			}
		}

		public void Save(){
			// Create a file
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(filePath, FileMode.OpenOrCreate);

			//Push data to it
			bf.Serialize(file, player);
			file.Close();
		}

		public void Load(){
			if(File.Exists(filePath)){
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(filePath, FileMode.Open);
				player = (Player)bf.Deserialize(file);
				file.Close();

				player.IsInLevel = false;
			}
		}

		void OnGUI(){
			if(!Plumbing.Settings.StylesSet)
				Plumbing.Settings.SetDefaultStyles(font);
		}
	}

	/*
	
		public Text playerName;
		public Text playerEmail;
		public Text levelsCleared;
		public Text levelsLost;
		public Text enemiesKilled;

	 */
}

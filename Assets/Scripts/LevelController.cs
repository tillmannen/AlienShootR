using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace AlienShooter {
	public class LevelController : MonoBehaviour {

		public static void LoadLevel(int level){
			switch(level){
				case (0):
					LoadScene("HomeScreen");
					//SceneManager.LoadScene("HomeScreen");
					if(GameControl.instance?.player != null)
						GameControl.instance.player.IsInLevel = false;
					break;
				case (1):
				case (2):
				case (3):
				case (4):

					SceneManager.LoadScene("Level"+level);
					SceneManager.LoadScene("LevelUI", LoadSceneMode.Additive);
					GameControl.instance.player.IsInLevel = true;
					break;
				case 1000:
					SceneManager.LoadScene("Debug");
					break;
				default:
					break;
			}
		}

		public static void QuitGame(){

			GameControl.instance.Save();
			Application.Quit();

			//UnityEditor.EditorApplication.isPlaying = false;
		}

		public static void LoadScene(string name){
			var scene = SceneManager.GetSceneByName(name);
			if(scene.isLoaded)
				SceneManager.SetActiveScene(scene);
			else
				SceneManager.LoadScene(name);
		}

		public static void ShowPopup(string name){
			SceneManager.LoadScene(name);//, LoadSceneMode.Additive);
		}
		public static void ClosePopup(string name){
			LoadLevel(0);
//			SceneManager.UnloadSceneAsync(name);

		}

		public static void LoadNextLevel(){
			LoadLevel(GameControl.instance.player.Level);
		}
		
		public void LoadDebugLevel(){
			LoadLevel(1000);
		}

		public static bool NextLevelExists {
			get{
				var s = SceneManager.GetSceneByName("Level" +AlienShooter.GameControl.instance.player.Level +1);
				return s.name != null;
			}
		}

		public static void GameOver(){
			if(GameControl.instance.player.IsInLevel){
				GameControl.instance.player.IsInLevel = false;
			}
			SceneManager.LoadScene("GameOver"); //, LoadSceneMode.Additive);
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}




	public interface ILevelHandler{
	}

	
	

}
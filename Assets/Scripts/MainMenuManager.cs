using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlienShooter {
	public class MainMenuManager : MonoBehaviour {

		public RectTransform playButton;

		public Text playerNameLabel;
		public Text moneyLabel;
		public Text experienceLabel;
		

		// Use this for initialization
		void Start () {
			//UIManager.BounceButton(playButton, 100);
			//LeanTween.scale(playButton, new Vector3(1.1f,1.1f, 1), 0.5f).setDelay(1f).setEaseInOutCirc().setRepeat(100).setLoopPingPong();
			//LeanTween.size(playButton, new Vector2(playButton.sizeDelta.x * 0.1f, playButton.sizeDelta.y * 0.1f), 0.5f).setEaseInOutElastic().setLoopPingPong().setRepeat(100);

			playerNameLabel.text = AlienShooter.GameControl.instance.player.Name;
			moneyLabel.text = AlienShooter.GameControl.instance.player.Money.ToString();
			experienceLabel.text = AlienShooter.GameControl.instance.player.Experience.ToString();

		}
		
		public void PlayClicked(){
			LeanTween.scale(playButton, new Vector3(0.8f, 0.8f,1), 0.10f).setLoopPingPong();
			StartCoroutine(PlayDelayed());
		}

		private IEnumerator PlayDelayed(){
			yield return new WaitForSeconds(0.2f);

			LevelController.LoadNextLevel();  
		}

		public void UserButtonClicked(){
			LevelController.ShowPopup("UserScreen");
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}
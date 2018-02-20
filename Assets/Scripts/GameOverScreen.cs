using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlienShooter;

public class GameOverScreen : MonoBehaviour {

	public RectTransform GameOverLabel;
	public RectTransform MoneySummary;
	public RectTransform PlayAgainButton;
	private Text MoneyCount;

	private float count = 0;

	// Use this for initialization
	void Start () {
		LeanTween.scale(GameOverLabel, new Vector2(0f,0f), 0f);

		MoneyCount = MoneySummary.Find("MoneyCount").GetComponent<Text>();

		LeanTween.move(MoneySummary, new Vector3(10, 180, 0), 2f).setEaseOutBounce();

		AnimateGameOverText();

		if(GameControl.instance.player.LevelProgress == 100){
			var label = GameOverLabel.GetComponent<Text>();
			label.text = "Cleared";
			label.color = Color.green;

			GameControl.instance.player.LevelsCleared++;
		}
		else
			GameControl.instance.player.LevelsLost++;
	}
	
	// Update is called once per frame
	void Update () {
		if(count < GameControl.instance?.player?.MoneyLastLevel)
			count = count+(int)(GameControl.instance.player.MoneyLastLevel / 100);
		MoneyCount.text = "" + count;
	}

	void AnimateGameOverText(){
		LeanTween.scale(GameOverLabel, new Vector2(1f,1f), 2.5f).setEaseOutBounce().setDelay(1);
		//LeanTween.scale(GameOverLabel, new Vector2(1.5f,1.5f), 2f).setEasePunch().setDelay(1.5f);
		LeanTween.scale(GameOverLabel, new Vector2(1.2f, 1.2f), 2f).setDelay(3f).setLoopPingPong().setRepeat(1000).setEaseInOutSine();
	}

	public void BackButtonClick(){
		LevelController.LoadLevel(0);
	}

	public void PlayButtonClick(){
		if(LevelController.NextLevelExists){
			GameControl.instance.player.Level++;
			PlayAgainButton.GetComponent<Text>().text = "Play next";
		}
		LevelController.LoadLevel(GameControl.instance.player.Level);
	}

	void OnGUI(){
	}
}

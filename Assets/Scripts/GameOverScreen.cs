using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlienShooter;

public class GameOverScreen : MonoBehaviour {

	public RectTransform GameOverLabel;
	public RectTransform MoneySummary;
	public RectTransform TimeSummary;
	public RectTransform HighScore;
	public RectTransform PlayAgainButton;
	private Text MoneyCount;
	private Text TimeCount;
	private Text HighScoreTime;

	private float count = 0;

	// Use this for initialization
	void Start () {
		SavePlayerStats();
		InitLables();

		LeanTween.move(MoneySummary, new Vector3(10, 180, 0), 2f).setEaseOutBounce();
		LeanTween.move(TimeSummary, new Vector3(10, 350, 0), 2f).setEaseOutBounce();
		LeanTween.move(HighScore, new Vector3(10, 280, 0), 2f).setEaseOutBounce();

		AnimateGameOverText();

	}
	
	void SavePlayerStats(){
		var player = GameControl.instance.player;
		if(player.LevelProgress == 100){
			var label = GameOverLabel.GetComponent<Text>();
			label.text = "Cleared";
			label.color = Color.green;

			if(player.BestLevelTimeMilliseconds == 0 || player.BestLevelTimeMilliseconds > player.LevelTimeMilliseconds){
				player.BestLevelTimeMilliseconds = player.LevelTimeMilliseconds;
			}

			player.LevelsCleared++;
		}
		else
			player.LevelsLost++;
	}

	void InitLables(){
		LeanTween.scale(GameOverLabel, new Vector2(0f,0f), 0f);

		MoneyCount = MoneySummary.Find("MoneyCount").GetComponent<Text>();
		TimeCount = TimeSummary.Find("TimeCount").GetComponent<Text>();
		TimeCount.text = GameControl.instance.player.LevelTime;
		HighScoreTime = HighScore.Find("HighScoreTime").GetComponent<Text>();
		HighScoreTime.text = GameControl.instance.player.BestLevelTime;

		LeanTween.move(MoneySummary, new Vector3(10, 1400, 0), 0f);
		LeanTween.move(TimeSummary, new Vector3(10, 1400, 0), 0f);
		LeanTween.move(HighScore, new Vector3(10, 1400, 0), 0f);

	}

	// Update is called once per frame
	void Update () {
		if(count < GameControl.instance?.player?.MoneyLastLevel){
			var moneyToAdd=(int)(GameControl.instance.player.MoneyLastLevel / 100);
			if(moneyToAdd < 1)
				moneyToAdd = 1;
			count = count+ moneyToAdd;
		}
		MoneyCount.text = "" + count;
	}

	void AnimateGameOverText(){
		LeanTween.scale(GameOverLabel, new Vector2(1f,1f), 2.5f).setEaseOutBounce().setDelay(1);
		//LeanTween.scale(GameOverLabel, new Vector2(1.5f,1.5f), 2f).setEasePunch().setDelay(1.5f);
		LeanTween.scale(GameOverLabel, new Vector2(1.2f, 1.2f), 2f).setDelay(3f).setLoopPingPong().setEaseInOutSine();
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

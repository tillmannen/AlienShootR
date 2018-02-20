using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlienShooter{


public class DebugSceneController : MonoBehaviour {

	public RectTransform Debug1;
	public RectTransform Debug2;
	public RectTransform Debug3;
	public GameObject ship;

	private Text DebugText1;
	private Text DebugText2;
	private Text DebugText3;

	// Use this for initialization
	void Start () {
		DebugText1 = Debug1.GetComponent<Text>();
		DebugText2 = Debug2.GetComponent<Text>();
		DebugText3 = Debug3.GetComponent<Text>();	
		
		LeanTween.scale(ship, new Vector3(0.3f, 0.3f, 0.3f),0);
		LeanTween.rotateAround(ship, new Vector3(0,1,0), 40, 3f).setLoopPingPong().setRepeat(-1);
		
	}
	
	// Update is called once per frame
	void Update () {
		DebugText1.text = @"width: " + Camera.main.scaledPixelWidth;

		DebugText2.text = @"height " + Camera.main.scaledPixelHeight;

		DebugText3.text = @"w : " + Camera.main.pixelWidth;
	}


	public void BackToMainMenu(){
		LevelController.LoadLevel(0);
	}
}
}
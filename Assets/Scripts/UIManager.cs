using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DentedPixel;

namespace AlienShooter{
	public class UIManager : MonoBehaviour {

		public Text moneyLabel;
		public Text progressLabel;

		private GUIStyle style;
	//	public Font font;


		void Awake () {
			// style = new GUIStyle ();
			// style.font = font;
		}
		
		void Update () {
			if(moneyLabel != null)
				moneyLabel.text = AlienShooter.GameControl.instance.player.MoneyLastLevel.ToString();
			if(progressLabel != null)
				progressLabel.text = AlienShooter.GameControl.instance.player.LevelProgress.ToString()+"%";
		}

		public static void GameOver(){
			if(ShowButton(Screen.width / 2,Screen.height / 2, "Game Over")){
				LevelController.LoadLevel(0);
			}
		}

		public static bool ShowButton(float x, float y, string label){
			
			var oldColor = GUI.backgroundColor;
			GUI.backgroundColor = Color.blue;
			
			var content = new GUIContent(label);
			var style = GUI.skin.button;
			style.alignment = TextAnchor.MiddleCenter;

			var size = style.CalcSize(content);

			var rect = new LTRect(x, y, size.x, size.y, 0f);

			var value =  GUI.Button(rect.rect, content);

			GUI.backgroundColor = oldColor;

			return value;
		}

		public static void BounceButton(RectTransform button, int repeat = 1){
			LeanTween.scale(button, new Vector2(1.1f, 1.1f), 0.5f).setLoopPingPong().setRepeat(repeat).setEaseInOutCirc();
		}

		public static void ShowLabel(float x, float y, string label){
			var content = new GUIContent(label);
			var style = GUI.skin.label;
			style.alignment = TextAnchor.MiddleCenter;

			var size = style.CalcSize(content);

			GUI.Label(new Rect(x, y, size.x, size.y), label);
		}
		public static void ShowLabelLeftSide(float x, float y, string label){
			var content = new GUIContent(label);
			var style = GUI.skin.label;
			style.alignment = TextAnchor.MiddleCenter;

			var size = style.CalcSize(content);

			ShowLabel(Screen.width - x - size.x, y, label);

		}

		void OnGUI(){

		}

	}
}
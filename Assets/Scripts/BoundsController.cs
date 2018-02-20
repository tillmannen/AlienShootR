using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsController : MonoBehaviour {

	public BoxCollider2D upper = new BoxCollider2D();
	public BoxCollider2D lower = new BoxCollider2D();
	public BoxCollider2D left = new BoxCollider2D();
	public BoxCollider2D right = new BoxCollider2D();

	// Use this for initialization
	void Start () {
		upper.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width *2, 0f, 0f)).x, 1f);
		upper.offset = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y +0.5f);

		lower.size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width *2, 0f, 0f)).x, 1f);
		lower.offset = new Vector2(0f, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y -0.5f);

		left.size = new Vector2(1f, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height*2, 0f)).y);
		left.offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 0.5f, 0f);

		right.size = new Vector2(1f, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height *2, 0f)).y);
		right.offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x+0.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

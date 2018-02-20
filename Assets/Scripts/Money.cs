using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour{
	Rigidbody2D rb;
	public int value;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, -2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		 
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			AlienShooter.GameControl.instance.player.Money += value;
			AlienShooter.GameControl.instance.player.MoneyLastLevel += value;
			Destroy (gameObject);
		}
	}
}

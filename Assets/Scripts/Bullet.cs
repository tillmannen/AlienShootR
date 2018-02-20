using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlienShooter.Enemies;

namespace AlienShooter {
	public class Bullet : MonoBehaviour {

		Rigidbody2D rb;

		public int direction; 
		public int speed;
		public int damage;

		public GameObject hitEffect;

		void Awake(){
			rb = GetComponent<Rigidbody2D> ();
		}

		// Use this for initialization
		void Start () {
			
		}

		public void ChangeDirection(){
			direction *= -1;
		} 

		// Update is called once per frame
		void Update () {
			rb.velocity = new Vector2 (0, speed * direction);
			if (gameObject.transform.position.y > 12 || gameObject.transform.position.y < -12)
				Destroy (gameObject);
		}
			
		void OnTriggerEnter2D(Collider2D col){
			
			if (col.gameObject.tag == "Enemy" && direction > 0) {
				col.gameObject.GetComponent<AlienShooter.Enemies.BaseBadGuy> ().Damage (damage);
				Explode ();
			}

			else if (col.gameObject.tag == "Player" && direction < 0) {
				col.gameObject.GetComponent<SpaceShip> ().DamageShip (damage);
				Explode ();
			}
		}

		void Explode(){
			if (hitEffect != null)
				Instantiate (hitEffect, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

	}
}
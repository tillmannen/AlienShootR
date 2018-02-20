using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienShooter.Enemies {

	public class Enemy : MonoBehaviour {

		public Rigidbody2D ship;


		private bool isDying;
		private GameObject a;
		private GameObject b;
		private GameObject nextCannon;
		private float fireRateStartValue;

		public float xSpeed;
		public float ySpeed;
		public float health;
		public float fireRate;

		public GameObject bullet;
		public GameObject explosion;
		public GameObject[] surpricesThatMightSpawn;
		public float chanceOfSurpriceSpawn;

		void Awake () {
			ship = GetComponent<Rigidbody2D> ();
			if (fireRate > 0) {
				a = transform.Find ("a").gameObject;
				b = transform.Find ("b").gameObject;
				int rand = Random.Range (0, 2);
				if (rand >= 1)
					nextCannon = a;
				else
					nextCannon = b;
				fireRateStartValue = fireRate;
			}
		}
		
		void Start () {
		}

		void OnCollisionEnter2D(Collision2D col){
			if (col.gameObject.tag == "Player" && !isDying) {
				isDying = true;
				col.gameObject.SendMessage("DamageShip", (int)health);
				//col.gameObject.GetComponent<SpaceShip>().DamageShip ((int)health);
				KilledByPlayer();
				Explode ();
			}
		}

		void KilledByPlayer(){
			//AlienShooter.GameControl.instance.player.EnemiesKilled++;
		}

		void Explode(){
			MaybeSpawnSurprice ();
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

		public void Damage(int damage){
			health = health - damage;
			if (health < 1 && !isDying) {
				isDying = true;
				KilledByPlayer();
				Explode();		
			}
		}

		void Update () {
			if (fireRate > 0)
				Fire ();

			if (gameObject.transform.position.y < -12)
				Destroy (gameObject);
		}

		void Fire(){
			fireRate--;
			if (fireRate < 1) {
				fireRate = fireRateStartValue;;

				Instantiate (bullet, nextCannon.gameObject.transform.position, Quaternion.identity);
				if (nextCannon == a)
					nextCannon = b;
				else
					nextCannon = a;
			}
		}

		void MaybeSpawnSurprice(){
			if (surpricesThatMightSpawn.Length < 1)
				return;

			if (Random.Range (0, 101) < chanceOfSurpriceSpawn) {
				Instantiate (surpricesThatMightSpawn [Random.Range (0, surpricesThatMightSpawn.Length)], gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	public class EnemyType1 : Enemy {

		// Use this for initialization
		void Start () {
				
		}
		
		// Update is called once per frame
		void Update () {
			this.transform.position = new Vector2(0,0);
		}
	}
}
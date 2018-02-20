using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienShooter {

	public class SpaceShip : MonoBehaviour {

		Rigidbody2D ship;


		public GameObject explosion;
		public float speed;
		public float health;
		public GameObject weapon;
		public int shotDelay = 0;

		public Sprite leftShip;
		public Sprite centerShip;
		public Sprite rightShip;

		private GameObject attachedWeapon;
		private float horizontal;
		private float vertical;

		

		void Awake(){
			ship = GetComponent<Rigidbody2D> ();
		}

		// Use this for initialization
		void Start () {
			AttachNewWeapon(weapon);

			SetupTouch();
		}

		void SetupTouch(){
			
		}
		
		// Update is called once per frame
		void Update () {
			ShowSprite ();
			MoveSprite();
		}

		public void DamageShip(int damage){
			health= health - damage;
			if (health < 1) {
				Explode ();
			}
		}

		public void AttachNewWeapon(GameObject newWeapon){
			Destroy (attachedWeapon);
			attachedWeapon = Instantiate (newWeapon, gameObject.transform.position, Quaternion.identity);
		}

		void ShowSprite(){
			// if (Input.GetKey (KeyCode.LeftArrow)) {
			// 	gameObject.GetComponent<SpriteRenderer> ().sprite = leftShip;
			// } else if (Input.GetKey (KeyCode.RightArrow)) {
			// 	gameObject.GetComponent<SpriteRenderer> ().sprite = rightShip;
			// }
			// else
			// 	gameObject.GetComponent<SpriteRenderer> ().sprite = centerShip;
			
		}

		void MoveSprite(){
			#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER

			Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector2 touchPoint = Camera.main.ScreenToWorldPoint(mousePos); //Input.mousePosition;

			ship.position = Vector2.MoveTowards(ship.position, touchPoint, speed);

			// Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
			#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

			if (Input.touchCount == 1)
			{
				var touch = Input.GetTouch(0);
				
				// if (touch.phase == TouchPhase.Moved)
				{
					var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
					Vector2 touchPoint = touchPos; //Camera.main.ScreenToWorldPoint(touchPos);

					ship.position = Vector2.MoveTowards(ship.position, touchPoint, speed);
				}
			}
			#endif 

			attachedWeapon.transform.position = gameObject.transform.position;

		}

		void Explode(){
			if(explosion != null)
				Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
			Destroy (attachedWeapon);
			LevelController.GameOver();
			Destroy (gameObject);
		}
	}
}

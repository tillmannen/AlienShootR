using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienShooter{
	public class WeaponUpgradeBox : MonoBehaviour {

		Rigidbody2D rb;
		public GameObject boxContents;

		void Start () {
			rb = GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector2 (0, -2);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
			
		void OnTriggerEnter2D(Collider2D col){
			if (col.gameObject.tag == "Player") {
				if(boxContents != null)
					col.gameObject.GetComponent<SpaceShip> ().AttachNewWeapon (boxContents);
				Destroy (gameObject);
			}
		}
	}
}
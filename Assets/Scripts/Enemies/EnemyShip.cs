using System;
using UnityEngine;

namespace AlienShooter.Enemies {
    public class EnemyShip : MonoBehaviour {
		public BaseBadGuy enemy;
		public Vector2 position;
		public Vector2 target1;
		public Vector2 target2;
		

		public void Launch(){
			var ship = (BadGuy1)Instantiate(enemy, position, Quaternion.Euler(90,180,0));
			ship.target1 = target1;
			ship.target2 = target2;
		}
	}


}
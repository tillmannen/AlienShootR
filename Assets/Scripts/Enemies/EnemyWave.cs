using UnityEngine;

namespace AlienShooter.Enemies {

    public class EnemyWave {
		public EnemyShip[] enemies;
		public float Lenght;
		public void SpawnEnemies() {
			foreach(var enemy in enemies){
				enemy.Launch();
			}
		}

		public int BadGuysInCurrentWave(){
						
			return GameControl.instance.badGuysKilledThisWave;
		}

        void Start(){

        }

        void Update(){
            
        }
	}
}

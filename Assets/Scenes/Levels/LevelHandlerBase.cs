using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AlienShooter.Enemies;

namespace AlienShooter.Levels {
	public abstract class LevelHandlerBase : MonoBehaviour{
		public EnemyWave[] waves;
		public EnemyWaveSpawner spawner;
		public BaseBadGuy[] enemies;
		public Bullet[] enemyBullets;
		public float startupDelay = 5;
		public RectTransform waveText;

		protected EnemyWaveSpawner activeSpawner = new EnemyWaveSpawner();
		protected bool levelStarted = false;
		protected float progress = 0;
		protected EnemyWavesHelper helper;

	//    private int levelProgress = 0;
		private bool gameOverLoaded = false;
		private IEnumerator StartSpawner(){

			yield return new WaitForSeconds(startupDelay);

			var s = Instantiate(spawner, new Vector2(0,8), Quaternion.identity);
			s.waves = waves;
			activeSpawner = s;
			activeSpawner.waveText = waveText;

			levelStarted = true;
		}

		protected abstract void CreateWaves();

		public void Start(){
			helper = new EnemyWavesHelper(enemies, enemyBullets);
			CreateWaves();
			
			AlienShooter.GameControl.instance.player.LevelProgress = 0;
			AlienShooter.GameControl.instance.player.MoneyLastLevel = 0;

			var coroutine = StartSpawner();
			StartCoroutine(coroutine);
		}

		void Update(){
			if(activeSpawner.allWavesDestroyed){
				GameControl.instance.player.LevelProgress = 100;
			}
			if(AlienShooter.GameControl.instance.player.LevelProgress >= 100 && !gameOverLoaded) {
				gameOverLoaded = true;
				StartCoroutine(EndLevel());
			}
		}

		IEnumerator EndLevel(){
			yield return new WaitForSeconds(3);
			Debug.Log("Game Over");
			LevelController.GameOver();
		}

		void OnGUI(){
		}
	}
}
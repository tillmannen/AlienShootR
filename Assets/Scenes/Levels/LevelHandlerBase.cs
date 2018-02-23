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
		public LevelTimer timer;

		protected EnemyWaveSpawner activeSpawner = new EnemyWaveSpawner();
		protected bool levelStarted = false;
		protected float progress = 0;
		protected EnemyWavesHelper helper;

	//    private int levelProgress = 0;
		private bool gameOverLoaded = false;
		private IEnumerator StartLevelWithDelay(){

			yield return new WaitForSeconds(startupDelay);

			StartLevel();
		}

		private void StartSpawner(){
			var s = Instantiate(spawner, new Vector2(0,8), Quaternion.identity);
			s.waves = waves;
			activeSpawner = s;
			activeSpawner.waveText = waveText;

		}

		private void StartLevel(){
			StartSpawner();
			levelStarted = true;
			timer.StartTimer();
		}

		protected abstract void CreateWaves();

		public void Start(){
			timer = new LevelTimer();
			helper = new EnemyWavesHelper(enemies, enemyBullets);
			CreateWaves();
			
			AlienShooter.GameControl.instance.player.LevelProgress = 0;
			AlienShooter.GameControl.instance.player.MoneyLastLevel = 0;

			var coroutine = StartLevelWithDelay();
			StartCoroutine(coroutine);
		}

		void Update(){
			if(activeSpawner.allWavesDestroyed){
				GameControl.instance.player.LevelProgress = 100;
				timer.StopTimer();
			}
			if(AlienShooter.GameControl.instance.player.LevelProgress >= 100 && !gameOverLoaded) {
				gameOverLoaded = true;
				StartCoroutine(EndLevel());
			}
			timer.UpdateTimer();
//			GameControl.instance.player.LevelTime = timer.ToString();
			GameControl.instance.player.LevelTimeMilliseconds = timer.millisecondsPassed;
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
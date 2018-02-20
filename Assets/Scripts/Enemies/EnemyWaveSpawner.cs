using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AlienShooter.Enemies {
	public class EnemyWaveSpawner : MonoBehaviour {
		public EnemyWave[] waves;
		public int currentWave => currentWaveIndex+1;
		public int waveCount => waves.Length;
		public RectTransform waveText;

		private int currentWaveIndex;
		private float waitFrames;
		private bool firstWaveLaunched = false;
		public bool allWavesDestroyed = false;

		public float TotalWaveLength {
			get {
				if(waves == null)
					return 0;
				return waves.Select(x => x.Lenght).Sum();
			}
		}

		void Start(){
			currentWaveIndex = -1;
			LeanTween.scale(waveText, new Vector2(0,0), 0f);
		}

		void Update(){
			waitFrames--;
			if(waves != null && (!firstWaveLaunched || waves[currentWaveIndex].BadGuysInCurrentWave() >= waves[currentWaveIndex].enemies.Length)) {
				firstWaveLaunched = true;
				GameControl.instance.badGuysKilledThisWave = 0;
				currentWaveIndex++;
				if(currentWaveIndex >= waves.Length){
					Debug.Log("Spawner destroyed");
					allWavesDestroyed = true;
					Destroy(this);
				}
				else{
					ShowWaveMessage(currentWave, waveCount);
					StartCoroutine(SpawnNextWave());
				}
			}
		}

		IEnumerator SpawnNextWave(){
			yield return new WaitForSeconds(2);
				waves[currentWaveIndex].SpawnEnemies();
		}

		public void ShowWaveMessage(int current, int total){
			waveText.GetComponent<Text>().text = string.Format("Wave {0}/{1}",current, total);
			LeanTween.scale(waveText, new Vector2(1,1), 1f).setEaseInOutExpo();
			LeanTween.scale(waveText, Vector2.zero, 1f).setDelay(3);
		}

	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject bullet;
	public float fireRate;
	public bool fireAllCannonsAtOnce;
	public bool autoFire;

	private float originalFireRate;
	private int nextSpawnPointIndex;

	// Use this for initialization
	void Start () {
		originalFireRate = fireRate;
		nextSpawnPointIndex = 0;
		
		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
		autoFire = false;
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		autoFire = true;
		#endif

	}
	
	// Update is called once per frame
	void Update () {
		fireRate--;
		if((autoFire || Input.GetKey(KeyCode.Space)) && fireRate < 1)
			Fire ();		
	}

	public void Fire(){
		fireRate = originalFireRate;
		if (!fireAllCannonsAtOnce)
			fireOneCannon ();
		else {
			for (var i = 0; i < spawnPoints.Length; i++) {
				fireOneCannon ();
			}
		}
	}

	private void fireOneCannon(){
		Instantiate (bullet, spawnPoints [nextSpawnPointIndex].transform.position, Quaternion.identity);

		nextSpawnPointIndex++;

		if (nextSpawnPointIndex > spawnPoints.Length - 1)
			nextSpawnPointIndex = 0;
		
	}
}

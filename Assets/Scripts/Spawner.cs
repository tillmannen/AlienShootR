using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemies;
	public float spawnRate;


	void Start () {
		InvokeRepeating ("Spawn", spawnRate, spawnRate);
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate (enemies [(int)Random.Range (0, enemies.Length)].gameObject, new Vector3 (Random.Range ((float)-8.5, (float)8.5), (float)7, (float)0), Quaternion.identity);
	}
}

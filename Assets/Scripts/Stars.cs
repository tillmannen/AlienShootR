using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

	ParticleSystem stars;

	// Use this for initialization
	void Start () {
		stars = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(stars != null && Input.GetKeyDown(KeyCode.Escape)){
			if(stars.isPaused)
				stars.Play(); 
			else 
				stars.Pause();
		}
	}
}

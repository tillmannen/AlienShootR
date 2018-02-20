using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {

	public int animationTime;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animationTime--;
		if (animationTime < 0)
			Destroy (gameObject);
	}
}

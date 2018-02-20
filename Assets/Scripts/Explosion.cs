using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public int clipLength;

	void Start () {
//		anim = gameObject.GetComponent<Animator> ();
//		anim.StopPlayback ();
	}
	
	void Update () {
		clipLength--;
		if (clipLength < 0)
			Destroy (gameObject);
	}
}

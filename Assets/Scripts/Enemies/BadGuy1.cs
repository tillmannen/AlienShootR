using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienShooter.Enemies{
	public class BadGuy1 : BaseBadGuy {

		public Vector3 target1;
		public Vector3 target2;
		
		void Start () {
			LeanTween.init(800);
			LeanTween.move(gameObject, target1, 3f).setOnComplete(Move1);
			fireRateStartValue = fireRate;
		}
		
		void Update () {
            if(fireRate > 0 && chanceOfFire > 0 && bullet != null){
                fireRate--;
                if(fireRate <= 0){
                    fireRate = fireRateStartValue;
                    if (UnityEngine.Random.Range (0, 101) < chanceOfFire){
                        FireCannon();
                    }
                }
            }
		}

		IEnumerator AnimateShipMovement(){
			yield return new WaitForSeconds(2);

			Move1();
		}

		void Move1(){
			LeanTween.move(gameObject, target2, 1f).setEaseInOutBack().setLoopPingPong().setOnComplete(Move1);
		}
	}
}

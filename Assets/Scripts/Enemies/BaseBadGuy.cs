using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlienShooter.Enemies {
    public class BaseBadGuy : MonoBehaviour {

		private Rigidbody2D ship;

		public float health;
		public GameObject explosion;
		public GameObject[] surpricesThatMightSpawn;
		public float chanceOfSurpriceSpawn;
        public bool dead;
        public float fireRate;
        public float chanceOfFire;
        
        public Bullet bullet;

        protected float fireRateStartValue;


        void Start(){
            dead = false;
            ship = GetComponent<Rigidbody2D>();
        }

        void Update(){
        }

        public void Damage(float value){
            health -= value;
            if(health < 0)
                Explode();
        }

        void Explode(){
            if(!dead)
                GameControl.instance.badGuysKilledThisWave++;
            dead = true;
            MaybeSpawnSurprice();
            Destroy(gameObject);
        }

        protected void FireCannon(){
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        }

        void MaybeSpawnSurprice(){
			if (surpricesThatMightSpawn.Length < 1)
				return;

			if (UnityEngine.Random.Range (0, 101) < chanceOfSurpriceSpawn) {
				Instantiate (surpricesThatMightSpawn [UnityEngine.Random.Range (0, surpricesThatMightSpawn.Length)], gameObject.transform.position, Quaternion.identity);
			}
		}
    }
}

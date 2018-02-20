using System;
using System.Collections.Generic;
using UnityEngine;

using AlienShooter.Enemies;

namespace AlienShooter.Levels{
	public class EnemyWavesHelper {

		private readonly BaseBadGuy[] enemies;
		private readonly Bullet[] bullets;

		public EnemyWavesHelper(BaseBadGuy[] e, Bullet[] enemyBullets)
		{
			enemies = e;
			bullets = enemyBullets;
			MatchEnemiesAndBullets();
		}

		private void MatchEnemiesAndBullets(){
			for(int i = 0; i < enemies.Length; i++){
				if(bullets[i] != null)
					enemies[i].bullet = bullets[i];
			}
		}

		public EnemyWave NineTimesFourSimpleWave(int index = 0){
			return new EnemyWave(){
				enemies = new List<EnemyShip>(){
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-3.8f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-2.8f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-1.8f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-0.8f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 0.2f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 1.2f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 2.2f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 3.2f, 10), 0),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 4.2f, 10), 0),

					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-3.8f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-2.8f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-1.8f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-0.8f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 0.2f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 1.2f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 2.2f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 3.2f, 12), 1.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 4.2f, 12), 1.5f),

					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-3.8f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-2.8f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-1.8f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-0.8f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 0.2f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 1.2f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 2.2f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 3.2f, 14), 3f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 4.2f, 14), 3f),

					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-3.8f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-2.8f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-1.8f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-0.8f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 0.2f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 1.2f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 2.2f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 3.2f, 16), 4.5f),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 4.2f, 16), 4.5f),
				}.ToArray()
			};
		}

		public EnemyWave NineBadGuy1InAStraightLine(int index = 0, int length = 100){
			return new EnemyWave(){
				enemies = new List<EnemyShip>(){
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-4, 10), new Vector2(-4, 0), new Vector2(-4.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-3, 10), new Vector2(-3, 0), new Vector2(-3.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-2, 10), new Vector2(-2, 0), new Vector2(-2.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2(-1, 10), new Vector2(-1, 0), new Vector2(-1.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 0, 10), new Vector2( 0, 0), new Vector2(-0.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 1, 10), new Vector2( 1, 0), new Vector2( 0.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 2, 10), new Vector2( 2, 0), new Vector2( 1.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 3, 10), new Vector2( 3, 0), new Vector2( 2.5f, 0)),
					AddBadGuy1((BadGuy1)enemies[index], new Vector2( 4, 10), new Vector2( 4, 0), new Vector2( 3.5f, 0)),
					
					// AddShip(enemies[index],-6, 6),
					// AddShip(enemies[index],-4, 6),
					// AddShip(enemies[index],-2, 6),
					// AddShip(enemies[index], 0, 6),
					// AddShip(enemies[index], 2, 6),
					// AddShip(enemies[index], 4, 6),
					// AddShip(enemies[index], 6, 6),
					// AddShip(enemies[index], 8, 6),
				}.ToArray(),
				Lenght = length
			};
		}
		public EnemyWave NineShipsInASlash(int index = 0, int length = 100){
			return new EnemyWave(){
				enemies = new List<EnemyShip>(){
					AddShip(enemies[index],-8, 6),
					AddShip(enemies[index],-6, 7),
					AddShip(enemies[index],-4, 8),
					AddShip(enemies[index],-2, 9),
					AddShip(enemies[index], 0, 10),
					AddShip(enemies[index], 2, 11),
					AddShip(enemies[index], 4, 12),
					AddShip(enemies[index], 6, 13),
					AddShip(enemies[index], 8, 14),
				}.ToArray(),
				Lenght = length
			};
		}
		public EnemyWave NineShipsInABackSlash(int index = 0, int length = 100){
			return new EnemyWave(){
				enemies = new List<EnemyShip>(){
					AddShip(enemies[index], 8, 6),
					AddShip(enemies[index], 6, 7),
					AddShip(enemies[index], 4, 8),
					AddShip(enemies[index], 2, 9),
					AddShip(enemies[index], 0, 10),
					AddShip(enemies[index],-2, 11),
					AddShip(enemies[index],-4, 12),
					AddShip(enemies[index],-6, 13),
					AddShip(enemies[index],-8, 14),
				}.ToArray(),
				Lenght = length
			};
		}	
		public EnemyWave SevenShipsInAV(int index = 0, int length = 100){
			return new EnemyWave(){
				enemies = new List<EnemyShip>(){
					AddShip(enemies[index],-6, 9),
					AddShip(enemies[index],-4, 8),
					AddShip(enemies[index],-2, 7),
					AddShip(enemies[index], 0, 6),
					AddShip(enemies[index], 2, 7),
					AddShip(enemies[index], 4, 8),
					AddShip(enemies[index], 6, 9),
				}.ToArray(),
				Lenght = length
			};
			
		}

		public EnemyShip AddShip(BaseBadGuy ship, float x, float y){
			var distance = (float)Camera.main.scaledPixelWidth/(3 * Camera.main.pixelWidth);
	//		var point = 
			return 	new EnemyShip(){
					enemy = ship,
					position = new Vector2(x*distance,y*distance+3)
				};			
		}



		public EnemyShip AddBadGuy1(BadGuy1 badGuy, Vector2 StartingPos, Vector2 target1, Vector2 target2){

			return new EnemyShip(){
				enemy = badGuy,
				position = StartingPos,
				target1 = target1,
				target2 = target2
			};
		}
		public EnemyShip AddBadGuy1(BadGuy1 badGuy, Vector2 StartingPos, float targetY){
			var target1 = new Vector2(StartingPos.x, targetY);
			var target2 = new Vector2(StartingPos.x-0.5f, targetY);

			return new EnemyShip(){
				enemy = badGuy,
				position = StartingPos,
				target1 = target1,
				target2 = target2
			};
		}

	}
}
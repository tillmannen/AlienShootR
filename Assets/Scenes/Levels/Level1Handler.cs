using System.Collections.Generic;

using AlienShooter.Enemies;
namespace AlienShooter.Levels {
	public class Level1Handler : LevelHandlerBase {

		new void Start(){
			enemies[0].fireRate = 50;
			enemies[0].chanceOfFire = 2;
			

			base.Start();
		}

		protected override void CreateWaves(){
			var w = new List<EnemyWave>();
			w.Add(helper.NineTimesFourSimpleWave());
			w.Add(helper.NineTimesFourSimpleWave());
			w.Add(helper.NineTimesFourSimpleWave());
			waves = w.ToArray();
		}
	}
}
using System.Collections.Generic;

using AlienShooter.Enemies;
namespace AlienShooter.Levels {
	public class Level1Handler : LevelHandlerBase {

		new void Start(){
			enemies[0].fireRate = 30;
			enemies[0].chanceOfFire = 3;
			

			base.Start();
		}

		protected override void CreateWaves(){
			var w = new List<EnemyWave>();
			w.Add(helper.NineTimesFourSimpleWave());
			w.Add(helper.NineTimesFourSimpleWave());
			w.Add(helper.NineBadGuy1InAStraightLine());
			// w.Add(helper.NineShipsInASlash());
			// w.Add(helper.NineShipsInABackSlash());
			// w.Add(helper.SevenShipsInAV());
			// w.Add(helper.NineShipsInASlash(0, 150));
			// w.Add(helper.NineShipsInABackSlash());
			// w.Add(helper.SevenShipsInAV(0, 400));
			waves = w.ToArray();
		}
	}
}
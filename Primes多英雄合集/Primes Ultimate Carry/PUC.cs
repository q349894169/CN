using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace Primes_Ultimate_Carry
{
	class PUC
	{
		public static Obj_AI_Hero Player = ObjectManager.Player;
		public static Champion Champion;
		public static IEnumerable<Obj_AI_Hero> AllHeros = ObjectManager.Get<Obj_AI_Hero>();
		public static IEnumerable<Obj_AI_Hero> AllHerosFriend = ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsAlly);
		public static IEnumerable<Obj_AI_Hero> AllHerosEnemy = ObjectManager.Get<Obj_AI_Hero>().Where(hero => hero.IsEnemy);
		
		//public Champion Champion;
		//public Orbwalker Orbwalker;

		public static Menu Menu;

		public PUC()
		{

			Game.PrintChat("<font color=\"#00BFFF\">====== 鎴愬姛杞藉叆:銆愮劇鐐烘眽鍖栥€戙劎Primes澶氳嫳闆勫悎闆嗐劎 ======</font>");
			Game.PrintChat("<font color=\"#00BFFF\">====== 鐗堟湰: v 0.15====== </font>");
			Game.PrintChat("<font color=\"#00BFFF\">銊у墤榄斻劎寰疯幈鏂囥劎浼婃辰鐟炲皵銊х撼灏斻劎閲戝厠鏂劎璺タ瀹夈劎鍙戞潯銊ч敜鐭炽劎</font>");
			Game.PrintChat("<font color=\"#00BFFF\">鏇村姹夊寲鑴氭湰璇峰姞  L#姹夊寲缇わ細386289593</font>");

			Player = ObjectManager.Player;
			Menu = new Menu("【無為汉化】多英雄合集", Player.ChampionName + "UltimateCarry", true);

			var infoMenu = new Menu("Primes 咨询台", "Primes_Info");
			PrimesInfo.AddtoMenu(infoMenu);

			var sidebarMenu = new Menu("Primes 边栏", "Primes_SideBar");
			SideBar.AddtoMenu(sidebarMenu);

			var trackerMenu = new Menu("Primes 跟踪器", "Primes_Tracker");
			Tracker.AddtoMenu(trackerMenu);

			var tsMenu = new Menu("Primes 目标选择", "Primes_TS");
			TargetSelector.AddtoMenu(tsMenu);

			var orbwalkMenu = new Menu("Primes 走砍", "Primes_Orbwalker");
			Orbwalker.AddtoMenu(orbwalkMenu);

			var activatorMenu = new Menu("Primes 活化剂", "Primes_Activator");
			Activator.AddtoMenu(activatorMenu);

			var autolevelMenu = new Menu("Primes 自动加点", "Primes_AutoLevel");
			AutoLevel.AddtoMenu(autolevelMenu);
			var loadbaseult = false;
			switch(Player.ChampionName)
			{
				case "Ashe":
					loadbaseult = true;
					break;
				case "Draven":
					loadbaseult = true;
					break;
				case "Ezreal":
					loadbaseult = true;
					break;
				case "jinx":
					loadbaseult = true;
					break;
			}
			if(loadbaseult)
			{
				var baseUltMenu = new Menu("Primes 基地大招", "Primes_BaseUlt");
				BaseUlt.AddtoMenu(baseUltMenu);
			}

		//if(Utility.Map.GetMap()._MapType == Utility.Map.MapType.SummonersRift ||
			//	Utility.Map.GetMap()._MapType == Utility.Map.MapType.TwistedTreeline)
			//{
			//	var tarzanMenu = new Menu("Primes Tarzan", "Primes_Tarzan");
			//	Jungle.AddtoMenu(tarzanMenu);
			//}

			LoadChampionPlugin();

			Menu.AddToMainMenu();

			Drawing.OnDraw += Drawing_OnDraw;
		}

		private void LoadChampionPlugin()
		{

			try
			{
				// ReSharper disable once AssignNullToNotNullAttribute
				var handle = System.Activator.CreateInstance(null, "Primes_Ultimate_Carry.Champion_" + ObjectManager.Player.ChampionName);
				Champion = (Champion)handle.Unwrap();
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch(Exception)
			{			
			}

		}

		private void Drawing_OnDraw(EventArgs args)
		{
			PrimesInfo.Draw();
			TargetSelector.Draw();
			SideBar.Draw();
			Orbwalker.Draw();
			//if(Utility.Map.GetMap()._MapType == Utility.Map.MapType.SummonersRift ||
			//	Utility.Map.GetMap()._MapType == Utility.Map.MapType.TwistedTreeline)
			//{
			//	Jungle.Draw();
			//}
			Activator.Draw();
		}
	}
}

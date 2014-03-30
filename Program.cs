using System;
using System.Collections.Generic;
using System.IO;

namespace Kokoban
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			System.AppDomain.CurrentDomain.ProcessExit += (sender, e) => Global.File.Save ("maps.sokoban");
			Console.CancelKeyPress += (sender, e) => Global.File.Save ("maps.sokoban");
			if (File.Exists ("maps.sokoban"))
				Global.Maps = Global.File.Open ("maps.sokoban");
			else
				Global.Maps = new List<MapStruct> ();
			Console.CursorVisible = false;
			GameState m = new MainMenu ();
			m.Loop ();
		}
	}
}

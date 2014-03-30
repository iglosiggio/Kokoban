using System;
using System.Collections;
using System.Collections.Generic;

namespace Kokoban
{
	public class MapSelector : MenuState
	{
		public override void Draw ()
		{
			Console.Clear ();
			if (Global.Maps.Count == 0) {
				Console.WriteLine ();
				Global.Center ("No tienes mapas, pulsa BORRAR y vé a editar uno!");
				return;
			}
			base.Draw ();
			MapStruct Preview = Global.Maps [selected];
			for (int y = 0; y < Preview.Map.GetLength(0); y++) {
				String line = "";
				for (int x = 0; x < Preview.Map.GetLength(1); x++) {
					if (x == Preview.PlayerX && y == Preview.PlayerY)
						line += '^';
					else
						line += (char)Preview.Map [y, x];
				}
				Console.SetCursorPosition(26, 3 + y);
				Console.Write (line);
			}
		}
		public override bool In (ConsoleKeyInfo Key)
		{
			if (Global.Maps.Count == 0)
				return false;
			switch (Key.Key) {
			case ConsoleKey.Delete:
				Global.Maps.Remove (Global.Maps [selected]);
				if (selected == Global.Maps.Count)
					selected -= 1;
				break;
			default:
				return base.In (Key);
			}
			return true;
		}
		public override Boolean Enter ()
		{
			GameState Game = new Map (Global.Maps [selected]);
			Game.Loop ();
			return true;
		}
		public override IList menu {
			get {
				return new Ugly.MapList ();
			}
		}
	}
}


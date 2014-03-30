using System;

namespace Kokoban
{
	public class MapSelector : GameState
	{
		Int32 selected = 0;
		public override void Draw ()
		{
			Console.Clear ();
			if (Global.Maps.Count == 0)
				return;
			for (int i = 0; i < Global.Maps.Count; i++) {
				Console.SetCursorPosition (2, 2 + i);
				if (i == selected) {
					ConsoleColor Back = Console.BackgroundColor;
					Console.BackgroundColor = Console.ForegroundColor;
					Console.ForegroundColor = Back;
					Console.WriteLine ("  {0,-3}", i);
					Console.ResetColor ();
				} else
					Console.WriteLine ("  {0,-3}", i);

			}
			MapStruct Preview = Global.Maps [selected];
			for (int y = 0; y < Preview.Map.GetLength(0); y++) {
				String line = "";
				for (int x = 0; x < Preview.Map.GetLength(1); x++) {
					if (x == Preview.PlayerX && y == Preview.PlayerY)
						line += '^';
					else
						line += (char)Preview.Map [y, x];
				}
				Console.SetCursorPosition(9, 3 + y);
				Console.Write (line);
			}
		}
		public override bool In (ConsoleKeyInfo Key)
		{
			if (Global.Maps.Count == 0)
				return false;
			switch (Key.Key) {
			case ConsoleKey.DownArrow:
				selected += selected < (Global.Maps.Count - 1) ? 1 : 0;
				break;
			case ConsoleKey.UpArrow:
				selected -= selected > 0 ? 1 : 0;
				break;
			case ConsoleKey.Delete:
				Global.Maps.Remove (Global.Maps [selected]);
				if (selected == Global.Maps.Count)
					selected -= 1;
				break;
			case ConsoleKey.Enter:
				GameState Game = new Map (Global.Maps [selected]);
				Console.Clear ();
				Game.Loop ();
				break;
			case ConsoleKey.Backspace:
				return false;
			}
			return true;
		}
	}
}


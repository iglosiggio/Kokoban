using System;
using System.Collections;

namespace Kokoban
{
	public abstract class MenuState : GameState
	{
		protected Int32 selected = 0;
		public abstract IList menu { get; }
		public MenuState ()
		{
		}
		public override void Draw ()
		{
			for (int i = 0; i < menu.Count; i++) {
				Console.SetCursorPosition (2, 2 + i);
				if (i == selected) {
					ConsoleColor Back = Console.BackgroundColor;
					Console.BackgroundColor = Console.ForegroundColor;
					Console.ForegroundColor = Back;
					Console.WriteLine ("  {0,-20}", menu[i]);
					Console.ResetColor ();
				} else
					Console.WriteLine ("  {0,-20}", menu[i]);	
			}
		}
		public override Boolean In(ConsoleKeyInfo Key) {
			switch (Key.Key) {
			case ConsoleKey.DownArrow:
				selected += selected < (menu.Count - 1) ? 1 : 0;
				break;
			case ConsoleKey.UpArrow:
				selected -= selected > 0 ? 1 : 0;
				break;
			case ConsoleKey.Enter:
				return Enter ();
			default:
				return base.In (Key);
			}
			return true;
		}
		public abstract Boolean Enter();
	}
}


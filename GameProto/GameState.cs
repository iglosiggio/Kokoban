using System;

namespace Kokoban
{
	public abstract class GameState
	{
		public abstract void Draw();
		public virtual Boolean In(ConsoleKeyInfo Key) {
			switch (Key.Key) {
			case ConsoleKey.Backspace:
				return false;
			}
			return true;
		}
		public virtual void Loop() {
			Console.Clear ();
			do {
				Draw();
			} while(In(Console.ReadKey(true)));
		}
	}
}


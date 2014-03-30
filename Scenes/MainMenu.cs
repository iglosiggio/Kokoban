using System;

namespace Kokoban
{
	public class MainMenu : GameState {
		public MainMenu() {}
		public override void Draw() {
			Console.SetCursorPosition (2, 3);
			Console.WriteLine (" 1. Editor de Mapas   ");
			Console.SetCursorPosition (2, 4);
			Console.WriteLine (" 2. Selector de Mapas ");
			Console.SetCursorPosition (2, 5);
			Console.WriteLine (" 0. Salir             ");
		}
		public override Boolean In(ConsoleKeyInfo Key) {
			GameState g;
			Console.Clear ();
			switch (Key.KeyChar) {
			case '1':
				g = new MapEditor (Global.Read<Int32>("Ingrese el ancho del mapa"), Global.Read<Int32>("Ingrese el alto del mapa"));
				Console.Clear ();
				g.Loop ();
				Console.Clear ();
				break;
			case '2':
				g = new MapSelector ();
				g.Loop ();
				Console.Clear ();
				break;
			case '0':
				return false;
			}
			return true;
		}
	}
}


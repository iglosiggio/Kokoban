using System;

namespace Kokoban
{
	public class MainMenu : MenuState {
		public MainMenu() {}
		public override System.Collections.IList menu {
			get {
				return new String[] {
					"Editor de mapas",
					"Selector de mapas",
					"Salir"
				};
			}
		}
		public override Boolean Enter ()
		{
			GameState g;
			switch (selected) {
			case 0:
				g = new MapEditor (Global.Read<Int32>("Ingrese el ancho del mapa"), Global.Read<Int32>("Ingrese el alto del mapa"));
				g.Loop ();
				Console.Clear ();
				break;
			case 1:
				g = new MapSelector ();
				g.Loop ();
				Console.Clear ();
				break;
			case 2:
				return false;
			}
			return true;
		}
	}
}


using System;
using System.IO;

namespace Kokoban
{
	class Map : MapState {
		public Map(string[] smap, Int32 X, Int32 Y) {
			InternalMap = new TileState[smap.Length, smap [0].Length];
			for (int y = 0; y < InternalMap.GetLength(0); y++) {
				for (int x = 0; x < InternalMap.GetLength(1); x++) {
					InitialState.Map [y, x] = (TileState) smap [y] [x];
				}
			}
			InitialState.PlayerX = X;
			InitialState.PlayerY = Y;
			LoadMap ();
		}
		public Map(TileState[,] iMap, Int32 X, Int32 Y) {
			InitialState.Map = iMap;
			InitialState.PlayerX = X;
			InitialState.PlayerY = Y;
			LoadMap ();
		}
		public Map(MapStruct TheMap) {
			InitialState = TheMap;
			LoadMap ();
		}
		protected void LoadMap() {
			InternalMap = (TileState[,])InitialState.Map.Clone ();
			Player.X = InitialState.PlayerX;
			Player.Y = InitialState.PlayerY;
			Player.LastMove = PlayerSprite.arriba;
		}
		public override void Draw ()
		{
			base.Draw ();
			Console.SetCursorPosition (0, InternalMap.GetLength (0) + 2);
			Global.Center("Pulse R para reiniciar el mapa y BORRAR para volver atrás");
		}
		public override Boolean In(ConsoleKeyInfo Key) {
			switch (Key.Key) {
			case ConsoleKey.UpArrow:
				Move (0, -1);
				Player.LastMove = PlayerSprite.arriba;
				break;
			case ConsoleKey.DownArrow:
				Move (0, 1);
				Player.LastMove = PlayerSprite.abajo;
				break;
			case ConsoleKey.LeftArrow:
				Move (-1, 0);
				Player.LastMove = PlayerSprite.izquierda;
				break;
			case ConsoleKey.RightArrow:
				Move (1, 0);
				Player.LastMove = PlayerSprite.derecha;
				break;
			case ConsoleKey.R:
				LoadMap ();
				break;
			default:
				return base.In (Key);
			}
			return true;
		}
		Boolean Move(Int32 x, Int32 y) {
			try {
				switch (InternalMap [Player.Y + y, Player.X + x]) {
				case TileState.vacio:
					Player.X += x;
					Player.Y += y;
					return true;
				case TileState.movil:
					switch (InternalMap[Player.Y + 2*y, Player.X + 2*x]) {
					case TileState.fijo:
						return false;
					case TileState.movil:
						return false;
					case TileState.movilUbicado:
						return false;
					case TileState.vacio:
						InternalMap[Player.Y + y, Player.X + x] = TileState.vacio;
						InternalMap[Player.Y + 2*y, Player.X + 2*x] = TileState.movil;
						break;
					case TileState.punto:
						InternalMap[Player.Y + y, Player.X + x] = TileState.vacio;
						InternalMap[Player.Y + 2*y, Player.X + 2*x] = TileState.movilUbicado;
						break;
					}
					Player.X += x;
					Player.Y += y;
					return true;
				case TileState.movilUbicado:
					switch (InternalMap[Player.Y + 2*y, Player.X + 2*x]) {
					case TileState.fijo:
						return false;
					case TileState.movil:
						return false;
					case TileState.movilUbicado:
						return false;
					case TileState.vacio:
						InternalMap[Player.Y + y, Player.X + x] = TileState.punto;
						InternalMap[Player.Y + 2*y, Player.X + 2*x] = TileState.movil;
						break;
					case TileState.punto:
						InternalMap[Player.Y + y, Player.X + x] = TileState.punto;
						InternalMap[Player.Y + 2*y, Player.X + 2*x] = TileState.movilUbicado;
						break;
					}
					Player.X += x;
					Player.Y += y;
					return true;
				case TileState.fijo:
					return false;
				case TileState.punto:
					Player.X += x;
					Player.Y += y;
					return true;
				}
			} catch (IndexOutOfRangeException) {
				return false;
			}
			return false;
		}
	}
	
}

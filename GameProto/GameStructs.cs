using System;

namespace Kokoban {
	[Serializable]
	public enum TileState {
		vacio = ' ', fijo = '#', movil = 'o', punto = '·', movilUbicado = 'O'
	}
	public enum PlayerSprite {
		arriba = '^', abajo = 'v', izquierda = '<', derecha = '>'
	}
	public struct PlayerStruct 
	{
		public PlayerSprite LastMove;
		public Int32 X;
		public Int32 Y;
	}
	[Serializable]
	public struct MapStruct{
		public MapStruct(TileState[,] map, Int32 x, Int32 y) {
			Map = map;
			PlayerX = x;
			PlayerY = y;
		}
		public TileState[,] Map;
		public Int32 PlayerX, PlayerY;
	}
}
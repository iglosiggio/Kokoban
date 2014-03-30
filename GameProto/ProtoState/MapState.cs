using System;

namespace Kokoban
{
	
	public abstract class MapState : GameState
	{
		protected MapStruct InitialState;
		protected PlayerStruct Player;
		protected TileState[,] InternalMap;
		public override void Draw() {
			Console.SetCursorPosition(0, 0);
			for (int y = 0; y < InternalMap.GetLength(0); y++) {
				String map = "";
				for (int x = 0; x < InternalMap.GetLength (1); x++)
					if (x == Player.X && y == Player.Y)
						map += (char)Player.LastMove;
					else
						map += (char)InternalMap [y, x];
				Global.Center (map);
			}
		}
		public override void Loop() {
			Console.Clear ();
			Boolean win = false;
			do {
				win = true;
				Draw();
				foreach(TileState tile in InternalMap)
					if(tile == TileState.punto)
						win = false;
			} while(In(Console.ReadKey(true)) && !win);
			Console.SetCursorPosition (0, InternalMap.GetLength (0) + 3);
			Global.Center ("You win!");
			Console.ReadKey ();
			Console.SetCursorPosition (0, 0);
		}
	}
}

using System;

namespace Kokoban
{
	public abstract class GameState
	{
		public abstract void Draw();
		public abstract Boolean In(ConsoleKeyInfo Key);
		public virtual void Loop() {
			do {
				Draw();
			} while(In(Console.ReadKey(true)));
		}
	}
	public abstract class MapState : GameState
	{
		protected MapStruct InitialState;
		protected PlayerStruct Player;
		protected TileState[,] InternalMap;
		public override void Draw() {
			String map = "";
			for (int y = 0; y < InternalMap.GetLength(0); y++) {
				for (int x = 0; x < InternalMap.GetLength (1); x++)
					if (x == Player.X && y == Player.Y)
						map += (char)Player.LastMove;
					else
						map += (char)InternalMap [y, x];
				map += '\n';
			}
			Console.SetCursorPosition(0, 0);
			Console.Write(map);
		}
		public override void Loop() {
			Boolean win = false;
			do {
				win = true;
				Draw();
				foreach(TileState tile in InternalMap)
					if(tile == TileState.punto)
						win = false;
			} while(In(Console.ReadKey(true)) && !win);
			Console.SetCursorPosition (2, InternalMap.GetLength (0) + 1);
			Console.Write ("You Win!");
			Console.SetCursorPosition (0, 0);
		}
	}
}


using System;
using System.IO;

namespace Kokoban
{
	class MapEditor : MapState {
		struct Point {
			public Point(Int32 x, Int32 y) {
				X = x;
				Y = y;
			}
			public Int32 X, Y;
		}
		Point LastMove = new Point(1, 0);
		Point Pointer;
		public MapEditor() : this(16, 16) {}
		public MapEditor(Int32 Width, Int32 Height) {
			InternalMap = new TileState[Height, Width];
			for (int y = 0; y < InternalMap.GetLength (0); y++)
				for (int x = 0; x < InternalMap.GetLength (1); x++)
					InternalMap [y, x] = TileState.vacio;
			Player.LastMove = PlayerSprite.arriba;
			Player.X = 1;
			Player.Y = 1;
		}
		public override void Draw ()
		{
			base.Draw ();
			Console.SetCursorPosition (Pointer.X, Pointer.Y);
			ConsoleColor Back = Console.BackgroundColor;
			Console.BackgroundColor = Console.ForegroundColor;
			Console.ForegroundColor = Back;
			if (Pointer.X == Player.X && Pointer.Y == Player.Y)
				Console.Write((char)Player.LastMove);
			else
				Console.Write((char)InternalMap [Pointer.Y, Pointer.X]);
			Console.ResetColor ();
			Console.SetCursorPosition (0, InternalMap.GetLength (0) + 2);
			Console.WriteLine ("  Flechas -> Mover cursor     P -> Jugador");
			Console.WriteLine ("  F       -> Pared            O -> Objetivo");
			Console.WriteLine ("  m       -> Caja             M -> Caja Ubicada");
			Console.WriteLine ("  SUPR    -> Espacio vacío    R -> Reiniciar mapa");
			Console.WriteLine ("  BORRAR  -> Volver atrás     INICIO -> Probar nivel");
			Console.WriteLine ("    PULSE S PARA GUARDAR EL MAPA EN EL ESPACIO {0}", Global.Maps.Count);
		}
		public override Boolean In(ConsoleKeyInfo Key) {
			switch (Key.Key) {
			case ConsoleKey.UpArrow:
				LastMove = new Point (0, -1);
				MovePointer (LastMove);
				break;
			case ConsoleKey.DownArrow:
				LastMove = new Point (0, 1);
				MovePointer (LastMove);
				break;
			case ConsoleKey.LeftArrow:
				LastMove = new Point (-1, 0);
				MovePointer (LastMove);
				break;
			case ConsoleKey.RightArrow:
				LastMove = new Point (1, 0);
				MovePointer (LastMove);
				break;
			case ConsoleKey.P:
				Player.X = Pointer.X;
				Player.Y = Pointer.Y;
				break;
			case ConsoleKey.F:
				InternalMap [Pointer.Y, Pointer.X] = TileState.fijo;
				MovePointer (LastMove);
				break;
			case ConsoleKey.M:
				if((Key.Modifiers & ConsoleModifiers.Shift) != 0)
					InternalMap [Pointer.Y, Pointer.X] = TileState.movilUbicado;
				else
					InternalMap [Pointer.Y, Pointer.X] = TileState.movil;
				break;
			case ConsoleKey.O:
				InternalMap [Pointer.Y, Pointer.X] = TileState.punto;
				break;
			case ConsoleKey.Delete:
				InternalMap [Pointer.Y, Pointer.X] = TileState.vacio;
				MovePointer (LastMove);
				break;
			case ConsoleKey.Home:
				TileState[,] MapClone = (TileState[,])InternalMap.Clone ();
				Map Game = new Map (MapClone, Player.X, Player.Y);
				Game.Loop ();
				Console.ReadKey ();
				Console.Clear();
				break;
			case ConsoleKey.Backspace:
				return false;
			case ConsoleKey.R:
				for (int y = 0; y < InternalMap.GetLength (0); y++)
					for (int x = 0; x < InternalMap.GetLength (1); x++)
						InternalMap [y, x] = TileState.vacio;
				break;
			case ConsoleKey.S:
				Global.Maps.Add(new MapStruct((TileState[,])InternalMap.Clone(), Player.X, Player.Y));
				break;
			}
			return true;
		}
		public override void Loop() {
			do {
				Draw();
			} while(In(Console.ReadKey(true)));
		}
		Boolean MovePointer(Point P) {
			try {
				InternalMap[Pointer.Y + P.Y, Pointer.X + P.X].Equals(0);
			} catch (IndexOutOfRangeException) {
				return false;
			}
			Pointer.X += P.X;
			Pointer.Y += P.Y;
			return true;
		}
	}
	
}

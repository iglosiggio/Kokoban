using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kokoban
{
	public static class Global
	{
		public static List<MapStruct> Maps;
		public static class File {
			public static List<MapStruct> Open(string path) {
				StreamReader Archivo = new StreamReader (path);
				BinaryFormatter Formatter = new BinaryFormatter ();
				List<MapStruct> rval = (List<MapStruct>)Formatter.Deserialize (Archivo.BaseStream);
				Archivo.Close ();
				return rval ;
			}
			public static void Save(string path) {
				StreamWriter Archivo = new StreamWriter (path);
				BinaryFormatter Formatter = new BinaryFormatter ();
				Formatter.Serialize (Archivo.BaseStream, Maps);
				Archivo.Close ();
			}
		}
		public static T Read<T> (String Texto) {
			Console.Write ("{0}: ", Texto);
			String Line = Console.ReadLine ();
			try {
				Object rval = Convert.ChangeType (Line, typeof(T));
				return (T)rval;
			} catch (Exception) {
				return default(T);
			}
		}
	}
}


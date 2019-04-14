using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("weaponList", "currentLoadout")]
	public class ES3Type_PlayerLoadout : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_PlayerLoadout() : base(typeof(PlayerLoadout)){ Instance = this; }

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (PlayerLoadout)obj;
			
			writer.WriteProperty("currentLoadout", instance.currentLoadout);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerLoadout)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					case "currentLoadout":
						instance.currentLoadout = reader.Read<PlayerLoadout.WeaponTypes[]>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_PlayerLoadoutArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_PlayerLoadoutArray() : base(typeof(PlayerLoadout[]), ES3Type_PlayerLoadout.Instance)
		{
			Instance = this;
		}
	}
}
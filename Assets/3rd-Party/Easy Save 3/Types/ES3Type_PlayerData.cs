using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("HealthLevel", "FireRateLevel", "BulletDamageLevel", "BulletNumLevel", "AttractorLevel", "Sp")]
	public class ES3Type_PlayerData : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_PlayerData() : base(typeof(PlayerData)){ Instance = this; }

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (PlayerData)obj;
			
			writer.WritePrivateField("HealthLevel", instance);
			writer.WritePrivateField("FireRateLevel", instance);
			writer.WritePrivateField("BulletDamageLevel", instance);
			writer.WritePrivateField("BulletNumLevel", instance);
			writer.WritePrivateField("AttractorLevel", instance);
			writer.WritePrivateField("Sp", instance);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "HealthLevel":
					reader.SetPrivateField("HealthLevel", reader.Read<System.Int32>(), instance);
					break;
					case "FireRateLevel":
					reader.SetPrivateField("FireRateLevel", reader.Read<System.Int32>(), instance);
					break;
					case "BulletDamageLevel":
					reader.SetPrivateField("BulletDamageLevel", reader.Read<System.Int32>(), instance);
					break;
					case "BulletNumLevel":
					reader.SetPrivateField("BulletNumLevel", reader.Read<System.Int32>(), instance);
					break;
					case "AttractorLevel":
					reader.SetPrivateField("AttractorLevel", reader.Read<System.Int32>(), instance);
					break;
					case "Sp":
					reader.SetPrivateField("Sp", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_PlayerDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_PlayerDataArray() : base(typeof(PlayerData[]), ES3Type_PlayerData.Instance)
		{
			Instance = this;
		}
	}
}
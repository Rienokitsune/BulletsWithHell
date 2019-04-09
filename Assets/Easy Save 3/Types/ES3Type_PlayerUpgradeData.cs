using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("type", "level")]
	public class ES3Type_PlayerUpgradeData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_PlayerUpgradeData() : base(typeof(PlayerData.PlayerUpgradeData)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (PlayerData.PlayerUpgradeData)obj;
			
			writer.WriteProperty("type", instance.type);
			writer.WritePrivateField("level", instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerData.PlayerUpgradeData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "type":
						instance.type = reader.Read<UpgradeTypes.UpgradeType>();
						break;
					case "level":
					reader.SetPrivateField("level", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new PlayerData.PlayerUpgradeData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_PlayerUpgradeDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_PlayerUpgradeDataArray() : base(typeof(PlayerData.PlayerUpgradeData[]), ES3Type_PlayerUpgradeData.Instance)
		{
			Instance = this;
		}
	}
}
using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("Level_ID", "topScore", "topTime", "goalChecks")]
	public class ES3Type_LevelSaveData : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_LevelSaveData() : base(typeof(LevelSaveData)){ Instance = this; }

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (LevelSaveData)obj;
			
			writer.WriteProperty("Level_ID", instance.Level_ID, ES3Type_string.Instance);
			writer.WritePrivateField("topScore", instance);
			writer.WritePrivateField("topTime", instance);
			writer.WritePrivateField("goalChecks", instance);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (LevelSaveData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Level_ID":
						instance.Level_ID = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "topScore":
					reader.SetPrivateField("topScore", reader.Read<System.Int32>(), instance);
					break;
					case "topTime":
					reader.SetPrivateField("topTime", reader.Read<System.Single>(), instance);
					break;
					case "goalChecks":
					reader.SetPrivateField("goalChecks", reader.Read<System.Boolean[]>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

	public class ES3Type_LevelSaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_LevelSaveDataArray() : base(typeof(LevelSaveData[]), ES3Type_LevelSaveData.Instance)
		{
			Instance = this;
		}
	}
}
using Newtonsoft.Json;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement
{
	public class JsonSerializer : IDataSerializer
	{
		public TData Deserialize<TData>(string serializedObject)
		{
			return JsonConvert.DeserializeObject<TData>(serializedObject, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
			});
		}

		public string Serialize<TData>(TData data)
		{
			return JsonConvert.SerializeObject(data, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.Auto,
				TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
			});
		}
	}
}

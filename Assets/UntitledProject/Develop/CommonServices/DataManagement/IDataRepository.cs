namespace Assets.UntitledProject.Develop.CommonServices.DataManagement
{
	public interface IDataRepository
	{
		public string Read(string key);

		public void Write(string key, string serializedData);

		public void Remove(string key);

		public bool Exists(string key);
	}
}
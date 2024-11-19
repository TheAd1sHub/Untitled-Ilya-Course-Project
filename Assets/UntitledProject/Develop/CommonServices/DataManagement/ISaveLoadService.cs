namespace Assets.UntitledProject.Develop.CommonServices.DataManagement
{
	public interface ISaveLoadService
	{
		public bool TryLoad<TData>(out TData data) where TData : ISaveData;

		public void Save<TData>(TData data) where TData : ISaveData;
	}
}
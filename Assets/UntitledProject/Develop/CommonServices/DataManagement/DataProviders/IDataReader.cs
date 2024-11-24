namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	public interface IDataReader<TData> where TData: ISaveData
	{
		public void ReadFrom(TData data);
	}
}

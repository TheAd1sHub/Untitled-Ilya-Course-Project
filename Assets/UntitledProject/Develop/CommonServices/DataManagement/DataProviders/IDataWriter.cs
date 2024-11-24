namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	public interface IDataWriter<TData> where TData : ISaveData
	{
		public void WriteTo(TData data);
	}
}

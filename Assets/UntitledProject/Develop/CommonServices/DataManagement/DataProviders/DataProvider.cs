using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	public abstract class DataProvider<TData> where TData : ISaveData
	{
		private readonly ISaveLoadService _saveLoadService;

		private List<IDataWriter<TData>> _dataWriters = new();
		private List<IDataReader<TData>> _dataReaders = new();

		public DataProvider(ISaveLoadService saveLoadService)
		{
			_saveLoadService = saveLoadService;
		}

		private TData Data { get; set; }

		public void RegisterWriter(IDataWriter<TData> writer)
		{
			if (_dataWriters.Contains(writer))
				throw new ArgumentException($"The '{writer}' {nameof(IDataWriter<TData>)} is already registered");

			_dataWriters.Add(writer);
		}

		public void RegisterReader(IDataReader<TData> reader)
		{
			if (_dataReaders.Contains(reader))
				throw new ArgumentException($"The '{reader}' {nameof(IDataReader<TData>)} is already registered");

			_dataReaders.Add(reader);
		}

		public void Load()
		{
			if (_saveLoadService.TryLoad(out TData data))
				Data = data;
			else
				ResetToDefaults();

			foreach (IDataReader<TData> reader in _dataReaders)
				reader.ReadFrom(Data);
		}

		public void Save()
		{
			foreach (IDataWriter<TData> writer in _dataWriters)
				writer.WriteTo(Data);

			_saveLoadService.Save(Data);
		}

		protected abstract TData GetOriginData();

		private void ResetToDefaults()
		{
			Data = GetOriginData();
			Save();
		}
	}
}

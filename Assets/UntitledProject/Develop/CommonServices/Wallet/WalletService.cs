using Assets.UntitledProject.Develop.Utils.Reactive;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;

namespace Assets.UntitledProject.Develop.CommonServices.Wallet
{
	public class WalletService : IDataReader<PlayerData>, IDataWriter<PlayerData>
	{
		private Dictionary<CurrencyType, ReactiveVariable<int>> _currencies = new();

		public WalletService(PlayerDataProvider playerDataProvider)
		{
			playerDataProvider.RegisterWriter(this);
			playerDataProvider.RegisterReader(this);
		}

		public List<CurrencyType> AvaiableCurrencies => _currencies.Keys.ToList();

		public IReadOnlyVariable<int> GetCurrencyAmount(CurrencyType type)
			=> _currencies[type];

		public bool HasEnough(CurrencyType type, int amount) 
			=> _currencies[type].Value >= amount;

		public void Spend(CurrencyType type, int amount)
		{
			if (HasEnough(type, amount) == false)
				throw new ArgumentException($"There is not enough {type} to spend. {amount} requested, got only {_currencies[type].Value}.");

			_currencies[type].Value -= amount;
		}

		public void Add(CurrencyType type, int amount)
		{
			checked
			{
				_currencies[type].Value += amount;
			}
		}

		public void ReadFrom(PlayerData data)
		{
			foreach (KeyValuePair<CurrencyType, int> currency in data.WalletData)
			{
				if (_currencies.ContainsKey(currency.Key))
					_currencies[currency.Key].Value = currency.Value;
				else
					_currencies.Add(currency.Key, new ReactiveVariable<int>(currency.Value));
			}
		}

		public void WriteTo(PlayerData data)
		{
			foreach (KeyValuePair<CurrencyType, ReactiveVariable<int>> currency in _currencies)
			{
				if (data.WalletData.ContainsKey(currency.Key))
					data.WalletData[currency.Key] = currency.Value.Value;
				else
					data.WalletData.Add(currency.Key, currency.Value.Value);
			}
		}
	}
}

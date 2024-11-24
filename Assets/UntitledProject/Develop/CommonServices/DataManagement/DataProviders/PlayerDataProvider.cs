using Assets.UntitledProject.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	public class PlayerDataProvider : DataProvider<PlayerData>
	{
		public PlayerDataProvider(ISaveLoadService saveLoadService)
			: base(saveLoadService)
		{
		}

		protected override PlayerData GetOriginData()
		{
			return new PlayerData()
			{
				WalletData = GetInitialWalletData()
			};
		}

		private Dictionary<CurrencyType, int> GetInitialWalletData()
		{
			Dictionary<CurrencyType, int> walletData = new();

			foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
				walletData[currencyType] = 0;

			return walletData;
		}
	}
}

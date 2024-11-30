using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	public class PlayerDataProvider : DataProvider<PlayerData>
	{
		private ConfigsProviderService _configsProviderService;

		public PlayerDataProvider(
			ISaveLoadService saveLoadService,
			ConfigsProviderService configsProviderService)
			: base(saveLoadService)
		{
			_configsProviderService = configsProviderService;
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
			{
				if (currencyType == CurrencyType.None)
					continue;

				int currencyStartValue = _configsProviderService.StartWalletConfig.GetStartValueFor(currencyType);
				walletData.Add(currencyType, currencyStartValue);
			}

			return walletData;
		}
	}
}

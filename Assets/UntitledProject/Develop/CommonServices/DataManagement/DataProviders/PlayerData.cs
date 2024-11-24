
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	[Serializable]
	public class PlayerData : ISaveData
	{
		public Dictionary<CurrencyType, int> WalletData = new();
	}
}

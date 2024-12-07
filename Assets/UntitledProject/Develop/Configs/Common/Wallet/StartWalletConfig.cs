using Assets.UntitledProject.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Configs.Common.Wallet
{
	[CreateAssetMenu(menuName = "Configs/Common/Wallet/NewStartWalletConfig", fileName = "StartWalletConfig")]
	public sealed class StartWalletConfig : ScriptableObject
	{
		[SerializeField] private List<CurrencyConfig> _values;

		public int GetStartValueFor(CurrencyType currencyType)
			=> _values.Single(config => config.Type == currencyType).Value;

		private void OnValidate()
		{
			foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
			{
				if (type == CurrencyType.None)
					continue;

				int currencyConfigsAmount = _values.Where(config => config.Type == type).Count();

				if (currencyConfigsAmount == 0)
					Debug.LogWarning($"No start config for {type} currency found");
				
				if (currencyConfigsAmount > 1)
					Debug.LogWarning($"Found several configs for {type} currency. This is not supported.");
			}
		}

		[Serializable]
		private sealed class CurrencyConfig
		{
			[field: SerializeField] public CurrencyType Type { get; private set; }
			[field: SerializeField] public int Value { get; private set; }
		}
	}
}

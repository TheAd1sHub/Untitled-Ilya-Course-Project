using Assets.UntitledProject.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Configs.Common.Wallet
{
	[CreateAssetMenu(menuName = "Configs/Common/Wallet/NewCurrencyIconsConfig", fileName = "CurrencyIconsConfig")]
	public sealed class CurrencyIconsConfig : ScriptableObject
	{
		[SerializeField] private List<CurrencyIconConfig> _configs;

		public Sprite GetSpriteFor(CurrencyType currencyType) => _configs.First(config => config.CurrencyType == currencyType).Sprite;

		private void OnValidate()
		{
			foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
			{
				if (type == CurrencyType.None)
					continue;

				int iconConfigsAmount = _configs.Where(config => config.CurrencyType == type).Count();

				if (iconConfigsAmount == 0)
					Debug.LogWarning($"No start config for {type} currency found");

				if (iconConfigsAmount > 1)
					Debug.LogWarning($"Found several configs for {type} currency. This is not supported.");
			}
		}

		[Serializable]
		private sealed class CurrencyIconConfig
		{
			[field: SerializeField] public CurrencyType CurrencyType { get; private set; }
			[field: SerializeField] public Sprite Sprite { get; private set; }
		}
	}
}

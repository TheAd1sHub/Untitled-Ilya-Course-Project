using Assets.UntitledProject.Develop.CommonServices.Wallet;
using Assets.UntitledProject.Develop.Configs.Common.Wallet;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Utils.Reactive;
using System;

namespace Assets.UntitledProject.Develop.CommonUI.Wallet
{
	public sealed class CurrencyPresenter : IInitializable, IDisposable
	{
		private IReadOnlyVariable<int> _currency;
		private CurrencyType _currencyType;
		private CurrencyIconsConfig _currencyIconsConfig;

		private	IconWithText _currencyView;

		public CurrencyPresenter(
			IReadOnlyVariable<int> currency,
			CurrencyType currencyType,
			IconWithText currencyView,
			CurrencyIconsConfig currencyIconsConfig
			)
		{
			_currency = currency;
			_currencyType = currencyType;
			_currencyView = currencyView;
			_currencyIconsConfig = currencyIconsConfig;
		}

		public IconWithText View => _currencyView;

		public void Enable()
		{
			UpdateValue(_currency.Value);
			_currencyView.SetIcon(_currencyIconsConfig.GetSpriteFor(_currencyType));

			_currency.Changed += OnCurrencyChanged;
		}

		public void Disable()
		{
			_currency.Changed -= OnCurrencyChanged;
		}

		public void Initialize() => Enable();

		public void Dispose() => Disable();

		private void UpdateValue(int value) => _currencyView.SetText(value.ToString());

		private void OnCurrencyChanged(int oldValue, int newValue)
		{
			UpdateValue(newValue);
		}
	}
}
